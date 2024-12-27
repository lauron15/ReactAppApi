using System.ComponentModel.DataAnnotations;

namespace ReactAppApi.Server.DTOs.StockDto
{
    public class CreateStockRequestDto
    {
        [Required] //data validation
        [MaxLength(10,ErrorMessage = "Symbol cannot be over 10 over characters")]//data validation

        public string Symbol { get; set; } = string.Empty;

        [Required] //data validation
        [MaxLength(10, ErrorMessage = "CompanyName cannot be over 10 over characters")]//data validation
        public string CompanyName { get; set; } = string.Empty;
           
        [Required]
        [Range(1,1000000000)]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001,100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage ="Industry cannot be over 10 characters")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1,5000000000)]
        public long MarketCap { get; set; }

    }
}

