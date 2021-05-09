using GrpcWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcWebApp.Controllers
{
    public class UsageDataController : Controller
    {
        private readonly IUsageDataService _usageDataService;

        public UsageDataController(IUsageDataService usageDataService)
        {
            _usageDataService = usageDataService;
        }
        // GET: UsageDataController
        public async Task<ActionResult> IndexAsync()
        {
            return View(await _usageDataService.GetAllUsageData());
        }

        // GET: UsageDataController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsageDataController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsageDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsageDataController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsageDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsageDataController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsageDataController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
