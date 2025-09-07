
using HealthDemo.Data;
using HealthDemo.Model.Model;
using HealthDemo.Service.PatientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HealthDemo.WebApp.Controllers
{
    [Authorize] 
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
       
        public PatientController( IPatientService patientService)
        {     
            _patientService = patientService;
        }
        //<--Read Data-->
        public IActionResult Index()
        {
            var result = _patientService.GetPatientDetails();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        //<--Insert Patient Data-->
        public IActionResult AddPatient(PatientDataAddressVM obj)
        {
           
            if (obj.Id == 0)
            {
                _patientService.PatientMapping(obj);
                TempData["Msg1"] = HealthResource.Add;
            }
            else
            {
                _patientService.Update(obj);
                TempData["Msg2"] = HealthResource.Update;
            }
            return RedirectToAction("Index");
        }
        //<--Delete Patient Data-->
        public IActionResult Delete(int Id)
        {
            _patientService.Delete(Id);
            TempData["Msg"] =HealthResource.Delete;
            return RedirectToAction("Index");
        }
        //<Edit Action>
        public IActionResult Edit(int Id)
        {
            var emp = _patientService.PatientEdit(Id);        
            return View("AddPatient", emp);
        }
    }
}
