using HealthDemo.Data;
using HealthDemo.Data.Entities;
using HealthDemo.Data.ModelDbContext;
using HealthDemo.Model.Model;
using HealthDemo.Service.PatientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthDemo.API.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
    
        public PatientsController(IPatientService patientService )
        {
            _patientService = patientService;
          
        }         
        [HttpGet]
        [Route("API/GetPatient")]
        //<--GetData-->
        public ActionResult<List<PatientDataAddressVM>> GetPatient()
        {
            var result = _patientService.GetPatientDetails();
            return result;
        }
        [HttpPost]
        [Route("API/AddPatient")]
        //<--AddData-->
        public ActionResult  AddPatient(PatientDataAddressVM obj)
        {

            if (obj.Id == 0)
            {
                _patientService.PatientMapping(obj);              
            }
            else
            {
                _patientService.Update(obj);               
            }           
            return Ok();
        }
        [HttpGet]
        [Route("API/DeletePatient")]
        //<--DeleteData-->
        public ActionResult Delete(int Id)
        {
            _patientService.Delete(Id);          
            return Ok();
        }
        [HttpGet]
        [Route("API/EditPatient")]
        //<--Edit Action-->
        public ActionResult Edit(int Id)
        {
            var emp = _patientService.PatientEdit(Id);
            return Ok();
        }
    }
}
