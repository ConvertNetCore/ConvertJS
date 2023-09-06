using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace ConvertJS.Services.AppealCheckServices
{
    public interface IAppealCheckService
    {
         Task<object> Khang_buoc_1(string id, string ids_issue_ent_id, string fb_dtsg, string jazoest, string uid, string cookie);
         Task<object> Khang_buoc_1_pass2(string id, string ids_issue_ent_id, string fb_dtsg, string jazoest, string uid, string cookie);
         Task<object> Khang_buoc_2(string id, string fb_dtsg, string jazoest, string uid, string cookie);
        Task<object> Khang_buoc_2bm(string id, string fb_dtsg, string jazoest, string uid, string cookie);
    }
    public class AppealCheckService : IAppealCheckService
    {
        public async Task<object> Khang_buoc_1(string id, string ids_issue_ent_id, string fb_dtsg, string jazoest, string uid, string cookie)
        {
            
                try
                {
                var client = new RestClient("https://www.facebook.com");
                var request = new RestRequest("api/graphql", Method.Post);

                // Set up request headers
                request.AddHeader("authority", "www.facebook.com");
                request.AddHeader("accept", "*/*");
                request.AddHeader("accept-language", "en-US,en;q=0.9");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddHeader("origin", "https://www.facebook.com");
                request.AddHeader("referer", "https://www.facebook.com/accountquality/100088675546057/247746905242/?asset_view_type=asset");
                request.AddHeader("sec-ch-prefers-color-scheme", "light");
                request.AddHeader("sec-ch-ua", "\"Not_A Brand\";v=\"99\", \"Google Chrome\";v=\"109\", \"Chromium\";v=\"109\"");
                request.AddHeader("sec-ch-ua-mobile", "?0");
                request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                request.AddHeader("sec-fetch-dest", "empty");
                request.AddHeader("sec-fetch-mode", "cors");
                request.AddHeader("sec-fetch-site", "same-origin");
                request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36");
                request.AddHeader("viewport-width", "1349");
                request.AddHeader("x-fb-friendly-name", "useALEBanhammerAppealMutation");
                request.AddHeader("x-fb-lsd", "O59clWSQAHa2KcbZRkurck");
                request.AddHeader("Cookie", cookie);

                // Set up request parameters
                request.AddParameter("av", id);
                request.AddParameter("session_id", "6b124788a85ea3de");
                request.AddParameter("__user", id);
                request.AddParameter("__a", "1");
                request.AddParameter("__dyn", "7xeUmxa2C5rgydwCwRyU8EKnFG5UkBwCwgE98nCG6UmCyEgwjojyUW3eF8iBxa7GzU4q5Eiz8WdwJzUi-4UgwgUgwqoqyoyazoO4o461mCwOxa7FEhwywCxq2u3K6UGq1eKFpobQUTwJHiG9zQE8RVodoKUryonwu8sxep3bwExm3G4UhwXxW9wgolUScyobo4a5U2dz8twAKmu7EK3i2a3Fe6rwiolDwFwBgak48W2e2i3mbxOfxa2y5E5WUru6ogyHwyx6i8wxK2efK2W1dx-q4VEhG7o2swQzUS2W2K4E6-bxu3ydCgqw-z8c8-5aDBwEBwKG13y85i4oKqbDyoOEbVEHyU8U3yDwbm1bwzwqp87q5rwCwmo4S");
                request.AddParameter("__csr", "");
                request.AddParameter("__req", "k");
                request.AddParameter("__hs", "19391.BP:DEFAULT.2.0.0.0.0");
                request.AddParameter("dpr", "1");
                request.AddParameter("__ccg", "EXCELLENT");
                request.AddParameter("__rev", "1006907533");
                request.AddParameter("__s", "yug5vd:rkwrf1:8dxu3z");
                request.AddParameter("__hsi", "7195846812736417894");
                request.AddParameter("__comet_req", "0");
                request.AddParameter("fb_dtsg", fb_dtsg);
                request.AddParameter("jazoest",jazoest);
                request.AddParameter("lsd", "O59clWSQAHa2KcbZRkurck");
                request.AddParameter("__aaid", "5887772874637720");
                request.AddParameter("__spin_r", "1006907533");
                request.AddParameter("__spin_b", "trunk");
                request.AddParameter("__spin_t", "1675413645");
                request.AddParameter("fb_api_caller_class", "RelayModern");
                request.AddParameter("fb_api_req_friendly_name", "useALEBanhammerAppealMutation");
                request.AddParameter("variables", "{\"input\":{\"client_mutation_id\":\"1\",\"actor_id\":\"" + id + "\",\"entity_id\":\"" + uid + "\",\"ids_issue_ent_id\":\"" + ids_issue_ent_id + "\",\"appeal_comment\":\"I'm not sure which policy was violated.\",\"callsite\":\"ACCOUNT_QUALITY\"}}");
                request.AddParameter("server_timestamps", "true");
                request.AddParameter("doc_id", "5329872773703511");

                // Send the request
                RestResponse response = client.Execute(request);
                return response.Content;
                }
                catch (Exception ex)
                {
                    return new { Error = ex };
                }
           
        }
        
        public async Task<object> Khang_buoc_1_pass2(string id, string ids_issue_ent_id, string fb_dtsg, string jazoest, string uid,string cookie)
        {
            
                try
                {
                var client = new RestClient("https://www.facebook.com");
                var request = new RestRequest("api/graphql", Method.Post);

                // Set up request headers
                request.AddHeader("authority", "www.facebook.com");
                request.AddHeader("accept", "*/*");
                request.AddHeader("accept-language", "en-US,en;q=0.9");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddHeader("origin", "https://www.facebook.com");
                request.AddHeader("referer", "https://www.facebook.com/accountquality/100088675546057/247746905242/?asset_view_type=asset");
                request.AddHeader("sec-ch-prefers-color-scheme", "light");
                request.AddHeader("sec-ch-ua", "\"Not_A Brand\";v=\"99\", \"Google Chrome\";v=\"109\", \"Chromium\";v=\"109\"");
                request.AddHeader("sec-ch-ua-mobile", "?0");
                request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                request.AddHeader("sec-fetch-dest", "empty");
                request.AddHeader("sec-fetch-mode", "cors");
                request.AddHeader("sec-fetch-site", "same-origin");
                request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36");
                request.AddHeader("viewport-width", "1349");
                request.AddHeader("x-fb-friendly-name", "useALEBanhammerAppealMutation");
                request.AddHeader("x-fb-lsd", "O59clWSQAHa2KcbZRkurck");
                request.AddHeader("Cookie", cookie);

                // Set up request parameters
                request.AddParameter("av", id);
                request.AddParameter("session_id", "6b124788a85ea3de");
                request.AddParameter("__user", id);
                request.AddParameter("__a", "1");
                request.AddParameter("__dyn", "7xeUmxa2C5rgydwCwRyU8EKnFG5UkBwCwgE98nCG6UmCyEgwjojyUW3eF8iBxa7GzU4q5Eiz8WdwJzUi-4UgwgUgwqoqyoyazoO4o461mCwOxa7FEhwywCxq2u3K6UGq1eKFpobQUTwJHiG9zQE8RVodoKUryonwu8sxep3bwExm3G4UhwXxW9wgolUScyobo4a5U2dz8twAKmu7EK3i2a3Fe6rwiolDwFwBgak48W2e2i3mbxOfxa2y5E5WUru6ogyHwyx6i8wxK2efK2W1dx-q4VEhG7o2swQzUS2W2K4E6-bxu3ydCgqw-z8c8-5aDBwEBwKG13y85i4oKqbDyoOEbVEHyU8U3yDwbm1bwzwqp87q5rwCwmo4S");
                request.AddParameter("__csr", "");
                request.AddParameter("__req", "k");
                request.AddParameter("__hs", "19391.BP:DEFAULT.2.0.0.0.0");
                request.AddParameter("dpr", "1");
                request.AddParameter("__ccg", "EXCELLENT");
                request.AddParameter("__rev", "1006907533");
                request.AddParameter("__s", "yug5vd:rkwrf1:8dxu3z");
                request.AddParameter("__hsi", "7195846812736417894");
                request.AddParameter("__comet_req", "0");
                request.AddParameter("fb_dtsg", fb_dtsg);
                request.AddParameter("jazoest", jazoest);
                request.AddParameter("lsd", "O59clWSQAHa2KcbZRkurck");
                request.AddParameter("__aaid", "5887772874637720");
                request.AddParameter("__spin_r", "1006907533");
                request.AddParameter("__spin_b", "trunk");
                request.AddParameter("__spin_t", "1675413645");
                request.AddParameter("fb_api_caller_class", "RelayModern");
                request.AddParameter("fb_api_req_friendly_name", "useALEBanhammerAppealMutation");
                request.AddParameter("variables", "{\"input\":{\"client_mutation_id\":\"1\",\"actor_id\":\"" + id + "\",\"ad_account_id\":\"" + uid + "\",\"ids_issue_ent_id\":\"" + ids_issue_ent_id + "\",\"appeal_comment\":\"I'm not sure which policy was violated.\",\"callsite\":\"ACCOUNT_QUALITY\"}}");
                request.AddParameter("server_timestamps", "true");
                request.AddParameter("doc_id", "5329872773703511");

                // Send the request
                RestResponse response = client.Execute(request);
                return response.Content;
                }
                catch (Exception ex)
                {
                    return new { Error = ex };
                }
            
        }
       
        public async Task<object> Khang_buoc_2(string id, string fb_dtsg, string jazoest, string uid, string cookie)
        {
           
                try
                {

                    var client = new RestClient("https://www.facebook.com");
                    var request = new RestRequest("api/graphql", Method.Post);
                    request.AddHeader("authority", "www.facebook.com");
                    request.AddHeader("accept", "*/*");
                    request.AddHeader("accept-language", "en-US,en;q=0.9");
                    request.AddHeader("content-type", "application/x-www-form-urlencoded");
                    request.AddHeader("origin", "https://www.facebook.com");
                    request.AddHeader("referer", "https://www.facebook.com/accountquality/100088675546057/247746905242/?asset_view_type=asset");
                    request.AddHeader("sec-ch-prefers-color-scheme", "light");
                    request.AddHeader("sec-ch-ua", "\"Not_A Brand\";v=\"99\", \"Google Chrome\";v=\"109\", \"Chromium\";v=\"109\"");
                    request.AddHeader("sec-ch-ua-mobile", "?0");
                    request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                    request.AddHeader("sec-fetch-dest", "empty");
                    request.AddHeader("sec-fetch-mode", "cors");
                    request.AddHeader("sec-fetch-site", "same-origin");
                    request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36");
                    request.AddHeader("viewport-width", "1349");
                    request.AddHeader("x-fb-friendly-name", "AccountQualityHubAssetViewV2Query");
                    request.AddHeader("x-fb-lsd", "O59clWSQAHa2KcbZRkurck");
                    request.AddHeader("Cookie", cookie);
                    // Set up request parameters
                    request.AddParameter("av", id);
                    request.AddParameter("session_id", "6b124788a85ea3de");
                    request.AddParameter("__user", id);
                    request.AddParameter("__a", "1");
                    request.AddParameter("__dyn", "7xeUmxa2C5rgydwCwRyU8EKnFG5UkBwCwgE98nCG6UmCyEgwjojyUW3eF8iBxa7GzU4q5Eiz8WdwJzUi-4UgwgUgwqoqyoyazoO4o461mCwOxa7FEhwywCxq2u3K6UGq1eKFpobQUTwJHiG9zQE8RVodoKUryonwu8sxep3bwExm3G4UhwXxW9wgolUScyobo4a5U2dz8twAKmu7EK3i2a3Fe6rwiolDwFwBgak48W2e2i3mbxOfxa2y5E5WUru6ogyHwyx6i8wxK2efK2W1dx-q4VEhG7o2swQzUS2W2K4E6-bxu3ydCgqw-z8c8-5aDBwEBwKG13y85i4oKqbDyoOEbVEHyU8U3yDwbm1bwzwqp87q5rwCwmo4S");
                    request.AddParameter("__csr", "");
                    request.AddParameter("__req", "l");
                    request.AddParameter("__hs", "19391.BP:DEFAULT.2.0.0.0.0");
                    request.AddParameter("dpr", "1");
                    request.AddParameter("__ccg", "EXCELLENT");
                    request.AddParameter("__rev", "1006907533");
                    request.AddParameter("__s", "yug5vd:rkwrf1:8dxu3z");
                    request.AddParameter("__hsi", "7195846812736417894");
                    request.AddParameter("__comet_req", "0");
                    request.AddParameter("fb_dtsg", fb_dtsg);
                    request.AddParameter("jazoest", jazoest);
                    request.AddParameter("lsd", "O59clWSQAHa2KcbZRkurck");
                    request.AddParameter("__aaid", "5887772874637720");
                    request.AddParameter("__spin_r", "1006907533");
                    request.AddParameter("__spin_b", "trunk");
                    request.AddParameter("__spin_t", "1675413645");
                    request.AddParameter("fb_api_caller_class", "RelayModern");
                    request.AddParameter("fb_api_req_friendly_name", "AccountQualityHubAssetViewV2Query");
                    request.AddParameter("variables", "{\"assetOwnerId\":\"" + id + "\",\"assetId\":\"" + uid + "\"}");
                    request.AddParameter("server_timestamps", "true");
                    request.AddParameter("doc_id", "6206358346052492");

                    // Send the request
                    RestResponse response = client.Execute(request);
                    return response.Content;
                }
                catch (Exception ex)
                {
                    return new { Error = ex };
                }
            
        }
        
        public async Task<object> Khang_buoc_2bm(string id, string fb_dtsg, string jazoest, string uid, string cookie)
        {
            
                try
                {
                var client = new RestClient("https://www.facebook.com");
                var request = new RestRequest("api/graphql", Method.Post);
                request.AddHeader("authority", "www.facebook.com");
                request.AddHeader("accept", "*/*");
                request.AddHeader("accept-language", "en-US,en;q=0.9");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddHeader("origin", "https://www.facebook.com");
                request.AddHeader("referer", "https://www.facebook.com/accountquality/100088675546057/247746905242/?asset_view_type=asset");
                request.AddHeader("sec-ch-prefers-color-scheme", "light");
                request.AddHeader("sec-ch-ua", "\"Not_A Brand\";v=\"99\", \"Google Chrome\";v=\"109\", \"Chromium\";v=\"109\"");
                request.AddHeader("sec-ch-ua-mobile", "?0");
                request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                request.AddHeader("sec-fetch-dest", "empty");
                request.AddHeader("sec-fetch-mode", "cors");
                request.AddHeader("sec-fetch-site", "same-origin");
                request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36");
                request.AddHeader("viewport-width", "1349");
                request.AddHeader("x-fb-friendly-name", "AccountQualityHubAssetOwnerViewV2Query");
                request.AddHeader("x-fb-lsd", "O59clWSQAHa2KcbZRkurck");
                request.AddHeader("Cookie", cookie);
                // Set up request parameters
                request.AddParameter("av", id);
                request.AddParameter("session_id", "6b124788a85ea3de");
                request.AddParameter("__user", id);
                request.AddParameter("__a", "1");
                request.AddParameter("__dyn", "7xeUmxa2C5rgydwCwRyU8EKnFG5UkBwCwgE98nCG6UmCyEgwjojyUW3eF8iBxa7GzU4q5Eiz8WdwJzUi-4UgwgUgwqoqyoyazoO4o461mCwOxa7FEhwywCxq2u3K6UGq1eKFpobQUTwJHiG9zQE8RVodoKUryonwu8sxep3bwExm3G4UhwXxW9wgolUScyobo4a5U2dz8twAKmu7EK3i2a3Fe6rwiolDwFwBgak48W2e2i3mbxOfxa2y5E5WUru6ogyHwyx6i8wxK2efK2W1dx-q4VEhG7o2swQzUS2W2K4E6-bxu3ydCgqw-z8c8-5aDBwEBwKG13y85i4oKqbDyoOEbVEHyU8U3yDwbm1bwzwqp87q5rwCwmo4S");
                request.AddParameter("__csr", "");
                request.AddParameter("__req", "l");
                request.AddParameter("__hs", "19391.BP:DEFAULT.2.0.0.0.0");
                request.AddParameter("dpr", "1");
                request.AddParameter("__ccg", "EXCELLENT");
                request.AddParameter("__rev", "1006907533");
                request.AddParameter("__s", "yug5vd:rkwrf1:8dxu3z");
                request.AddParameter("__hsi", "7195846812736417894");
                request.AddParameter("__comet_req", "0");
                request.AddParameter("fb_dtsg", fb_dtsg);
                request.AddParameter("jazoest", jazoest);
                request.AddParameter("lsd", "O59clWSQAHa2KcbZRkurck");
                request.AddParameter("__aaid", "5887772874637720");
                request.AddParameter("__spin_r", "1006907533");
                request.AddParameter("__spin_b", "trunk");
                request.AddParameter("__spin_t", "1675413645");
                request.AddParameter("fb_api_caller_class", "RelayModern");
                request.AddParameter("fb_api_req_friendly_name", "AccountQualityHubAssetOwnerViewV2Query");
                request.AddParameter("variables", "{\"assetOwnerId\":\"" + uid + "\"}");
                request.AddParameter("server_timestamps", "true");
                request.AddParameter("doc_id", "5816699831746699");
                RestResponse response = client.Execute(request);
                return response.Content;
                }
                catch (Exception ex)
                {
                    return new { Error = ex };
                }
            
        }
    }
}
