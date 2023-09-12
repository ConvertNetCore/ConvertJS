namespace ConvertJS.DTOs.ResponseDTO
{

    public class AdsResponseDTO
    {
        public Datumset[] data { get; set; }
        public Paging paging { get; set; }
        public string __fb_trace_id__ { get; set; }
        public string __www_request_id__ { get; set; }
    }

    

    public class Datumset
    {
        public string effective_status { get; set; }
        public string name { get; set; }
        public DateTime created_time { get; set; }
        public Insightsss insights { get; set; }
        public string id { get; set; }
    }

    public class Insightsss
    {
        public Datum1s[] data { get; set; }
        public Paging1s paging { get; set; }
    }

    public class Paging1s
    {
        public Cursors1s cursors { get; set; }
    }

    public class Cursors1s
    {
        public string before { get; set; }
        public string after { get; set; }
    }

    public class Datum1s
    {
        public string account_id { get; set; }
        public string account_currency { get; set; }
        public string account_name { get; set; }
        public Action_Values[] action_values { get; set; }
        public Action[] actions { get; set; }
        public string buying_type { get; set; }
        public string campaign_id { get; set; }
        public string clicks { get; set; }
        public Cost_Per_Action_Type[] cost_per_action_type { get; set; }
        public string cost_per_inline_link_click { get; set; }
        public string cost_per_inline_post_engagement { get; set; }
        public Cost_Per_Outbound_Click[] cost_per_outbound_click { get; set; }
        public Cost_Per_Thruplay[] cost_per_thruplay { get; set; }
        public Cost_Per_Unique_Action_Type[] cost_per_unique_action_type { get; set; }
        public string cost_per_unique_click { get; set; }
        public string cost_per_unique_inline_link_click { get; set; }
        public Cost_Per_Unique_Outbound_Click[] cost_per_unique_outbound_click { get; set; }
        public string cpc { get; set; }
        public string cpm { get; set; }
        public string cpp { get; set; }
        public string ctr { get; set; }
        public string date_start { get; set; }
        public string date_stop { get; set; }
        public string engagement_rate_ranking { get; set; }
        public string frequency { get; set; }
        public string impressions { get; set; }
        public string inline_link_click_ctr { get; set; }
        public string inline_link_clicks { get; set; }
        public string inline_post_engagement { get; set; }
        public Mobile_App_Purchase_Roas[] mobile_app_purchase_roas { get; set; }
        public string objective { get; set; }
        public string optimization_goal { get; set; }
        public Outbound_Clicks[] outbound_clicks { get; set; }
        public Outbound_Clicks_Ctr[] outbound_clicks_ctr { get; set; }
        public Purchase_Roas[] purchase_roas { get; set; }
        public string quality_ranking { get; set; }
        public string reach { get; set; }
        public string social_spend { get; set; }
        public string spend { get; set; }
        public Video_30_Sec_Watched_Actions[] video_30_sec_watched_actions { get; set; }
        public Video_Avg_Time_Watched_Actions[] video_avg_time_watched_actions { get; set; }
        public Video_P100_Watched_Actions[] video_p100_watched_actions { get; set; }
        public Video_P25_Watched_Actions[] video_p25_watched_actions { get; set; }
        public Video_P50_Watched_Actions[] video_p50_watched_actions { get; set; }
        public Video_P75_Watched_Actions[] video_p75_watched_actions { get; set; }
        public Video_P95_Watched_Actions[] video_p95_watched_actions { get; set; }
        public Video_Play_Actions[] video_play_actions { get; set; }
       
        public Website_Ctr[] website_ctr { get; set; }
        public Website_Purchase_Roas[] website_purchase_roas { get; set; }
    }

    

}
