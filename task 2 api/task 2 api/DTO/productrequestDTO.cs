namespace task_2_api.DTO
{
    public class productrequestDTO
    {
        public string? ProductName { get; set; }

        public string? Descr { get; set; }

        public decimal? Price { get; set; }

        public IFormFile ProductImage { get; set; }
     
    }
}
