using System.ComponentModel.DataAnnotations;

namespace ReactAppApi.Server.DTOs.Comments
{
    public class UpdateCommentRequestDto
    {
        [Required] //data validation
        [MinLength(5, ErrorMessage = "Title Must be at least 5 characters")] //data validation 
        [MaxLength(280, ErrorMessage = "Title cannot be over 280 characters")] //data validation
        public string Title { get; set; } = string.Empty;

        [Required] //data validation
        [MinLength(5, ErrorMessage = "Content Must be at least 5 characters")] //data validation 
        [MaxLength(280, ErrorMessage = "Content cannot be over 280 characters")] //data validation
        public string Content { get; set; } = string.Empty;
    }
}

