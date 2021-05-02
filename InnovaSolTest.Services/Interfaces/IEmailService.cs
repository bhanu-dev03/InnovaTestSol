using InnovaSolTest.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSolTest.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailDto emailDto);
    }
}
