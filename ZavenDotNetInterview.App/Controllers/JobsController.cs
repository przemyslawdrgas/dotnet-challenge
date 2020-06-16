using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ZavenDotNetInterview.Entities.ViewModels;
using ZavenDotNetInterview.Services;

namespace ZavenDotNetInterview.App.Controllers
{
    [RoutePrefix("Tasks")]
    public class JobsController : Controller
    {
        private readonly IJobProcessorService _jobProcessorService;
        private readonly IJobService _jobService;
        private readonly IJobValidatorService _jobValidatorService;
        public JobsController(IJobProcessorService jobProcessorService, IJobService jobService, IJobValidatorService jobValidatorService)
        {
            _jobProcessorService = jobProcessorService;
            _jobService = jobService;
            _jobValidatorService = jobValidatorService;
        }

        // GET: Tasks
        [HttpGet, Route("")]
        public ActionResult Index()
        {
            var jobs = _jobService.GetJobsViewModel();
            return View(jobs);
        }

        // POST: Tasks/Process
        [HttpGet, Route("Process")]
        public async Task<ActionResult> Process()
        {
            await _jobProcessorService.ProcessJobs();

            return RedirectToAction("Index");
        }

        // GET: Tasks/Create
        [HttpGet, Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost, Route("Create")]
        public ActionResult Create(CreateJobViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var errors = _jobValidatorService.ValidateJob(model);
                    if (ResolveErrors(errors))
                        return View(model);
                    _jobService.CreateJob(model.Name, model.DoAfter);
                }
                else
                {
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet, Route("Details")]
        public ActionResult Details(Guid jobId)
        {
            JobViewModel job = _jobService.GetJobViewModel(jobId);
            return View(job);
        }

        private bool ResolveErrors(Dictionary<string, string> errors)
        {
            if (errors.Count > 0)
            {
                foreach (var item in errors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return true;
            }
            return false;
        }
    }
}
