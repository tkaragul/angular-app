using App.Application.Contracts.Persistence;
using App.Application.Features.ErrorLogFeatures;
using App.Application.Features.ErrorLogFeatures.Create;
using App.Domain.Entities;
using AutoMapper;

namespace App.Persistence.Services
{
    public class ErrorLogService(IErrorLogRepository errorLogRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IErrorLogService
    {
        public async Task CreateAsync(CreateErrorLogCommand request, CancellationToken cancellationToken)
        {
            ErrorLog newErrorLog = mapper.Map<ErrorLog>(request);

            await errorLogRepository.AddAsync(newErrorLog);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
