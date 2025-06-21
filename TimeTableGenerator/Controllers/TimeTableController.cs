using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.Models;
using TimeTableGenerator.Repositories;

namespace TimeTableGenerator.Controllers
{
    public class TimeTableController : Controller
    {
        private static InputModel inputData;
        private static List<SubjectHoursModel> subjectHoursList;
        private readonly ITimeTableRepository _repo;

        public TimeTableController(ITimeTableRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(InputModel model)
        {
            if (ModelState.IsValid) 
            {
                inputData = model;
                return RedirectToAction("SubjectHours");
            }           
            return View(model);
            
        }

        [HttpGet]
        public IActionResult SubjectHours()
        { 
            subjectHoursList = new List<SubjectHoursModel>();
            for (int i = 0; i < inputData.TotalSubjects; i++)
            {
                subjectHoursList.Add(new SubjectHoursModel());
            }
            return View(subjectHoursList);
        }

        [HttpPost]
        public IActionResult SubjectHours(List<SubjectHoursModel> model)
        { 
            int enteredTotal = model.Sum(m => m.Hours);
            int expectedTotal = inputData.TotalHours;

            if (enteredTotal != expectedTotal)
            {
                ModelState.AddModelError("", $"Total subject hours must be equal to {expectedTotal}");
                return View(model);
            }
                
            subjectHoursList = model;
            return RedirectToAction("Generate");
        }

        public IActionResult Generate()
        {
            var subjectDect = subjectHoursList.ToDictionary(s => s.SubjectName, s => s.Hours);
            var table = _repo.GenerateTimeTable(inputData.WorkingDays, inputData.SubjectsPerDay, subjectDect);
            ViewBag.WorkingDays = inputData.WorkingDays;
            return View(table);
        }
    }
}
