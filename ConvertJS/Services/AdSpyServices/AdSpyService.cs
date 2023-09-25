using ConvertJS.DTOs.ResponseDTO;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Numerics;

namespace ConvertJS.Services.AdSpyServices
{
    public interface IAdSpyService
    {
         Task<List<AdSpyPostDTO>> Search(string keyword, string forward_cursor, string user_id, string fb_dtsg, string cookie);
    }
    public class AdSpyService : IAdSpyService
    {
        private string getImgUrl(Result data)
        {
            if(data.snapshot.images.Count() != 0)
            {
                return data.snapshot.images.First().original_image_url;
            } 
            if(data.snapshot.videos.Count() != 0)
            {
                return data.snapshot.videos.First().video_preview_image_url;
            }
            return data.snapshot.page_profile_picture_url;
        }
        private DateTime GetCreateTime(Result data)
        {
            int timestamp = data.snapshot.creation_time??0;
            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
            return dateTime;
        }
        public async Task<List<AdSpyPostDTO>> Search(string keyword,string forward_cursor,string user_id, string fb_dtsg,  string cookie)
        {

            try
            {
                var client = new RestClient("https://www.facebook.com");
                var request = new RestRequest("ads/library/async/search_ads", Method.Post);

                request.AddHeader("authority", "www.facebook.com");
                request.AddHeader("accept", "*/*");
                request.AddHeader("accept-language", "vi,vi-VN;q=0.9,fr-FR;q=0.8,fr;q=0.7,en-US;q=0.6,en;q=0.5");
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddHeader("cookie", cookie);
                request.AddHeader("origin", "https://www.facebook.com");
                request.AddHeader("pragma", "no-cache");
                request.AddHeader("referer", "https://www.facebook.com/ads/library/?active_status=all&ad_type=all&country=VN&q=%22th%E1%BB%9Di%20trang%22&search_type=keyword_exact_phrase&media_type=all");
                request.AddHeader("sec-ch-prefers-color-scheme", "light");
                request.AddHeader("sec-ch-ua", "\"Google Chrome\";v=\"113\", \"Chromium\";v=\"113\", \"Not-A.Brand\";v=\"24\"");
                request.AddHeader("sec-ch-ua-full-version-list", "\"Google Chrome\";v=\"113.0.5672.127\", \"Chromium\";v=\"113.0.5672.127\", \"Not-A.Brand\";v=\"24.0.0.0\"");
                request.AddHeader("sec-ch-ua-mobile", "?0");
                request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                request.AddHeader("sec-ch-ua-platform-version", "\"10.0.0\"");
                request.AddHeader("sec-fetch-dest", "empty");
                request.AddHeader("sec-fetch-mode", "cors");
                request.AddHeader("sec-fetch-site", "same-origin");
                request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36");
                request.AddHeader("viewport-width", "1198");
                request.AddHeader("x-asbd-id", "198387");
                request.AddHeader("x-fb-lsd", "LD13gvkEmpWHQCac716lbZ");

                request.AddParameter("__user", user_id);
                request.AddParameter("__a", "1");
                request.AddParameter("__req", "5v");
                request.AddParameter("__ccg", "EXCELLENT");
                request.AddParameter("fb_dtsg", fb_dtsg);

                request.AddQueryParameter("q", keyword);
                request.AddQueryParameter("count", "100");
                request.AddQueryParameter("forward_cursor", forward_cursor);
                request.AddQueryParameter("active_status", "all");
                request.AddQueryParameter("ad_type", "all");
                request.AddQueryParameter("countries[0]", "VN");
                request.AddQueryParameter("media_type", "all");
                request.AddQueryParameter("search_type", "keyword_exact_phrase");
                RestResponse response = client.Execute(request);
                if (response.Content != null) response.Content = response.Content.Replace("for (;;);", "");
                var adSpys = JsonConvert.DeserializeObject<AdSpyResponseDTO>(response.Content.ToString());
                List<AdSpyPostDTO> AllUserDTOs = new List<AdSpyPostDTO>();
                if (adSpys == null) return new List<AdSpyPostDTO>();
                if (adSpys.payload == null) return new List<AdSpyPostDTO>();
                if (adSpys.payload.results == null) return new List<AdSpyPostDTO>();
                foreach (var adSpy in adSpys.payload.results)
                {
                    try
                    {
                        var adSpyPost = new AdSpyPostDTO
                        {
                            keyword = keyword,
                            Id = adSpy.First().adArchiveID,
                            ImageURL = getImgUrl(adSpy.First()),
                            Name = adSpy.First().snapshot.page_name,
                            CreateAt = GetCreateTime(adSpy.First()),
                            Content = adSpy.First().snapshot.body.markup.__html,
                            Url = adSpy.First().snapshot.page_profile_uri,
                            NumberLike = adSpy.First().snapshot.page_like_count ?? 0,
                        };

                        AllUserDTOs.Add(adSpyPost);
                    }
                    catch { }
                }
                return AllUserDTOs;
            }
            catch (Exception ex)
            {
                return new List<AdSpyPostDTO>();
            }

        }
    }
}
