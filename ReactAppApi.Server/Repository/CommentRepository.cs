﻿using Microsoft.EntityFrameworkCore;
using ReactAppApi.Server.Data;
using ReactAppApi.Server.Interfaces;
using ReactAppApi.Server.Models;

namespace ReactAppApi.Server.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.Include(a => a.AppUser).ToListAsync();
            
            // return await _context.Comments.ToListAsync(); before the modification 
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.Id == id);

            //return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if (existingComment == null) 
            {
            return null;
            }

            existingComment.Title = commentModel.Title;
            existingComment.Content = commentModel.Content;
            
            await _context.SaveChangesAsync();
            return existingComment;
        }

        public async Task<Comment> DeleteByIdAsync(int id)
        {

            var commentModel = await _context.Comments.FirstOrDefaultAsync(c=>c.Id == id);

            if (commentModel == null)
            {
                return null;
            }

            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
          
        
        }
    }
}
