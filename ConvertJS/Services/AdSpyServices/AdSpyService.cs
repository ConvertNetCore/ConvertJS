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
        public async Task<List<AdSpyPostDTO>> Search(string keyword,string forward_cursor,string user_id, string fb_dtsg,  string cookie)
        {

            try
            {
                //var baseUrl = "https://graph.facebook.com/v14.0";
                //var options = new RestClientOptions(baseUrl)
                //{
                //    MaxTimeout = -1,
                //    UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36",
                //};
                //var client = new RestClient(options);
                //var request = new RestRequest("https://www.facebook.com/ads/library/async/search_ads/?q="+keyword+"&count=100&forward_cursor="
                //    +forward_cursor+"&active_status=all&ad_type=all&countries\\[0\\]=VN&media_type=all&search_type=keyword_exact_phrase", Method.Post);
                //request.AddHeader("authority", " www.facebook.com");
                //request.AddHeader("accept", " */*");
                //request.AddHeader("accept-language", " vi,vi-VN;q=0.9,fr-FR;q=0.8,fr;q=0.7,en-US;q=0.6,en;q=0.5");
                //request.AddHeader("cache-control", " no-cache");
                //request.AddHeader("content-type", " application/x-www-form-urlencoded");
                //request.AddHeader("Cookie", cookie);
                //request.AddHeader("origin", " https://www.facebook.com");
                //request.AddHeader("pragma", " no-cache");
                //request.AddHeader("referer", " https://www.facebook.com/ads/library/?active_status=all&ad_type=all&country=VN&q=%22th%E1%BB%9Di%20trang%22&search_type=keyword_exact_phrase&media_type=all");
                //request.AddHeader("sec-ch-prefers-color-scheme", " light");
                //request.AddHeader("sec-ch-ua", " \"Google Chrome\";v=\"113\", \"Chromium\";v=\"113\", \"Not-A.Brand\";v=\"24\"");
                //request.AddHeader("sec-ch-ua-full-version-list", " \"Google Chrome\";v=\"113.0.5672.127\", \"Chromium\";v=\"113.0.5672.127\", \"Not-A.Brand\";v=\"24.0.0.0\"");
                //request.AddHeader("sec-ch-ua-mobile", " ?0,");
                //request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                //request.AddHeader("sec-ch-ua-platform-version", " \"10.0.0\"");
                //request.AddHeader("sec-fetch-dest", " empty");
                //request.AddHeader("sec-fetch-mode", " cors");
                //request.AddHeader("sec-fetch-site", " same-origin");
                //request.AddHeader("viewport-width", " 1198");
                //request.AddHeader("x-asbd-id", " 198387");
                //request.AddHeader("x-fb-lsd", " LD13gvkEmpWHQCac716lbZ");
                //var body = @"{
                //" + "\n" +
                //                @"  ""__user"": ""100071096111263"",
                //" + "\n" +
                //                @"  ""__a"": 1,
                //" + "\n" +
                //                @"  ""__req"": ""5v"",
                //" + "\n" +
                //                @"  ""__ccg"": ""EXCELLENT"",
                //" + "\n" +
                //                @"  ""fb_dtsg"": ""NAcNEbiS1A2fFZRv6aEgMwj-QPNDb3Cm-jiYn7cTK0fQQUHoGOaoxEA:48:1693328646""
                //" + "\n" +
                //@"}";
                //request.AddParameter(" application/x-www-form-urlencoded", body, ParameterType.RequestBody);
                //RestResponse response = await client.ExecuteAsync(request);



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

                request.AddParameter("q", keyword);
                request.AddParameter("count", "100");
                request.AddParameter("forward_cursor", forward_cursor);
                request.AddParameter("active_status", "all");
                request.AddParameter("ad_type", "all");
                request.AddParameter("countries[0]", "VN");
                request.AddParameter("media_type", "all");
                request.AddParameter("search_type", "keyword_exact_phrase");

                RestResponse response = client.Execute(request);

                var bmAccountResponse = JsonConvert.DeserializeObject<AdSpyResponseDTO>(response.Content.ToString());
                List<AdSpyPostDTO> AllUserDTOs = new List<AdSpyPostDTO>();
                foreach (var userDTO in bmAccountResponse.allResources)
                {

                    var bmUser = new AdSpyPostDTO
                    {
                        Id = "",
                        ImageURL = "",
                        Name = "",
                         CreateAt = DateTime.Now,
                         Content = "",
                         Url = "",
                        NumberLike = 0,
                        NumberComment = 0,
                       NumberShare = 0
    };

                    AllUserDTOs.Add(bmUser);

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
