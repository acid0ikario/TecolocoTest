using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using DataAccess.Models;
using ServiceBusiness.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApp.Models;
using AutoMapper;

namespace WebApp.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobsService _jobs;
        private readonly IMapper _mapper;

        public JobsController(IJobsService jobs, IMapper mapper)
        {
            _jobs = jobs;
            _mapper = mapper;
        }


        public  IActionResult Index()
        {
            var ListJobs =  _mapper.Map<List<JobsDTO>>(_jobs.GetListJobs());
            return View(ListJobs);
        }


        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobs =  _jobs.GetJobById(id.Value);
            if (jobs == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<JobsDTO>(jobs));
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobsDTO jobs)
        {
            if (ModelState.IsValid)
            {
                _jobs.AddJob(_mapper.Map<Jobs>(jobs));
                return RedirectToAction(nameof(Index));
            }
            return View(jobs);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobs = _jobs.GetJobById(id.Value);
            if (jobs == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<JobsDTO>(jobs));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, JobsDTO jobs)
        {
            if (id != jobs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _jobs.UpdateJob(_mapper.Map<Jobs>(jobs));
                    
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ErrorUpdate", ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jobs);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobs = _jobs.GetJobById(id.Value);
            if (jobs == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<JobsDTO>(jobs));
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _jobs.DeleteJob(id);
            return RedirectToAction(nameof(Index));
        }

        private bool JobsExists(int id)
        {
            return _jobs.JobExist(id);
        }
    }
}
