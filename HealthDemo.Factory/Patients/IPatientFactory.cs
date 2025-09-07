using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthDemo.Data.Entities;
using HealthDemo.Model.Model;

namespace HealthDemo.Factory.Patients
{
    public interface IPatientFactory
    {
        //<--Methods-->
        List<PatientDataAddressVM> GetPatientDetails();
        Patient PatientMapping(PatientDataAddressVM patientDataAddressVM);
        PatientAddress AddressMapping(PatientDataAddressVM patientDataAddressVM);
        Patient Update (PatientDataAddressVM patientDataAddressVM);
        PatientAddress AddressUpdate(PatientDataAddressVM patientDataAddressVM);
        PatientDataAddressVM PatientEdit(int Id);
        PatientDataAddressVM Delete(int Id);
   

    }
}
