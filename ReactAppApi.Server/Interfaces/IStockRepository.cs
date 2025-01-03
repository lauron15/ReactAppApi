﻿using Microsoft.EntityFrameworkCore;
using ReactAppApi.Server.Data;
using ReactAppApi.Server.DTOs.StockDto;
using ReactAppApi.Server.Helpers;
using ReactAppApi.Server.Models;

namespace ReactAppApi.Server.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
       // Task<List<Stock>> GetAllAsync(); the right method without filtering
        Task<Stock?> GetByIdAsync(int id); //first or default can be null

        Task<Stock?> GetBySymbolAsync(string symbol);

        Task<Stock> CreateAsync(Stock stockModel);

        Task<Stock> UpdateByIdAsync(int id, UpdateStockDto stockDto);

        Task<Stock> DeleteByIdAsync(int id);

        Task<bool> StockExists(int id);
    }
}


