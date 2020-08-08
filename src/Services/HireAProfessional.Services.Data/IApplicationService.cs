﻿namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;

    public interface IApplicationService
    {
        Task CreateApplicationAsync(string userId, string companyId);
    }
}
