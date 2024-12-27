using System.ComponentModel.DataAnnotations;

namespace ReactAppApi.Server.DTOs.StockDto
{
    public class UpdateStockDto
    {

        [Required] //data validation
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 over characters")]//data validation

        public string Symbol { get; set; } = string.Empty;
        [Required] //data validation
        [MaxLength(10, ErrorMessage = "CompanyName cannot be over 10 over characters")]//data validation
        public string CompanyName { get; set; } = string.Empty;

        [Required]//data validation
        [Range(1, 1000000000)]//data validation
        public decimal Purchase { get; set; }
        [Required]//data validation
        [Range(0.001, 100)]//data validation
        public decimal LastDiv { get; set; }
        [Required]//data validation
        [MaxLength(10, ErrorMessage = "Industry cannot be over 10 characters")]//data validation
        public string Industry { get; set; } = string.Empty;
        [Required]//data validation
        [Range(1, 5000000000)]//data validation
        public long MarketCap { get; set; }

    }
}

