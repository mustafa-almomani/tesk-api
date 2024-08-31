using task_2_api.Models;

namespace task_2_api.DTO
{
    public class cartItemResponseDTO
    {
        public int CartItemId { get; set; }

        public int? CartId { get; set; }
        public int? ProductId { get; set; }

        public int Quantity { get; set; }
        public productDTO product { get; set; }


    }
    public class productDTO 
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

   
        public decimal? Price { get; set; }
        public IFormFile ProductImage { get; set; }





    }
}
