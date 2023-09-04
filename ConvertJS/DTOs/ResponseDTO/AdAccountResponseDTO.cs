namespace ConvertJS.DTOs.ResponseDTO
{
    public class AdAccountResponseDTO
    {
        public Datum[] data { get; set; }
        public Paging paging { get; set; }
        public Summary summary { get; set; }
        public string __fb_trace_id__ { get; set; }
        public string __www_request_id__ { get; set; }
    }

    public class Paging
    {
        public Cursors cursors { get; set; }
    }

    public class Cursors
    {
        public string before { get; set; }
        public string after { get; set; }
    }

    public class Summary
    {
        public int total_count { get; set; }
    }

    public class Datum
    {
        public Users users { get; set; }
        public string name { get; set; }
        public int account_status { get; set; }
        public string account_id { get; set; }
        public DateTime created_time { get; set; }
        public DateTime next_bill_date { get; set; }
        public string currency { get; set; }
        public float adtrust_dsl { get; set; }
        public string timezone_name { get; set; }
        public int timezone_offset_hours_utc { get; set; }
        public string business_country_code { get; set; }
        public int disable_reason { get; set; }
        public Adspaymentcycle adspaymentcycle { get; set; }
        public string balance { get; set; }
        public bool is_prepay_account { get; set; }
        public string owner { get; set; }
        public Total_Prepay_Balance total_prepay_balance { get; set; }
        public Insights insights { get; set; }
        public string id { get; set; }
    }

    public class Users
    {
        public Datum1[] data { get; set; }
    }

    public class Datum1
    {
        public string name { get; set; }
        public int[] permissions { get; set; }
        public int role { get; set; }
        public string[] tasks { get; set; }
        public string id { get; set; }
    }

    public class Adspaymentcycle
    {
        public Datum2[] data { get; set; }
        public Paging1 paging { get; set; }
    }

    public class Paging1
    {
        public Cursors1 cursors { get; set; }
    }

    public class Cursors1
    {
        public string before { get; set; }
        public string after { get; set; }
    }

    public class Datum2
    {
        public int threshold_amount { get; set; }
    }

    public class Total_Prepay_Balance
    {
        public string amount { get; set; }
        public string amount_in_hundredths { get; set; }
        public string currency { get; set; }
        public string offsetted_amount { get; set; }
    }

    public class Insights
    {
        public Datum3[] data { get; set; }
        public Paging2 paging { get; set; }
    }

    public class Paging2
    {
        public Cursors2 cursors { get; set; }
    }

    public class Cursors2
    {
        public string before { get; set; }
        public string after { get; set; }
    }

    public class Datum3
    {
        public double spend { get; set; }
        public string date_start { get; set; }
        public string date_stop { get; set; }
    }

}
