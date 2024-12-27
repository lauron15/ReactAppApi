using ReactAppApi.Server.DTOs.Comments;
using ReactAppApi.Server.Models;

namespace ReactAppApi.Server.Mappers.CommentMappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content, 
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
               
            };
        }


        public static Comment ToCommentFromCreat(this CreateCommentDto commentDto,int stockId )
        {
            return new Comment
            {
                
                Title = commentDto.Title,
                Content = commentDto.Content,
     
                StockId = stockId

            };
        }
        public static Comment ToCommentFromUpdatet(this UpdateCommentRequestDto commentDto)
        {
            return new Comment
            {

                Title = commentDto.Title,
                Content = commentDto.Content,
                



            };
        }
    }



}

