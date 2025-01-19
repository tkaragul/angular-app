using App.Application.Features.ErrorLogFeatures.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.ErrorLogFeatures
{
    public interface IErrorLogService
    {
        Task CreateAsync(CreateErrorLogCommand request, CancellationToken cancellationToken);
    }
}
