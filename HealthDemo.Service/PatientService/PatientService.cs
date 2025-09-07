using HealthDemo.Data.Entities;
using HealthDemo.Data.ModelDbContext;
using HealthDemo.Factory.Patients;
using HealthDemo.Model.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Service.PatientService
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDb _db;
        private readonly IPatientFactory _patientFactory;
        public PatientService(ApplicationDb db, IPatientFactory patientFactory)
        {
            _db = db;
            _patientFactory = patientFactory;
        }
        public List<PatientDataAddressVM> GetPatientDetails()
        {
            return _patientFactory.GetPatientDetails();
        }
        //<--Add Method-->
        public Patient PatientMapping(PatientDataAddressVM patientDataAddressVM)
        {
            var obj = new Patient();
            var emp = _patientFactory.PatientMapping(patientDataAddressVM);
            var patientAddress = _patientFactory.AddressMapping(patientDataAddressVM);
            if (patientDataAddressVM.Id == 0)
            {
                emp.PatientAddress = patientAddress;
                _db.Patients.Add(emp);
                _db.SaveChanges();
            }
            return obj;
        }
        public PatientDataAddressVM PatientEdit(int Id)
        {
            var emp = new PatientDataAddressVM();
            emp = _patientFactory.PatientEdit(Id);
            return emp;
        }
        public PatientDataAddressVM Delete(int Id)
        {
            var data = new PatientDataAddressVM();
            _patientFactory.Delete(Id);
            _db.SaveChanges();
            return data;
        }
        public Patient Update(PatientDataAddressVM patientDataAddressVM)
        {
            var abc = _patientFactory.Update(patientDataAddressVM);
            var abcd = _patientFactory.AddressUpdate(patientDataAddressVM);
            if (patientDataAddressVM.Id > 0)
            {
                abc.PatientAddress = abcd;
                _db.Patients.Update(abc);
                _db.SaveChanges();
            }
            return abc;

        }

    }
}
