using System.ComponentModel.DataAnnotations;

namespace ReactAppApi.Server.DTOs.Comments
{
    public class CreateCommentDto
    {
        //DO not use data validation direct on the Models, use them on DTOs instead. 
        // I do not need to make data validation on the beginning of the project, just if I would like to test the actual validation 

        [Required] //data validation
        [MinLength(5,ErrorMessage = "Title Must be at least 5 characters")] //data validation 
        [MaxLength(280,ErrorMessage ="Title cannot be over 280 characters")]
        public string Title { get; set; } = string.Empty;
        [Required] //data validation
        [MinLength(5, ErrorMessage = "Content Must be at least 5 characters")] //data validation 
        [MaxLength(280, ErrorMessage = "Content cannot be over 280 characters")]
        public string Content { get; set; } = string.Empty;
    }
}

