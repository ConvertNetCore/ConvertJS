using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConvertJS.DTOs
{
    public class AccessTokenInfo
    {
        public string Fb_dtsg { get; set; }
        public string Access_token { get; set; }
        public string Jazoest { get; set; }
    }
    public class RequestHelper
    {
        public RequestHelper(RestClient? client = null)
        {
            this.client = client == null ? new RestClient() : client;
        }

        public RestClient client = new RestClient();

        public string? Get(string Url)
        {
            try
            {
                var request = new RestRequest(Url);
                var response = client.Execute(request);
                return response.Content;
            }
            catch (Exception)
            {

            }
            return null;
        }
        public string? PostJson(string Url, string JsonData)
        {
            try
            {
                var request = new RestRequest(Url, Method.Post);
                request.AddJsonBody(JsonData);
                var response = client.Execute(request);
                return response.Content;
            }
            catch (Exception)
            {

            }
            return null;
        }
        public string? PostForm(string Url, Dictionary<string, string> Parameters)
        {
            try
            {
                var request = new RestRequest(Url, Method.Post);
                foreach (var item in Parameters)
                {
                    request.AddParameter(item.Key, item.Value);
                }
                var response = client.Execute(request);
                return response.Content;
            }
            catch (Exception)
            {

            }
            return null;
        }
        public string? PostQueryParameters(string Url)
        {
            try
            {
                var request = new RestRequest(Url, Method.Post);
                var response = client.Execute(request);
                return response.Content;
            }
            catch (Exception)
            {

            }
            return null;
        }


        public T? Get<T>(string Url)
        {
            try
            {
                var request = new RestRequest(Url);
                var response = client.Execute(request);
                string? content = response.Content;
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception)
            {

            }
            return default;
        }
        public T? PostJson<T>(string Url, string JsonData)
        {
            try
            {
                var request = new RestRequest(Url, Method.Post);
                request.AddJsonBody(JsonData);
                var response = client.Execute(request);
                string? content = response.Content;
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception)
            {

            }
            return default;
        }
        public T? PostForm<T>(string Url, Dictionary<string, string> Parameters)
        {
            try
            {
                var request = new RestRequest(Url, Method.Post);
                foreach (var item in Parameters)
                {
                    request.AddParameter(item.Key, item.Value);
                }
                var response = client.Execute(request);
                string? content = response.Content;
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception)
            {

            }
            return default;
        }
        public T? PostQueryParameters<T>(string Url)
        {
            try
            {
                var request = new RestRequest(Url, Method.Post);
                var response = client.Execute(request);
                string? content = response.Content;
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception)
            {

            }
            return default;
        }
        //public string GetCookie(string name)
        //{
        //    // Retrieve the request's cookies collection
        //    var cookies = HttpContext.Request.Cookies;
        //    string tenCookieValue = Request.Cookies["ten_cookie"];
        //    // Check if the cookie with the specified name exists
        //    if (cookies.TryGetValue(name, out string value))
        //    {
        //        return value;
        //    }

        //    return null; // Cookie not found
        //}

        public async Task<AccessTokenInfo> GetToken()
        {

            var fb_dtsg = await GetFbDtsg();
            try
            {
                HttpClient httpClient = new HttpClient();

                // Lấy fb_dtsg và jazoest từ trang Facebook
                HttpResponseMessage fbResponse = await httpClient.GetAsync("https://www.facebook.com/");
                fbResponse.EnsureSuccessStatusCode();
                string fbPage = await fbResponse.Content.ReadAsStringAsync();

                string fb_dtsgPattern = @"name=""fb_dtsg"" value=""([^""]+)""";
                string jazoestPattern = @"name=""jazoest"" value=""([^""]+)""";

                Match fb_dtsgMatch = Regex.Match(fbPage, fb_dtsgPattern);
                Match jazoestMatch = Regex.Match(fbPage, jazoestPattern);

                //string fb_dtsg = fb_dtsgMatch.Success ? fb_dtsgMatch.Groups[1].Value : null;
                string jazoest = jazoestMatch.Success ? jazoestMatch.Groups[1].Value : null;

                // Lấy access_token từ trang Facebook Ads Manager
                HttpResponseMessage adsManagerResponse = await httpClient.GetAsync("https://www.facebook.com/adsmanager/manage/account");
                adsManagerResponse.EnsureSuccessStatusCode();
                string adsManagerPage = await adsManagerResponse.Content.ReadAsStringAsync();

                string accessTokenPattern = @"act=([^&]+)&";
                Match accessTokenMatch = Regex.Match(adsManagerPage, accessTokenPattern);

                string access_token = accessTokenMatch.Success ? accessTokenMatch.Groups[1].Value : null;

                if (!string.IsNullOrEmpty(fb_dtsg) && !string.IsNullOrEmpty(jazoest) && !string.IsNullOrEmpty(access_token))
                {
                    return new AccessTokenInfo
                    {
                        Fb_dtsg = fb_dtsg,
                        Access_token = access_token,
                        Jazoest = jazoest
                    };
                }
                else
                {
                    // Trả về thông tin lỗi hoặc giá trị mặc định tùy theo yêu cầu của bạn
                    return null;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Lỗi khi gửi yêu cầu HTTP: " + e.Message);
                // Trả về thông tin lỗi hoặc giá trị mặc định tùy theo yêu cầu của bạn
                return null;
            }
        }

        public async Task<string> GetFbDtsg()
        {
            using (HttpClient client = new HttpClient())
            {
                // Create and set the HTTP headers
                client.DefaultRequestHeaders.Add("authority", "graph.facebook.com");
                client.DefaultRequestHeaders.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                client.DefaultRequestHeaders.Add("accept-language", "en-US,en;q=0.9");
                client.DefaultRequestHeaders.Add("cache-control", "max-age=0");
                client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Google Chrome\";v=\"107\", \"Chromium\";v=\"107\", \"Not=A?Brand\";v=\"24\"");
                client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
                client.DefaultRequestHeaders.Add("sec-fetch-dest", "document");
                client.DefaultRequestHeaders.Add("sec-fetch-mode", "navigate");
                client.DefaultRequestHeaders.Add("sec-fetch-site", "none");
                client.DefaultRequestHeaders.Add("sec-fetch-user", "?1");
                client.DefaultRequestHeaders.Add("upgrade-insecure-requests", "1");
                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36");

                HttpResponseMessage response = await client.GetAsync("https://mbasic.facebook.com");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    // Handle the response content as needed
                    Console.WriteLine(content);
                    return content;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return "";
                    
                }
            }
        }
    }
}
