namespace task_2_api.DTO
{
    public class categoryrequestDTO
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public IFormFile CategoryImage { get; set; }
        
    }
    
}
