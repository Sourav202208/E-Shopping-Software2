using HealthDemo.Data.Entities;
using HealthDemo.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Service.PatientService
{
    public interface IPatientService
    {
        //<--Methods-->
        List<PatientDataAddressVM> GetPatientDetails();
        Patient PatientMapping(PatientDataAddressVM patientDataAddressVM);
        PatientDataAddressVM PatientEdit(int Id);
        PatientDataAddressVM Delete(int Id);
        Patient Update(PatientDataAddressVM patientDataAddressVM);
    }
}
