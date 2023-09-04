namespace ConvertJS.DTOs.ResponseDTO
{
    public class BusinessResponseDTO
    {
        public BMdata[] data { get; set; }
        public Paging paging { get; set; }
        public string __fb_trace_id__ { get; set; }
        public string __www_request_id__ { get; set; }
    }
    public class BMdata
    {
        public string name { get; set; }
        public string id { get; set; }
        public string verification_status { get; set; }
        public BusinessUsser business_users { get; set; }
        public bool allow_page_management_in_www { get; set; }
        public string sharing_eligibility_status { get; set; }
        public DateTime created_time { get; set; }
        public ClientAdAccount client_ad_accounts { get; set; }
        public OwnedAdAccount owned_ad_accounts { get; set; }
        public string[] permitted_roles { get; set; }
    }
    public class BusinessUsser
    {
        public DataBM[] data { get; set; }
        public Paging paging { get; set; }
    }
    public class DataBM
    {
        public string id { get; set; }
        public string name { get; set; }
        public Business business { get; set; }

        public int expiry_time { get; set; }
        public string role { get; set; }
    }
    public class Business
    {
        public string id { get; set; } 
        public string name { get; set; }
    }
    public class ClientAdAccount
    {
        public AdAccount[] data { get; set; }
        public Paging paging { get; set; }
        public SummaryBM summary { get; set; }
    }
    public class AdAccount
    {
        public string id { get; set; }
        public string account_id { get; set; }
    }
    public class SummaryBM
    {
        public int total_count { get; set; }
        public int filtered_total_count { get; set; }
    }
    public class OwnedAdAccount
    {
        public AdAccount[] data { get; set; }
        public Paging paging { get; set; }
        public SummaryBM summary { get; set; }
    }
    
}
