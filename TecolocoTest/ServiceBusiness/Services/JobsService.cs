using DataAccess.Context;
using DataAccess.Models;
using ServiceBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ServiceBusiness.Services
{
    public class JobsService : IJobsService
    {
        private readonly TecolocoDbContext _dbcontext;
        public JobsService(TecolocoDbContext context)
        {
            _dbcontext = context;
        }
        public Jobs AddJob(Jobs job)
        {
            job.CreatedAt = DateTime.Now;
            _dbcontext.Jobs.Add(job);
            _dbcontext.SaveChanges();
            return job;
        }

        public void DeleteJob(int id)
        {
            var auxJob = _dbcontext.Jobs.Find(id);
            _dbcontext.Jobs.Remove(auxJob);
            _dbcontext.SaveChanges();
        }

        public Jobs GetJobById(int id)
        {
            return _dbcontext.Jobs.Find(id);
        }

        public List<Jobs> GetListJobs()
        {
            return _dbcontext.Jobs.ToList();
        }

        public bool JobExist(int id)
        {
            return _dbcontext.Jobs.Any(x => x.Id == id);
        }

        public Jobs UpdateJob(Jobs job)
        {
            _dbcontext.Jobs.Update(job);
            _dbcontext.SaveChanges();
            return job;
        }
    }
}
