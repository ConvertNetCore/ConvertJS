namespace ConvertJS.DTOs.ResponseDTO
{
    
    public class DeleteErrorResponseDTO
    {
        public Error error { get; set; }
        public string __fb_trace_id__ { get; set; }
        public string __www_request_id__ { get; set; }
    }

    public class Error
    {
        public string message { get; set; }
        public string type { get; set; }
        public int code { get; set; }
        public int error_subcode { get; set; }
        public bool is_transient { get; set; }
        public string error_user_title { get; set; }
        public string error_user_msg { get; set; }
        public string help_center_id { get; set; }
        public string fbtrace_id { get; set; }
    }

}

