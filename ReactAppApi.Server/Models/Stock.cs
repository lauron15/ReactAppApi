using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReactAppApi.Server.Models
{
    [Table("Stocks")]
    public class Stock
    {

        //DO not use data validation direct on the Models 
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("Symbol")]
        public string Symbol { get; set; } = string.Empty;

        [Column("company_name")] // Adjusted to avoid spaces in the column name
        public string CompanyName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")] // Corrected data type
        public decimal Purchase { get; set; }

        [Column(TypeName = "decimal(18,2)")] // Corrected data type
        public decimal LastDiv { get; set; }

        [Column("industry")]
        public string Industry { get; set; } = string.Empty;

        [Column("market_cap")] // Adjusted to avoid spaces in the column name
        public long MarketCap { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();


    }
}