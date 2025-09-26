namespace Addresses.API.Application.Infrastructure.Interfaces
{
    public interface IRedisService
    {
        Task<T> GetAsync<T>(string key);
        Task AddAsync<T>(string key, T value);  
    }
}
