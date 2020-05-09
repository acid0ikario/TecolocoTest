using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBusiness.Interfaces
{
    public interface IJobsService
    {
        Jobs GetJobById(int id);
        Jobs AddJob(Jobs job);
        Jobs UpdateJob(Jobs job);
        void DeleteJob(int id);
        List<Jobs> GetListJobs();
        bool JobExist(int id);
    }
}
