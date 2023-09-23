namespace ConvertJS.DTOs.ResponseDTO
{
    public class AdSpyPostDTO
    {
        public string keyword { get; set; }
        public string Id { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public int NumberLike { get; set; }
        public int NumberComment { get; set; }
        public int NumberShare { get; set; }
    }
}
