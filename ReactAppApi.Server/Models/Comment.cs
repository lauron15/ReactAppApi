namespace ReactAppApi.Server.Models
{
    public class Comment
    {

        //DO not use data validation direct on the Models 
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? StockId { get; set; }

        public Stock? Stock { get; set; }
    }
}
