﻿namespace BookStoreApp.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<int> GetRecordsCountAsyc();
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();

        Task<T> AddAsync(T entity);
        
        Task<T> UpdateAsync(T entity);
        
        Task DeleteAsync(T entity);
    }
}