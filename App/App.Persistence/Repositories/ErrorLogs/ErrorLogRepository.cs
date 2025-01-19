using App.Application.Contracts.Persistence;
using App.Application.Features.ErrorLogFeatures;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Repositories.ErrorLogs
{
    public class ErrorLogRepository(AppDbContext context)
        : GenericRepository<ErrorLog, int>(context), IErrorLogRepository
    {

    }
}
