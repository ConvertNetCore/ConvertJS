namespace ConvertJS.DTOs.ResponseDTO
{
 
    public class QualityResponse
    {
        public Data data { get; set; }
        public Extensions extensions { get; set; }
    }

    public class Data
    {
        public Node node { get; set; }
    }

    public class Node
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public bool is_viewer_admin { get; set; }
        public Profile_Photo profile_photo { get; set; }
        public object owner_business { get; set; }
        public Ads_Conversion_Experiences_Info ads_conversion_experiences_info { get; set; }
        public Account_Banhammer_Info account_banhammer_info { get; set; }
        public Advertising_Restriction_Info advertising_restriction_info { get; set; }
    }

    public class Profile_Photo
    {
        public string src { get; set; }
        public string id { get; set; }
    }

    public class Ads_Conversion_Experiences_Info
    {
        public bool is_penalized { get; set; }
        public bool is_in_probation { get; set; }
        public bool is_banned { get; set; }
        public int penalty_start_time { get; set; }
        public int probation_start_time { get; set; }
        public int banning_start_time { get; set; }
    }

    public class Account_Banhammer_Info
    {
        public object appeal_timestamp { get; set; }
    }

    public class Advertising_Restriction_Info
    {
        public bool is_restricted { get; set; }
        public object ids_issue_ent_id { get; set; }
        public string status { get; set; }
        public object restriction_date { get; set; }
        public object restriction_type { get; set; }
    }

    public class Extensions
    {
        public bool is_final { get; set; }
    }

}
