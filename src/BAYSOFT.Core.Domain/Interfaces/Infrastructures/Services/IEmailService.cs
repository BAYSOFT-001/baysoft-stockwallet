using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Interfaces.Infrastructures.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
