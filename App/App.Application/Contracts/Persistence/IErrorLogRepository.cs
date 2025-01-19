using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IErrorLogRepository : IGenericRepository<ErrorLog, int>
    {
        
    }
}