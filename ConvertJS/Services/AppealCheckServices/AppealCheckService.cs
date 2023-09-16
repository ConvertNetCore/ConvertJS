using ConvertJS.DTOs;
using ConvertJS.DTOs.ResponseDTO;
using ConvertJS.Infras.Enums;
using ConvertJS.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace ConvertJS.Services.AppealCheckServices
{
    public interface IAppealCheckService
    {
        Task<object> Khang_buoc_1(string id, string ids_issue_ent_id, string fb_dtsg, string jazoest, string uid, string cookie);
        Task<object> Khang_buoc_1_pass2(string id, string ids_issue_ent_id, string fb_dtsg, string jazoest, string uid, string cookie);
        Task<object> Khang_buoc_2(string id, string fb_dtsg, string jazoest, string uid, string cookie);
        Task<object> Khang_buoc_2bm(string id, string fb_dtsg, string jazoest, string uid, string cookie);

        //Todo
        Task<List<AppealCheckAccountDTO>> GetAccountDie(string accessTokenInfo, string cookie);
        //Todo
        Task<List<AppealCheckBMDTO>> GetBMDie(string accessTokenInfo, string cookie);
        //Todo
        Task<List<AppealCheckPageDTO>> GetPage(string accessTokenInfo, string cookie, string id, string fb_dtsg, string jazoest);
        //Task<QualityResponse> check_quality_all(string id, string fb_dtsg, string jazoest, string uid, string cookie);

    }
    public class AppealCheckService : IAppealCheckService
    {
        private readonly ILogger<AppealCheckService> _logger;
        public AppealCheckService(ILogger<AppealCheckService> logger)
        {
            _logger = logger;
        }
        public async Task<List<AppealCheckAccountDTO>> GetAccountDie(string accessTokenInfo, string cookie)
        {
            try
            {
                var baseUrl = "https://graph.facebook.com/v14.0";
                var options = new RestClientOptions(baseUrl)
                {
                    MaxTimeout = -1,
                    UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36",
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://graph.facebook.com/v14.0/me/adaccounts?limit=50&fields=users,name,account_status,account_id,owner_business,created_time,next_bill_date,currency,adtrust_dsl,timezone_name,timezone_offset_hours_utc,business_country_code,disable_reason,adspaymentcycle{threshold_amount},balance,is_prepay_account,owner,all_payment_methods{pm_credit_card{display_string,exp_month,exp_year,is_verified},payment_method_direct_debits{address,can_verify,display_string,is_awaiting,is_pending,status},payment_method_paypal{email_address},payment_method_tokens{current_balance,original_balance,time_expire,type}},total_prepay_balance,insights.date_preset(maximum){spend}&access_token=" +
                  accessTokenInfo +//.Access_token +
                  "&summary=1&locale=en_US", Method.Get);
                request.AddHeader("authority", "graph.facebook.com");
                request.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", "en-US,en;q=0.9");
                request.AddHeader("cache-control", "max-age=0");
                request.AddHeader("cookie", cookie);
                request.AddHeader("sec-ch-ua", "\"Google Chrome\";v=\"107\", \"Chromium\";v=\"107\", \"Not=A?Brand\";v=\"24\"");
                request.AddHeader("sec-ch-ua-mobile", "?0");
                request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                request.AddHeader("sec-fetch-dest", "document");
                request.AddHeader("sec-fetch-mode", "navigate");
                request.AddHeader("sec-fetch-site", "none");
                request.AddHeader("sec-fetch-user", "?1");
                request.AddHeader("upgrade-insecure-requests", "1");
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);

                //Convert to Model View
                var adAccountResponse = JsonConvert.DeserializeObject<AdAccountResponseDTO>(response.Content.ToString());
                List<AppealCheckAccountDTO> AllUserDTOs = new List<AppealCheckAccountDTO>();
                foreach (var userDTO in adAccountResponse.data)
                {
                    if (userDTO.account_status == 2)
                    {
                        var adsUser = new AppealCheckAccountDTO
                        {
                            Status = AccountStatus.Disable,
                            AccountName = userDTO.name,
                            ID = userDTO.account_id
                        };

                        AllUserDTOs.Add(adsUser);
                    }
                }
                return AllUserDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new List<AppealCheckAccountDTO>();
            }
        }

        public async Task<List<AppealCheckBMDTO>> GetBMDie(string accessTokenInfo, string cookie)
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
                var request = new RestRequest("https://graph.facebook.com/v14.0/me/businesses?fields=owned_pixels,name,id,verification_status,business_users,allow_page_management_in_www,sharing_eligibility_status,created_time,permitted_roles,client_ad_accounts.summary(1).limit(5000),owned_ad_accounts.summary(1).limit(5000)&limit=50&access_token=" +
                  accessTokenInfo +
                  "&locale=en_US", Method.Get);
                request.AddHeader("authority", " graph.facebook.com");
                request.AddHeader("accept", " text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", " en-US,en;q=0.9");
                request.AddHeader("cache-control", " max-age=0");
                request.AddHeader("sec-ch-ua", " \"Not_A Brand\";v=\"99\", \"Google Chrome\";v=\"109\", \"Chromium\";v=\"109\"");
                request.AddHeader("sec-ch-ua-mobile", " ?0");
                request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                request.AddHeader("sec-fetch-dest", " document");
                request.AddHeader("sec-fetch-mode", " navigate");
                request.AddHeader("sec-fetch-site", " none");
                request.AddHeader("sec-fetch-user", " ?1");
                request.AddHeader("upgrade-insecure-requests", " 1");
                request.AddHeader("Cookie", cookie);
                RestResponse response = await client.ExecuteAsync(request);

                //Convert to Model View
                var bmAccountResponse = JsonConvert.DeserializeObject<BusinessResponseDTO>(response.Content.ToString());
                List<AppealCheckBMDTO> AllUserDTOs = new List<AppealCheckBMDTO>();
                foreach (var userDTO in bmAccountResponse.data)
                {
                    if (userDTO.allow_page_management_in_www == true)
                    {
                        var bmUser = new AppealCheckBMDTO
                        {
                            Status = BMStatus.Die,
                            BMName = userDTO.name,
                            Id = userDTO.id
                        };

                        AllUserDTOs.Add(bmUser);
                    }
                }
                return AllUserDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new List<AppealCheckBMDTO>();
            }

        }

        public async Task<List<AppealCheckPageDTO>> GetPage(string accessTokenInfo, string cookie, string id, string fb_dtsg, string jazoest)
        {
            try
            {
                var baseUrl = "https://graph.facebook.com/v14.0";
                var options = new RestClientOptions(baseUrl)
                {
                    MaxTimeout = -1,
                    UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36",
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://graph.facebook.com/v14.0/me/accounts?limit=5000&access_token=" +
                                              accessTokenInfo +
                                              "&summary=1&locale=en_US", Method.Get);
                request.AddHeader("authority", " graph.facebook.com");
                request.AddHeader("accept", " text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", " en-US,en;q=0.9");
                request.AddHeader("cache-control", " max-age=0");
                request.AddHeader("cookie", cookie);
                request.AddHeader("sec-ch-ua", " \"Google Chrome\";v=\"107\", \"Chromium\";v=\"107\", \"Not=A?Brand\";v=\"24\"");
                request.AddHeader("sec-ch-ua-mobile", " ?0");
                request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                request.AddHeader("sec-fetch-dest", " document");
                request.AddHeader("sec-fetch-mode", " navigate");
                request.AddHeader("sec-fetch-site", " none");
                request.AddHeader("sec-fetch-user", " ?1");
                request.AddHeader("upgrade-insecure-requests", " 1");
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);

                //Convert here
                
                var bmAccountResponse = JsonConvert.DeserializeObject<AdAccountResponseDTO>(response.Content.ToString());
                List<AppealCheckPageDTO> AllUserDTOs = new List<AppealCheckPageDTO>();
                foreach (var userDTO in bmAccountResponse.data)
                {
                    QualityResponse dataQ = await check_quality_all(id, fb_dtsg, jazoest, userDTO.id, cookie);
                    PageStatus stt = dataQ.data.node.advertising_restriction_info.is_restricted ? PageStatus.Reject : PageStatus.Live;
                    var bmUser = new AppealCheckPageDTO
                        {
                            Status = stt,
                            PageName = userDTO.name,
                            Id = userDTO.id
                        };

                        AllUserDTOs.Add(bmUser);
                    
                }
                return AllUserDTOs;
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new List<AppealCheckPageDTO>();
            }
        }
        public async Task<QualityResponse> check_quality_all(string id, string fb_dtsg, string jazoest, string uid, string cookie)
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
                request.AddHeader("sec-ch-prefers-color-scheme", "light");
                request.AddHeader("sec-ch-ua", "\"Not_A Brand\";v=\"99\", \"Google Chrome\";v=\"109\", \"Chromium\";v=\"109\"");
                request.AddHeader("sec-ch-ua-mobile", "?0");
                request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                request.AddHeader("sec-fetch-dest", "empty");
                request.AddHeader("sec-fetch-mode", "cors");
                request.AddHeader("sec-fetch-site", "same-origin");
                request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36");
                request.AddHeader("viewport-width", "1349");
                request.AddHeader("x-fb-friendly-name", "AccountQualityUserPageWrapper_UserPageQuery");
                request.AddHeader("x-fb-lsd", "iVb4tcqWYh0Lr-l6WxQtab");
                request.AddHeader("Cookie", cookie);

                // Set up request parameters
                request.AddParameter("av", id);
                request.AddParameter("session_id", "4c19b2acf8bed07a");
                request.AddParameter("__user", id);
                request.AddParameter("__a", "1");
                request.AddParameter("__csr", "");
                request.AddParameter("__req", "8");
                request.AddParameter("__hs", "19391.BP:DEFAULT.2.0.0.0.0");
                request.AddParameter("dpr", "1");
                request.AddParameter("__ccg", "EXCELLENT");
                request.AddParameter("__rev", "1006907533");
                request.AddParameter("__s", "zxfkhx:jq3gvo:mr9z0p");
                request.AddParameter("__hsi", "7195855447466244657");
                request.AddParameter("__comet_req", "0");
                request.AddParameter("fb_dtsg", fb_dtsg);
                request.AddParameter("jazoest", jazoest);
                request.AddParameter("lsd", "iVb4tcqWYh0Lr-l6WxQtab");
                request.AddParameter("__aaid", "5887772874637720");
                request.AddParameter("__spin_r", "1006907533");
                request.AddParameter("__spin_b", "trunk");
                request.AddParameter("__spin_t", "1675415654");
                request.AddParameter("fb_api_caller_class", "RelayModern");
                request.AddParameter("fb_api_req_friendly_name", "AccountQualityUserPageWrapper_UserPageQuery");
                request.AddParameter("variables", "{\"id\":\"" + uid + "\",\"startTime\":null}");
                request.AddParameter("server_timestamps", "true");
                request.AddParameter("doc_id", "5473935232689253");

                // Send the request
                RestResponse response = client.Execute(request);
                var bmAccountResponse = JsonConvert.DeserializeObject<QualityResponse>(response.Content.ToString());
                return bmAccountResponse;
            }
            catch (Exception ex)
            {
                return new QualityResponse();
            }

        }

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
                request.AddParameter("jazoest", jazoest);
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

        public async Task<object> Khang_buoc_1_pass2(string id, string ids_issue_ent_id, string fb_dtsg, string jazoest, string uid, string cookie)
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
