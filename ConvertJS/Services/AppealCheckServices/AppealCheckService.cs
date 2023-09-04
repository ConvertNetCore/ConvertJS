using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace ConvertJS.Services.AppealCheckServices
{
    public class AppealCheckService
    {
        public async Task<object> Khang_buoc_1(string id, string ids_issue_ent_id, string fb_dtsg, string jazoest, string uid, string cookie)
        {
            
                try
                {
                    var baseUrl = "https://www.facebook.com/api/graphql/";
                    var options = new RestClientOptions(baseUrl)
                    {
                        MaxTimeout = -1,
                        UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36",
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest("https://www.facebook.com/api/graphql/", Method.Post);
                    request.AddHeader("authority", " www.facebook.com");
                    request.AddHeader("accept", " */*");
                    request.AddHeader("accept-language", " en-US,en;q=0.9");
                    request.AddHeader("content-type", " application/x-www-form-urlencoded");
                    request.AddHeader("origin", " https://www.facebook.com");
                    request.AddHeader("referer", " https://www.facebook.com/accountquality/100088675546057/247746905242/?asset_view_type=asset");
                    request.AddHeader("sec-ch-prefers-color-scheme", " light");
                    request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                    request.AddHeader("sec-ch-ua-mobile", " ?0");
                    request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                    request.AddHeader("sec-fetch-dest", " empty");
                    request.AddHeader("sec-fetch-mode", " cors");
                    request.AddHeader("sec-fetch-site", " same-origin");
                    request.AddHeader("viewport-width", " 1349");
                    request.AddHeader("x-fb-friendly-name", " useALEBanhammerAppealMutation");
                    request.AddHeader("x-fb-lsd", " O59clWSQAHa2KcbZRkurck");
                    request.AddHeader("Cookie", cookie);
                    request.AddHeader("", "");
                    var body = @"{
                    " + "\n" +
                                        @"    ""av"": ""${id}"",
                    " + "\n" +
                                        @"    ""session_id"": ""6b124788a85ea3de"",
                    " + "\n" +
                                        @"    ""__user"": ""${id}"",
                    " + "\n" +
                                        @"    ""__a"": ""1"",
                    " + "\n" +
                                        @"    ""__dyn"": ""7xeUmxa2C5rgydwCwRyU8EKnFG5UkBwCwgE98nCG6UmCyEgwjojyUW3eF8iBxa7GzU4q5Eiz8WdwJzUi-4UgwgUgwqoqyoyazoO4o461mCwOxa7FEhwywCxq2u3K6UGq1eKFpobQUTwJHiG9zQE8RVodoKUryonwu8sxep3bwExm3G4UhwXxW9wgolUScyobo4a5U2dz8twAKmu7EK3i2a3Fe6rwiolDwFwBgak48W2e2i3mbxOfxa2y5E5WUru6ogyHwyx6i8wxK2efK2W1dx-q4VEhG7o2swQzUS2W2K4E6-bxu3ydCgqw-z8c8-5aDBwEBwKG13y85i4oKqbDyoOEbVEHyU8U3yDwbm1bwzwqp87q5rwCwmo4S"",
                    " + "\n" +
                                        @"    ""__csr"": """",
                    " + "\n" +
                                        @"    ""__req"": ""k"",
                    " + "\n" +
                                        @"    ""__hs"": ""19391.BP:DEFAULT.2.0.0.0.0"",
                    " + "\n" +
                                        @"    ""dpr"": ""1"",
                    " + "\n" +
                                        @"    ""__ccg"": ""EXCELLENT"",
                    " + "\n" +
                                        @"    ""__rev"": ""1006907533"",
                    " + "\n" +
                                        @"    ""__s"": ""yug5vd:rkwrf1:8dxu3z"",
                    " + "\n" +
                                        @"    ""__hsi"": ""7195846812736417894"",
                    " + "\n" +
                                        @"    ""__comet_req"": ""0"",
                    " + "\n" +
                                        @"    ""fb_dtsg"": ""${fb_dtsg}"",
                    " + "\n" +
                                        @"    ""jazoest"": ""${jazoest}"",
                    " + "\n" +
                                        @"    ""lsd"": ""O59clWSQAHa2KcbZRkurck"",
                    " + "\n" +
                                        @"    ""__aaid"": ""5887772874637720"",
                    " + "\n" +
                                        @"    ""__spin_r"": ""1006907533"",
                    " + "\n" +
                                        @"    ""__spin_b"": ""trunk"",
                    " + "\n" +
                                        @"    ""__spin_t"": ""1675413645"",
                    " + "\n" +
                                        @"    ""fb_api_caller_class"": ""RelayModern"",
                    " + "\n" +
                                        @"    ""fb_api_req_friendly_name"": ""useALEBanhammerAppealMutation"",
                    " + "\n" +
                                        @"    ""variables"": {
                    " + "\n" +
                                        @"        ""input"": {
                    " + "\n" +
                                        @"            ""client_mutation_id"": ""1"",
                    " + "\n" +
                                        @"            ""actor_id"": ""${id}"",
                    " + "\n" +
                                        @"            ""entity_id"": ""${uid}"",
                    " + "\n" +
                                        @"            ""ids_issue_ent_id"": ""${ids_issue_ent_id}"",
                    " + "\n" +
                                        @"            ""appeal_comment"": ""I'm not sure which policy was violated."",
                    " + "\n" +
                                        @"            ""callsite"": ""ACCOUNT_QUALITY""
                    " + "\n" +
                                        @"        }
                    " + "\n" +
                                        @"    },
                    " + "\n" +
                                        @"    ""server_timestamps"": ""true"",
                    " + "\n" +
                                        @"    ""doc_id"": ""5329872773703511""
                    " + "\n" +
                    @"}";
                    request.AddParameter(" application/x-www-form-urlencoded", body, ParameterType.RequestBody);
                    RestResponse response = await client.ExecuteAsync(request);
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
                    var baseUrl = "https://www.facebook.com/api/graphql/";
                    var options = new RestClientOptions(baseUrl)
                    {
                        MaxTimeout = -1,
                        UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36",
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest("https://www.facebook.com/api/graphql/", Method.Post);
                    request.AddHeader("authority", " www.facebook.com");
                    request.AddHeader("accept", " */*");
                    request.AddHeader("accept-language", " en-US,en;q=0.9");
                    request.AddHeader("content-type", " application/x-www-form-urlencoded");
                    request.AddHeader("origin", " https://www.facebook.com");
                    request.AddHeader("referer", " https://www.facebook.com/accountquality/100088675546057/247746905242/?asset_view_type=asset");
                    request.AddHeader("sec-ch-prefers-color-scheme", " light");
                    request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                    request.AddHeader("sec-ch-ua-mobile", " ?0");
                    request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                    request.AddHeader("sec-fetch-dest", " empty");
                    request.AddHeader("sec-fetch-mode", " cors");
                    request.AddHeader("sec-fetch-site", " same-origin");
                    request.AddHeader("viewport-width", " 1349");
                    request.AddHeader("x-fb-friendly-name", " useALEBanhammerAppealMutation");
                    request.AddHeader("x-fb-lsd", " O59clWSQAHa2KcbZRkurck");
                    request.AddHeader("Cookie", cookie);
                    request.AddHeader("", "");
                    var body = @"{
                    " + "\n" +
                                        @"    ""av"": ""${id}"",
                    " + "\n" +
                                        @"    ""session_id"": ""6b124788a85ea3de"",
                    " + "\n" +
                                        @"    ""__user"": ""${id}"",
                    " + "\n" +
                                        @"    ""__a"": ""1"",
                    " + "\n" +
                                        @"    ""__dyn"": ""7xeUmxa2C5rgydwCwRyU8EKnFG5UkBwCwgE98nCG6UmCyEgwjojyUW3eF8iBxa7GzU4q5Eiz8WdwJzUi-4UgwgUgwqoqyoyazoO4o461mCwOxa7FEhwywCxq2u3K6UGq1eKFpobQUTwJHiG9zQE8RVodoKUryonwu8sxep3bwExm3G4UhwXxW9wgolUScyobo4a5U2dz8twAKmu7EK3i2a3Fe6rwiolDwFwBgak48W2e2i3mbxOfxa2y5E5WUru6ogyHwyx6i8wxK2efK2W1dx-q4VEhG7o2swQzUS2W2K4E6-bxu3ydCgqw-z8c8-5aDBwEBwKG13y85i4oKqbDyoOEbVEHyU8U3yDwbm1bwzwqp87q5rwCwmo4S"",
                    " + "\n" +
                                        @"    ""__csr"": """",
                    " + "\n" +
                                        @"    ""__req"": ""k"",
                    " + "\n" +
                                        @"    ""__hs"": ""19391.BP:DEFAULT.2.0.0.0.0"",
                    " + "\n" +
                                        @"    ""dpr"": ""1"",
                    " + "\n" +
                                        @"    ""__ccg"": ""EXCELLENT"",
                    " + "\n" +
                                        @"    ""__rev"": ""1006907533"",
                    " + "\n" +
                                        @"    ""__s"": ""yug5vd:rkwrf1:8dxu3z"",
                    " + "\n" +
                                        @"    ""__hsi"": ""7195846812736417894"",
                    " + "\n" +
                                        @"    ""__comet_req"": ""0"",
                    " + "\n" +
                                        @"    ""fb_dtsg"": ""${fb_dtsg}"",
                    " + "\n" +
                                        @"    ""jazoest"": ""${jazoest}"",
                    " + "\n" +
                                        @"    ""lsd"": ""O59clWSQAHa2KcbZRkurck"",
                    " + "\n" +
                                        @"    ""__aaid"": ""5887772874637720"",
                    " + "\n" +
                                        @"    ""__spin_r"": ""1006907533"",
                    " + "\n" +
                                        @"    ""__spin_b"": ""trunk"",
                    " + "\n" +
                                        @"    ""__spin_t"": ""1675413645"",
                    " + "\n" +
                                        @"    ""fb_api_caller_class"": ""RelayModern"",
                    " + "\n" +
                                        @"    ""fb_api_req_friendly_name"": ""useALEBanhammerAppealMutation"",
                    " + "\n" +
                                        @"    ""variables"": {
                    " + "\n" +
                                        @"        ""input"": {
                    " + "\n" +
                                        @"            ""client_mutation_id"": ""1"",
                    " + "\n" +
                                        @"            ""actor_id"": ""${id}"",
                    " + "\n" +
                                        @"            ""ad_account_id"": ""${uid}"",
                    " + "\n" +
                                        @"            ""ids_issue_ent_id"": ""${ids_issue_ent_id}"",
                    " + "\n" +
                                        @"            ""appeal_comment"": ""I'm not sure which policy was violated."",
                    " + "\n" +
                                        @"            ""callsite"": ""ACCOUNT_QUALITY""
                    " + "\n" +
                                        @"        }
                    " + "\n" +
                                        @"    },
                    " + "\n" +
                                        @"    ""server_timestamps"": ""true"",
                    " + "\n" +
                                        @"    ""doc_id"": ""5329872773703511""
                    " + "\n" +
                    @"}";
                    request.AddParameter(" application/x-www-form-urlencoded", body, ParameterType.RequestBody);
                    RestResponse response = await client.ExecuteAsync(request);
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
                    var baseUrl = "https://graph.facebook.com/v14.0";
                    var options = new RestClientOptions(baseUrl)
                    {
                        MaxTimeout = -1,
                        UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36",
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest("https://www.facebook.com/api/graphql/", Method.Post);
                    request.AddHeader("authority", " www.facebook.com");
                    request.AddHeader("accept", " */*");
                    request.AddHeader("accept-language", " en-US,en;q=0.9");
                    request.AddHeader("content-type", " application/x-www-form-urlencoded");
                    request.AddHeader("origin", " https://www.facebook.com");
                    request.AddHeader("referer", " https://www.facebook.com/accountquality/100088675546057/247746905242/?asset_view_type=asset");
                    request.AddHeader("sec-ch-prefers-color-scheme", " light");
                    request.AddHeader("sec-ch-ua", " \"Not_A Brand\";v=\"99\", \"Google Chrome\";v=\"109\", \"Chromium\";v=\"109\"");
                    request.AddHeader("sec-ch-ua-mobile", " ?0");
                    request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                    request.AddHeader("sec-fetch-dest", " empty");
                    request.AddHeader("sec-fetch-mode", " cors");
                    request.AddHeader("sec-fetch-site", " same-origin");
                    request.AddHeader("viewport-width", " 1349");
                    request.AddHeader("x-fb-friendly-name", " AccountQualityHubAssetViewV2Query");
                    request.AddHeader("x-fb-lsd", " O59clWSQAHa2KcbZRkurck");
                    request.AddHeader("Cookie", cookie);
                    var body = @"{
                    " + "\n" +
                                        @"    ""av"": ""${id}"",
                    " + "\n" +
                                        @"    ""session_id"": ""6b124788a85ea3de"",
                    " + "\n" +
                                        @"    ""__user"": ""${id}"",
                    " + "\n" +
                                        @"    ""__a"": ""1"",
                    " + "\n" +
                                        @"    ""__dyn"": ""7xeUmxa2C5rgydwCwRyU8EKnFG5UkBwCwgE98nCG6UmCyEgwjojyUW3eF8iBxa7GzU4q5Eiz8WdwJzUi-4UgwgUgwqoqyoyazoO4o461mCwOxa7FEhwywCxq2u3K6UGq1eKFpobQUTwJHiG9zQE8RVodoKUryonwu8sxep3bwExm3G4UhwXxW9wgolUScyobo4a5U2dz8twAKmu7EK3i2a3Fe6rwiolDwFwBgak48W2e2i3mbxOfxa2y5E5WUru6ogyHwyx6i8wxK2efK2W1dx-q4VEhG7o2swQzUS2W2K4E6-bxu3ydCgqw-z8c8-5aDBwEBwKG13y85i4oKqbDyoOEbVEHyU8U3yDwbm1bwzwqp87q5rwCwmo4S"",
                    " + "\n" +
                                        @"    ""__csr"": """",
                    " + "\n" +
                                        @"    ""__req"": ""l"",
                    " + "\n" +
                                        @"    ""__hs"": ""19391.BP:DEFAULT.2.0.0.0.0"",
                    " + "\n" +
                                        @"    ""dpr"": ""1"",
                    " + "\n" +
                                        @"    ""__ccg"": ""EXCELLENT"",
                    " + "\n" +
                                        @"    ""__rev"": ""1006907533"",
                    " + "\n" +
                                        @"    ""__s"": ""yug5vd:rkwrf1:8dxu3z"",
                    " + "\n" +
                                        @"    ""__hsi"": ""7195846812736417894"",
                    " + "\n" +
                                        @"    ""__comet_req"": ""0"",
                    " + "\n" +
                                        @"    ""fb_dtsg"": ""${fb_dtsg}"",
                    " + "\n" +
                                        @"    ""jazoest"": ""${jazoest}"",
                    " + "\n" +
                                        @"    ""lsd"": ""O59clWSQAHa2KcbZRkurck"",
                    " + "\n" +
                                        @"    ""__aaid"": ""5887772874637720"",
                    " + "\n" +
                                        @"    ""__spin_r"": ""1006907533"",
                    " + "\n" +
                                        @"    ""__spin_b"": ""trunk"",
                    " + "\n" +
                                        @"    ""__spin_t"": ""1675413645"",
                    " + "\n" +
                                        @"    ""fb_api_caller_class"": ""RelayModern"",
                    " + "\n" +
                                        @"    ""fb_api_req_friendly_name"": ""AccountQualityHubAssetViewV2Query"",
                    " + "\n" +
                                        @"    ""variables"": {
                    " + "\n" +
                                        @"        ""assetOwnerId"": ""${id}"",
                    " + "\n" +
                                        @"        ""assetId"": ""${uid}""
                    " + "\n" +
                                        @"    },
                    " + "\n" +
                                        @"    ""server_timestamps"": ""true"",
                    " + "\n" +
                                        @"    ""doc_id"": ""6206358346052492""
                    " + "\n" +
                    @"}";
                    request.AddParameter(" application/x-www-form-urlencoded", body, ParameterType.RequestBody);
                    RestResponse response = await client.ExecuteAsync(request);
                    return response.Content;
                }
                catch (Exception ex)
                {
                    return new { Error = ex };
                }
            
        }
        
        public async Task<object> Khang_buoc_2bm( string fb_dtsg, string jazoest, string uid, string cookie)
        {
            
                try
                {
                    var baseUrl = "https://graph.facebook.com/v14.0";
                    var options = new RestClientOptions(baseUrl)
                    {
                        MaxTimeout = -1,
                        UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36",
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest("https://www.facebook.com/api/graphql/", Method.Post);
                    request.AddHeader("authority", " www.facebook.com");
                    request.AddHeader("accept", " */*");
                    request.AddHeader("accept-language", " en-US,en;q=0.9");
                    request.AddHeader("content-type", " application/x-www-form-urlencoded");
                    request.AddHeader("origin", " https://www.facebook.com");
                    request.AddHeader("referer", " https://www.facebook.com/accountquality/100088675546057/247746905242/?asset_view_type=asset");
                    request.AddHeader("sec-ch-prefers-color-scheme", " light");
                    request.AddHeader("sec-ch-ua", " \"Not_A Brand\";v=\"99\", \"Google Chrome\";v=\"109\", \"Chromium\";v=\"109\"");
                    request.AddHeader("sec-ch-ua-mobile", " ?0");
                    request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                    request.AddHeader("sec-fetch-dest", " empty");
                    request.AddHeader("sec-fetch-mode", " cors");
                    request.AddHeader("sec-fetch-site", " same-origin");
                    request.AddHeader("viewport-width", " 1349");
                    request.AddHeader("x-fb-friendly-name", " AccountQualityHubAssetViewV2Query");
                    request.AddHeader("x-fb-lsd", " O59clWSQAHa2KcbZRkurck");
                    request.AddHeader("Cookie", "c_user=100071096111263; fr=0qLp1kLkdVgoM1pp7.AWXdZnkKxXiShGsedYsSM8N-jB0.Bk9C00.wx.AAA.0.0.Bk9C00.AWWvDmwY11I; xs=48%3A6VcDtFFcntJ8yA%3A2%3A1693328646%3A-1%3A8037%3A%3AAcWIEF7arQXXXkiWzyCLqsCfo5kvG93PeBuGfy8divc");
                    var body = @"{
                    " + "\n" +
                                        @"    ""av"": ""${uid}"",
                    " + "\n" +
                                        @"    ""session_id"": ""6b124788a85ea3de"",
                    " + "\n" +
                                        @"    ""__user"": ""${uid}"",
                    " + "\n" +
                                        @"    ""__a"": ""1"",
                    " + "\n" +
                                        @"    ""__dyn"": ""7xeUmxa2C5rgydwCwRyU8EKnFG5UkBwCwgE98nCG6UmCyEgwjojyUW3eF8iBxa7GzU4q5Eiz8WdwJzUi-4UgwgUgwqoqyoyazoO4o461mCwOxa7FEhwywCxq2u3K6UGq1eKFpobQUTwJHiG9zQE8RVodoKUryonwu8sxep3bwExm3G4UhwXxW9wgolUScyobo4a5U2dz8twAKmu7EK3i2a3Fe6rwiolDwFwBgak48W2e2i3mbxOfxa2y5E5WUru6ogyHwyx6i8wxK2efK2W1dx-q4VEhG7o2swQzUS2W2K4E6-bxu3ydCgqw-z8c8-5aDBwEBwKG13y85i4oKqbDyoOEbVEHyU8U3yDwbm1bwzwqp87q5rwCwmo4S"",
                    " + "\n" +
                                        @"    ""__csr"": """",
                    " + "\n" +
                                        @"    ""__req"": ""l"",
                    " + "\n" +
                                        @"    ""__hs"": ""19391.BP:DEFAULT.2.0.0.0.0"",
                    " + "\n" +
                                        @"    ""dpr"": ""1"",
                    " + "\n" +
                                        @"    ""__ccg"": ""EXCELLENT"",
                    " + "\n" +
                                        @"    ""__rev"": ""1006907533"",
                    " + "\n" +
                                        @"    ""__s"": ""yug5vd:rkwrf1:8dxu3z"",
                    " + "\n" +
                                        @"    ""__hsi"": ""7195846812736417894"",
                    " + "\n" +
                                        @"    ""__comet_req"": ""0"",
                    " + "\n" +
                                        @"    ""fb_dtsg"": ""${fb_dtsg}"",
                    " + "\n" +
                                        @"    ""jazoest"": ""${jazoest}"",
                    " + "\n" +
                                        @"    ""lsd"": ""O59clWSQAHa2KcbZRkurck"",
                    " + "\n" +
                                        @"    ""__aaid"": ""5887772874637720"",
                    " + "\n" +
                                        @"    ""__spin_r"": ""1006907533"",
                    " + "\n" +
                                        @"    ""__spin_b"": ""trunk"",
                    " + "\n" +
                                        @"    ""__spin_t"": ""1675413645"",
                    " + "\n" +
                                        @"    ""fb_api_caller_class"": ""RelayModern"",
                    " + "\n" +
                                        @"    ""fb_api_req_friendly_name"": ""AccountQualityHubAssetOwnerViewV2Query"",
                    " + "\n" +
                                        @"    ""variables"": {
                    " + "\n" +
                                        @"        ""assetOwnerId"": ""${uid}""
                    " + "\n" +
                                        @"    },
                    " + "\n" +
                                        @"    ""server_timestamps"": ""true"",
                    " + "\n" +
                                        @"    ""doc_id"": ""5816699831746699""
                    " + "\n" +
                    @"}";
                    request.AddParameter(" application/x-www-form-urlencoded", body, ParameterType.RequestBody);
                    RestResponse response = await client.ExecuteAsync(request);
                    return response.Content;
                }
                catch (Exception ex)
                {
                    return new { Error = ex };
                }
            
        }
    }
}
