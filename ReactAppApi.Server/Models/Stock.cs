using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReactAppApi.Server.Models
{
    public class Stock
    {

        //DO not use data validation direct on the Models 
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("Symbol")]
        public string Symbol { get; set; } = string.Empty;

        [Column("company_name")] // Ajustado para evitar espaços no nome da coluna
        public string CompanyName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")] // Corrigido o tipo de dado
        public decimal Purchase { get; set; }

        [Column(TypeName = "decimal(18,2)")] // Corrigido o tipo de dado
        public decimal LastDiv { get; set; }

        [Column("industry")]
        public string Industry { get; set; } = string.Empty;

        [Column("market_cap")] // Ajustado para evitar espaços no nome da coluna
        public long MarketCap { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
           
    }
}