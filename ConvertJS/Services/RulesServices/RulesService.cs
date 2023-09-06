using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace ConvertJS.Services.RulesServices
{
    public interface IRulesService
    {
        public Task<object> check_live_token(string accessTokenInfo, string cookie);
        public Task<object> Information(string cookie);
        public Task<object> get_all_camp_from_id_tkqc(string accessTokenInfo, string idqc, string cookie);
        public Task<object> get_all_adset_from_camp(string accessTokenInfo, string id_camp, string cookie);
        public Task<object> get_all_ads_from_adset(string accessTokenInfo, string id_adset, string cookie);
        
    }
    public class RulesService
    {
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
        public async Task<object> get_all_camp_from_id_tkqc(string accessTokenInfo, string idqc, string cookie)
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
                    RestResponse response = await client.ExecuteAsync(request);
                    return response.Content;
                }
                catch (Exception ex)
                {
                    return new { Error = ex };
                }
            
        }
        public async Task<object> get_all_adset_from_camp(string accessTokenInfo, string id_camp, string cookie)
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
                    return response.Content;
                }
                catch (Exception ex)
                {
                    return new { Error = ex };
                }
            
        }
        
        public async Task<object> get_all_ads_from_adset(string accessTokenInfo, string id_adset, string cookie)
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
