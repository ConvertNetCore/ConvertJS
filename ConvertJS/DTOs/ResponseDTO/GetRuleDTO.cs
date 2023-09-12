namespace ConvertJS.DTOs.ResponseDTO
{
    public class GetRuleDTO
    {
        public string ID { get; set; }
        public string RuleName { get; set; }
        public string Status { get; set; }
        public string AcctionCondition { get; set; }
        public string RuleResults { get; set; }
        public string WhenRuleRun { get; set; }
        public string CreatedBy { get; set; }
    }
}
