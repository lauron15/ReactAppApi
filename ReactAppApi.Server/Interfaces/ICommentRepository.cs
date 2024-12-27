using ReactAppApi.Server.DTOs.StockDto;
using ReactAppApi.Server.Models;

namespace ReactAppApi.Server.Interfaces
{
    public interface ICommentRepository 
    {
        Task<List<Comment>> GetAllAsync();

        Task<Comment?> GetByIdAsync(int id);

        Task<Comment> CreateAsync(Comment commentModel);

        Task<Comment?> UpdateAsync(int id, Comment commentModel);

        Task<Comment> DeleteByIdAsync(int id);

    }
}
