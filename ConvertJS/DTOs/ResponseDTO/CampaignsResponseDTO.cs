namespace ConvertJS.DTOs.ResponseDTO
{
    public class CampaignsResponseDTO
    {
        public Datacam[] data { get; set; }
        public Paging paging { get; set; }
        public string __fb_trace_id__ { get; set; }
        public string __www_request_id__ { get; set; }
    }


    public class Datacam
    {
        public string daily_budget { get; set; }
        public string effective_status { get; set; }
        public string bid_strategy { get; set; }
        public string name { get; set; }
        public DateTime created_time { get; set; }
        public Insightss insights { get; set; }
        public string id { get; set; }
        public string lifetime_budget { get; set; }
    }

    public class Insightss
    {
        public Datums[] data { get; set; }
        public Pagings paging { get; set; }
    }

    public class Pagings
    {
        public Cursorss cursors { get; set; }
    }

    public class Cursorss
    {
        public string before { get; set; }
        public string after { get; set; }
    }

    public class Datums
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

    public class Action_Values
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Action
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Cost_Per_Action_Type
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Cost_Per_Outbound_Click
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Cost_Per_Thruplay
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Cost_Per_Unique_Action_Type
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Cost_Per_Unique_Outbound_Click
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Mobile_App_Purchase_Roas
    {
        public string value { get; set; }
    }

    public class Outbound_Clicks
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Outbound_Clicks_Ctr
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Purchase_Roas
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Video_30_Sec_Watched_Actions
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Video_Avg_Time_Watched_Actions
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Video_P100_Watched_Actions
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Video_P25_Watched_Actions
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Video_P50_Watched_Actions
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Video_P75_Watched_Actions
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Video_P95_Watched_Actions
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Video_Play_Actions
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Website_Ctr
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

    public class Website_Purchase_Roas
    {
        public string action_type { get; set; }
        public string value { get; set; }
    }

}
