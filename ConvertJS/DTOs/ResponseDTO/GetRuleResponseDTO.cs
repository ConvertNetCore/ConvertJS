namespace ConvertJS.DTOs.ResponseDTO
{
   
    public class GetRuleResponseDTO
    {
        public Datum11[] data { get; set; }
        public Paging paging { get; set; }
        public string __fb_trace_id__ { get; set; }
        public string __www_request_id__ { get; set; }
    }

    

    public class Datum11
    {
        public string account_id { get; set; }
        public int created_time { get; set; }
        public string entity_type { get; set; }
        public Evaluation_Spec evaluation_spec { get; set; }
        public Execution_Spec execution_spec { get; set; }
        public string id { get; set; }
        public bool is_for_account { get; set; }
        public string name { get; set; }
        public Schedule_Spec schedule_spec { get; set; }
        public string status { get; set; }
        public int updated_time { get; set; }
        public Created_By created_by { get; set; }
    }

    public class Evaluation_Spec
    {
        public string evaluation_type { get; set; }
        public Filter[] filters { get; set; }
    }

    public class Filter
    {
        public string field { get; set; }
        public string value { get; set; }
        public string _operator { get; set; }
    }

    public class Execution_Spec
    {
        public string execution_type { get; set; }
        public Execution_Options[] execution_options { get; set; }
    }

    public class Execution_Options
    {
        public string field { get; set; }
        public object value { get; set; }
        public string _operator { get; set; }
    }

    public class Schedule_Spec
    {
        public string schedule_type { get; set; }
    }

    public class Created_By
    {
        public string id { get; set; }
        public string name { get; set; }
    }

}
