using ConvertJS.DTOs;
using ConvertJS.DTOs.ResponseDTO;
using ConvertJS.Infras.Enums;
using ConvertJS.Services.AppealCheckServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Net.WebSockets;
using System.Xml.Linq;

namespace ConvertJS.Services.RulesServices
{
    public interface IRulesService
    {
        public Task<object> check_live_token(string accessTokenInfo, string cookie);
        public Task<object> Information(string cookie);
        public Task<List<CampaignsDTO>> get_all_camp_from_id_tkqc(string accessTokenInfo, string idqc, string cookie);
        public Task<List<AdSetDTO>> get_all_adset_from_camp(string accessTokenInfo, string id_camp, string cookie);
        public Task<List<AdsDTO>> get_all_ads_from_adset(string accessTokenInfo, string id_adset, string cookie);

        //Todo
        public Task<List<AdsAccountDTO>> GetAllAccount(string accessTokenInfo, string cookie);
        public Task<List<GetRuleDTO>> GetRule(string accessTokenInfo, string cookie,string id_tkqc);

    }
    public class RulesService : IRulesService
    {
        private readonly ILogger<RulesService> _logger;
        public RulesService(ILogger<RulesService> logger)
        {
            _logger = logger;
        }
        public async Task<object> check_live_token(string accessTokenInfo, string cookie)
        {

            try
            {
                var baseUrl = "https://graph.facebook.com/me";
                var options = new RestClientOptions(baseUrl)
                {
                    MaxTimeout = -1,
                    UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36",
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://graph.facebook.com/me?access_token=" +
                accessTokenInfo +
                "&locale=en_US", Method.Get);
                request.AddHeader("authority", " graph.facebook.com");
                request.AddHeader("accept", " text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", " en-US,en;q=0.9");
                request.AddHeader("cache-control", " max-age=0");
                request.AddHeader("sec-ch-ua", " \"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
                request.AddHeader("sec-ch-ua-mobile", " ?0");
                request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                request.AddHeader("sec-fetch-dest", " document");
                request.AddHeader("sec-fetch-mode", " navigate");
                request.AddHeader("sec-fetch-site", " none");
                request.AddHeader("sec-fetch-user", " ?1");
                request.AddHeader("upgrade-insecure-requests", " 1");
                request.AddHeader("Cookie", cookie);
                RestResponse response = await client.ExecuteAsync(request);
                return response.Content;
            }
            catch (Exception ex)
            {
                return new { Error = ex };
            }

        }

        public async Task<object> Information(string cookie)
        {
            try
            {
                var baseUrl = "https://business.facebook.com";
                var options = new RestClientOptions(baseUrl)
                {
                    MaxTimeout = -1,
                    UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36",
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://business.facebook.com/ads/manager/account_settings/information", Method.Get);
                request.AddHeader("authority", " graph.facebook.com");
                request.AddHeader("accept", " text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", " en-US,en;q=0.9");
                request.AddHeader("cache-control", " max-age=0");
                request.AddHeader("sec-ch-ua", " \"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
                request.AddHeader("sec-ch-ua-mobile", " ?0");
                request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                request.AddHeader("sec-fetch-dest", " document");
                request.AddHeader("sec-fetch-mode", " navigate");
                request.AddHeader("sec-fetch-site", " none");
                request.AddHeader("sec-fetch-user", " ?1");
                request.AddHeader("upgrade-insecure-requests", " 1");
                request.AddHeader("Cookie", cookie);
                RestResponse response = await client.ExecuteAsync(request);
                return response.Content;
            }
            catch (Exception ex)
            {
                return new { Error = ex };
            }
        }
        public async Task<List<CampaignsDTO>> get_all_camp_from_id_tkqc(string accessTokenInfo, string idqc, string cookie)
        {

            try
            {
                var baseUrl = "https://graph.facebook.com/v14.0";
                var options = new RestClientOptions(baseUrl)
                {
                    MaxTimeout = -1,
                    UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36",
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://graph.facebook.com/v14.0/" +
                idqc +
                "/campaigns?date_preset=maximum&field=amount,results,daily_budget&limit=1&access_token=" +
                accessTokenInfo +
                "&__cppo=1&_reqName=path%3A%2Fact_29107808%3Ffields%3Dreach%2Cname%2Cowner_business%2Cresult%2Ccreated_time%2Cinsights.date_preset(maximum)%7Bspend%7D%2Ccurrency%2Cadtrust_dsl%2Caccount_status%2Cnext_bill_date%2Cadspaymentcycle%7Bthreshold_amount%7D%2Cis_prepay_account%2Ctimezone_offset_hours_utc%2Ctimezone_name%2Cowner%2Cfunding_source_details%2Cusers%7Brole%7D%2Cbalance%26locale%3Den_US&_sessionID=466bc0eb855f4dfd&fields=lifetime_budget,daily_budget,effective_status,bid_strategy,name,owner_business,created_time,insights.date_preset(maximum){account_id, account_currency, account_name, action_values, actions, buying_type, campaign_id, clicks, conversion_values, conversions, converted_product_quantity, converted_product_value, cost_per_action_type, cost_per_conversion, cost_per_estimated_ad_recallers, cost_per_inline_link_click, cost_per_inline_post_engagement, cost_per_outbound_click, cost_per_thruplay, cost_per_unique_action_type, cost_per_unique_click, cost_per_unique_inline_link_click, cost_per_unique_outbound_click, cpc, cpm, cpp, ctr, date_start, date_stop, dda_results, engagement_rate_ranking, estimated_ad_recall_rate, estimated_ad_recallers, frequency, full_view_impressions, full_view_reach, impressions, inline_link_click_ctr, inline_link_clicks, inline_post_engagement, instant_experience_clicks_to_open, instant_experience_clicks_to_start, instant_experience_outbound_clicks, mobile_app_purchase_roas, objective, optimization_goal, outbound_clicks, outbound_clicks_ctr, place_page_name, purchase_roas, qualifying_question_qualify_answer_rate, quality_ranking, reach, social_spend, spend, video_30_sec_watched_actions, video_avg_time_watched_actions, video_p100_watched_actions, video_p25_watched_actions, video_p50_watched_actions,video_p75_watched_actions, video_p95_watched_actions, video_play_actions, video_play_curve_actions, website_ctr, website_purchase_roas}&include_headers=false&locale=en_GB&method=get&pretty=0&suppress_http_code=1&xref=f1d3c29412c80bc&limit=5000", Method.Get);
                request.AddHeader("authority", " graph.facebook.com");
                request.AddHeader("accept", " text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", " en-US,en;q=0.9");
                request.AddHeader("cache-control", " max-age=0");
                request.AddHeader("sec-ch-ua", " \"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
                request.AddHeader("sec-ch-ua-mobile", " ?0");
                request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                request.AddHeader("sec-fetch-dest", " document");
                request.AddHeader("sec-fetch-mode", " navigate");
                request.AddHeader("sec-fetch-site", " none");
                request.AddHeader("sec-fetch-user", " ?1");
                request.AddHeader("upgrade-insecure-requests", " 1");
                request.AddHeader("Cookie", cookie);
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);
                //Convert here
                var bmAccountResponse = JsonConvert.DeserializeObject<CampaignsResponseDTO>(response.Content.ToString());
                List<CampaignsDTO> AllUserDTOs = new List<CampaignsDTO>();
                foreach (var userDTO in bmAccountResponse.data)
                {

                    var bmUser = new CampaignsDTO
                    {
                        Id = userDTO.id,
                        Name = userDTO.name,
                        Status = userDTO.effective_status == "ACTIVE" ? CampaignType.Active : CampaignType.Disable,
                        Delivery = userDTO.effective_status,
                        BidStrategy = userDTO.bid_strategy,
                        Budget = userDTO.daily_budget,
                        LastSignificantEdut = DateTime.Now,
                        Result = userDTO.insights.data[0].objective,
                        Reach = userDTO.insights.data[0].reach,
                        Frequency = userDTO.insights.data[0].frequency,
                        Impressions = userDTO.insights.data[0].impressions,
                        AmountSpent = userDTO.insights.data[0].spend,
                        Currency = userDTO.insights.data[0].account_currency,
                        Clicks = userDTO.insights.data[0].clicks,
                        Value = userDTO.insights.data[0].cpc

                    };

                    AllUserDTOs.Add(bmUser);

                }
                return AllUserDTOs;
            }
            catch (Exception ex)
            {
                return new List<CampaignsDTO>(); 
            }

        }
        public async Task<List<AdSetDTO>> get_all_adset_from_camp(string accessTokenInfo, string id_camp, string cookie)
        {
            try
            {
                var baseUrl = "https://graph.facebook.com/v14.0";
                var options = new RestClientOptions(baseUrl)
                {
                    MaxTimeout = -1,
                    UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36",
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://graph.facebook.com/v14.0/" +
                id_camp +
                "/adsets?date_preset=maximum&field=amount,results,daily_budget&limit=1&access_token=" +
                accessTokenInfo +
                "&__cppo=1&_reqName=path%3A%2Fact_29107808%3Ffields%3Dreach%2Cname%2Cowner_business%2Cresult%2Ccreated_time%2Cinsights.date_preset(maximum)%7Bspend%7D%2Ccurrency%2Cadtrust_dsl%2Caccount_status%2Cnext_bill_date%2Cadspaymentcycle%7Bthreshold_amount%7D%2Cis_prepay_account%2Ctimezone_offset_hours_utc%2Ctimezone_name%2Cowner%2Cfunding_source_details%2Cusers%7Brole%7D%2Cbalance%26locale%3Den_US&_sessionID=466bc0eb855f4dfd&fields=lifetime_budget,daily_budget,effective_status,bid_strategy,name,owner_business,created_time,insights.date_preset(maximum){account_id, account_currency, account_name, action_values, actions, buying_type, campaign_id, clicks, conversion_values, conversions, converted_product_quantity, converted_product_value, cost_per_action_type, cost_per_conversion, cost_per_estimated_ad_recallers, cost_per_inline_link_click, cost_per_inline_post_engagement, cost_per_outbound_click, cost_per_thruplay, cost_per_unique_action_type, cost_per_unique_click, cost_per_unique_inline_link_click, cost_per_unique_outbound_click, cpc, cpm, cpp, ctr, date_start, date_stop, dda_results, engagement_rate_ranking, estimated_ad_recall_rate, estimated_ad_recallers, frequency, full_view_impressions, full_view_reach, impressions, inline_link_click_ctr, inline_link_clicks, inline_post_engagement, instant_experience_clicks_to_open, instant_experience_clicks_to_start, instant_experience_outbound_clicks, mobile_app_purchase_roas, objective, optimization_goal, outbound_clicks, outbound_clicks_ctr, place_page_name, purchase_roas, qualifying_question_qualify_answer_rate, quality_ranking, reach, social_spend, spend, video_30_sec_watched_actions, video_avg_time_watched_actions, video_p100_watched_actions, video_p25_watched_actions, video_p50_watched_actions,video_p75_watched_actions, video_p95_watched_actions, video_play_actions, video_play_curve_actions, website_ctr, website_purchase_roas}&include_headers=false&locale=en_GB&method=get&pretty=0&suppress_http_code=1&xref=f1d3c29412c80bc&limit=5000", Method.Get);
                request.AddHeader("authority", " graph.facebook.com");
                request.AddHeader("accept", " text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", " en-US,en;q=0.9");
                request.AddHeader("cache-control", " max-age=0");
                request.AddHeader("sec-ch-ua", " \"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
                request.AddHeader("sec-ch-ua-mobile", " ?0");
                request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                request.AddHeader("sec-fetch-dest", " document");
                request.AddHeader("sec-fetch-mode", " navigate");
                request.AddHeader("sec-fetch-site", " none");
                request.AddHeader("sec-fetch-user", " ?1");
                request.AddHeader("upgrade-insecure-requests", " 1");
                request.AddHeader("Cookie", cookie);
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);

                //Convert here
                var bmAccountResponse = JsonConvert.DeserializeObject<AdsResponseDTO>(response.Content.ToString());
                List<AdSetDTO> AllUserDTOs = new List<AdSetDTO>();
                foreach (var userDTO in bmAccountResponse.data)
                {

                    var bmUser = new AdSetDTO
                    {
                        Id = userDTO.id,
                        Name = userDTO.name,
                        Status = userDTO.effective_status == "ACTIVE" ? AdSetStatus.Active : AdSetStatus.Disable,
                        Delivery = userDTO.effective_status,
                        BidStrategy = "Using campaign bid strategy",
                        Budget = "Using campaign bid strategy",
                        LastSignificantEdut = DateTime.Now,
                        Result = userDTO.insights.data[0].objective,
                        Reach = userDTO.insights.data[0].reach,
                        Frequency = userDTO.insights.data[0].frequency,
                        Impressions = userDTO.insights.data[0].impressions,
                        AmountSpent = userDTO.insights.data[0].spend,
                        Currency = userDTO.insights.data[0].account_currency,
                        Clicks = userDTO.insights.data[0].clicks,
                        Value = userDTO.insights.data[0].cpc
                    };

                    AllUserDTOs.Add(bmUser);

                }
                return AllUserDTOs;
            }
            catch (Exception ex)
            {
                return new List<AdSetDTO>();
            }

        }

        public async Task<List<AdsDTO>> get_all_ads_from_adset(string accessTokenInfo, string id_adset, string cookie)
        {

            try
            {
                var baseUrl = "https://graph.facebook.com/v14.0";
                var options = new RestClientOptions(baseUrl)
                {
                    MaxTimeout = -1,
                    UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36",
                };
                var client = new RestClient(options);
                var request = new RestRequest("https://graph.facebook.com/v14.0/" +
                id_adset +
                "/ads?date_preset=maximum&field=amount,results,daily_budget&limit=1&access_token=" +
                accessTokenInfo +
                "&__cppo=1&_reqName=path%3A%2Fact_29107808%3Ffields%3Dreach%2Cname%2Cowner_business%2Cresult%2Ccreated_time%2Cinsights.date_preset(maximum)%7Bspend%7D%2Ccurrency%2Cadtrust_dsl%2Caccount_status%2Cnext_bill_date%2Cadspaymentcycle%7Bthreshold_amount%7D%2Cis_prepay_account%2Ctimezone_offset_hours_utc%2Ctimezone_name%2Cowner%2Cfunding_source_details%2Cusers%7Brole%7D%2Cbalance%26locale%3Den_US&_sessionID=466bc0eb855f4dfd&fields=lifetime_budget,daily_budget,effective_status,bid_strategy,name,owner_business,created_time,insights.date_preset(maximum){account_id, account_currency, account_name, action_values, actions, buying_type, campaign_id, clicks, conversion_values, conversions, converted_product_quantity, converted_product_value, cost_per_action_type, cost_per_conversion, cost_per_estimated_ad_recallers, cost_per_inline_link_click, cost_per_inline_post_engagement, cost_per_outbound_click, cost_per_thruplay, cost_per_unique_action_type, cost_per_unique_click, cost_per_unique_inline_link_click, cost_per_unique_outbound_click, cpc, cpm, cpp, ctr, date_start, date_stop, dda_results, engagement_rate_ranking, estimated_ad_recall_rate, estimated_ad_recallers, frequency, full_view_impressions, full_view_reach, impressions, inline_link_click_ctr, inline_link_clicks, inline_post_engagement, instant_experience_clicks_to_open, instant_experience_clicks_to_start, instant_experience_outbound_clicks, mobile_app_purchase_roas, objective, optimization_goal, outbound_clicks, outbound_clicks_ctr, place_page_name, purchase_roas, qualifying_question_qualify_answer_rate, quality_ranking, reach, social_spend, spend, video_30_sec_watched_actions, video_avg_time_watched_actions, video_p100_watched_actions, video_p25_watched_actions, video_p50_watched_actions,video_p75_watched_actions, video_p95_watched_actions, video_play_actions, video_play_curve_actions, website_ctr, website_purchase_roas}&include_headers=false&locale=en_GB&method=get&pretty=0&suppress_http_code=1&xref=f1d3c29412c80bc&limit=5000", Method.Get);
                request.AddHeader("authority", " graph.facebook.com");
                request.AddHeader("accept", " text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                request.AddHeader("accept-language", " en-US,en;q=0.9");
                request.AddHeader("cache-control", " max-age=0");
                request.AddHeader("sec-ch-ua", " \"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
                request.AddHeader("sec-ch-ua-mobile", " ?0");
                request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
                request.AddHeader("sec-fetch-dest", " document");
                request.AddHeader("sec-fetch-mode", " navigate");
                request.AddHeader("sec-fetch-site", " none");
                request.AddHeader("sec-fetch-user", " ?1");
                request.AddHeader("upgrade-insecure-requests", " 1");
                request.AddHeader("Cookie", cookie);
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);

                //Convert here
                var bmAccountResponse = JsonConvert.DeserializeObject<AdsResponseDTO>(response.Content.ToString());
                List<AdsDTO> AllUserDTOs = new List<AdsDTO>();
                foreach (var userDTO in bmAccountResponse.data)
                {

                    var bmUser = new AdsDTO
                    {
                        Id = userDTO.id,
                        Name = userDTO.name,
                        Status = userDTO.effective_status == "ACTIVE" ? AdsStatus.Active : AdsStatus.Disable,
                        Delivery = userDTO.effective_status,
                        BidStrategy = "Using campaign bid strategy",
                        Budget = "Using campaign bid strategy",
                        LastSignificantEdut = DateTime.Now,
                        Result = userDTO.insights.data[0].objective,
                        Reach = userDTO.insights.data[0].reach,
                        Frequency = userDTO.insights.data[0].frequency,
                        Impressions = userDTO.insights.data[0].impressions,
                        AmountSpent = userDTO.insights.data[0].spend,
                        Currency = userDTO.insights.data[0].account_currency,
                        Clicks = userDTO.insights.data[0].clicks,
                        Value = userDTO.insights.data[0].cpc
                    };

                    AllUserDTOs.Add(bmUser);

                }
                return AllUserDTOs;
            }
            catch (Exception ex)
            {
                return new List<AdsDTO>();
            }

        }

        public async Task<List<AdsAccountDTO>> GetAllAccount(string accessTokenInfo, string cookie)
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
                List<AdsAccountDTO> AllUserDTOs = new List<AdsAccountDTO>();
                foreach (var userDTO in adAccountResponse.data)
                {
                    var adsUser = new AdsAccountDTO
                    {
                        Status = AccountStatus.Active,//chưa đúng
                        AccountName = userDTO.name,
                        Id = userDTO.account_id,
                        Balance = Convert.ToDouble(userDTO.balance), // chưa đúng
                        Type = "Normal Personnal", // chưa đúng
                        ThreashHold = 0,
                        NumberUser = 0,
                        AmountSpent = 0,
                        Currency = userDTO.currency,
                        Limit = userDTO.adtrust_dsl,
                        IDBM = userDTO.id,
                        Users = new List<UserDTO>()
                    };
                    if (userDTO.adspaymentcycle != null)
                        adsUser.ThreashHold = userDTO.adspaymentcycle.data.Sum(e => e.threshold_amount);

                    if (userDTO.users != null)
                        adsUser.NumberUser = userDTO.users.data.Count();

                    if (userDTO.insights != null)
                        adsUser.AmountSpent = userDTO.insights.data.Sum(e => e.spend);
                    if (userDTO.users != null)
                        adsUser.Users = userDTO.users.data.Select(e => new UserDTO
                        {
                            Name = e.name,
                            UserId = e.id,
                            Role = Role.Admin // chưa đúng
                        }).ToList();
                    AllUserDTOs.Add(adsUser);
                }
                return AllUserDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new List<AdsAccountDTO>();
            }
        }

        public async Task<List<GetRuleDTO>> GetRule(string accessTokenInfo, string cookie, string id_tkqc)
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
                var request = new RestRequest("https://adsmanager-graph.facebook.com/v15.0/act_" + id_tkqc + "/adrules_library?access_token=" + accessTokenInfo + "&__cppo=1&__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&__interactionsMetadata=%5B%5D&_reqName=adaccount%2Fadrules_library&_reqSrc=AdsRuleListDataManager&_sessionID=85b63ea04270095&date_format=U&fields=%5B%22account_id%22%2C%22created_time%22%2C%22entity_type%22%2C%22evaluation_spec%22%2C%22execution_spec%22%2C%22id%22%2C%22is_for_account%22%2C%22name%22%2C%22schedule_spec%22%2C%22status%22%2C%22updated_time%22%2C%22created_by%7Bid%2C%20name%7D%22%5D&include_headers=false&limit=250&locale=en_GB&method=get&pretty=0&suppress_http_code=1&xref=f1ed4b64eabbfd8&", Method.Get);
                request.AddHeader("authority", "adsmanager-graph.facebook.com");
                request.AddHeader("accept", "*/*");
                request.AddHeader("accept-language", "en-US,en;q=0.9");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddHeader("origin", "https://adsmanager.facebook.com");
                request.AddHeader("referer", "https://adsmanager.facebook.com/");
                request.AddHeader("cookie", cookie);
                request.AddHeader("sec-ch-ua", "\"Google Chrome\";v=\"113\", \"Chromium\";v=\"113\", \"Not=A?Brand\";v=\"24\"");
                request.AddHeader("sec-ch-ua-mobile", "?0");
                request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                request.AddHeader("sec-fetch-dest", "document");
                request.AddHeader("sec-fetch-mode", "cors");
                request.AddHeader("sec-fetch-site", "same-site");
                request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36");
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);

                //Convert to Model View
                var adAccountResponse = JsonConvert.DeserializeObject<GetRuleResponseDTO>(response.Content.ToString());
                List<GetRuleDTO> AllUserDTOs = new List<GetRuleDTO>();
                foreach (var userDTO in adAccountResponse.data)
                {
                    var adsUser = new GetRuleDTO
                    {
                        ID = userDTO.id,
                        RuleName = userDTO.name,
                        Status = userDTO.status,
                        AcctionCondition = "",
                         RuleResults = "",
                         WhenRuleRun = "",
                        CreatedBy = ""
                     };
                    
                    AllUserDTOs.Add(adsUser);
                }
                return AllUserDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new List<GetRuleDTO>();
            }
        }
    }
}
