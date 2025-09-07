using AutoMapper;
using HealthDemo.Data.Entities;
using HealthDemo.Data.ModelDbContext;
using HealthDemo.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Factory.Patients
{
    public class PatientFactory : IPatientFactory
    {
        //<--Database Connection object-->
        private readonly ApplicationDb _db;
        private readonly IMapper _mapper;
        public PatientFactory(ApplicationDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        //<!--Get Data-->
        public List<PatientDataAddressVM> GetPatientDetails()
        {

            var res = (from a in _db.Patients
                       join b in _db.PatientAddresses
                       on a.AddressId equals b.AddressId
                       select new PatientDataAddressVM
                       {
                           Id = a.Id,
                           Name = a.Name,
                           Age = a.Age,
                           Gender = a.Gender,
                           MedicalConditions = a.MedicalConditions,
                           Email = a.Email,
                           Contact = a.Contact,
                           Symptoms = a.Symptoms,
                           Note = a.Note,
                           Address = b.Address,
                           City = b.City,
                           Pincode = b.Pincode,
                       }).ToList();
            return res;
        }
        //<--Add Method-->(For Patient table)
        public Patient PatientMapping(PatientDataAddressVM patientDataAddressVM)
        {
            var emp = _mapper.Map<Patient>(patientDataAddressVM);
            return emp;           
        }
        //<--Add Method-->(For PatientAddress table)
        public PatientAddress AddressMapping(PatientDataAddressVM patientDataAddressVM)
        {
            var patientAddress = _mapper.Map<PatientAddress>(patientDataAddressVM);
            return patientAddress;
        }
        //[Post Method](For Patient table)
        //<--Edit-->
        public Patient Update(PatientDataAddressVM patientDataAddressVM)
        {
            var patients = _mapper.Map<Patient>(patientDataAddressVM);
            return patients;

        }
        //[Post Method](For PatientAddress table)
        //<--Edit-->
        public PatientAddress AddressUpdate(PatientDataAddressVM patientDataAddressVM)
        {
            var address = _mapper.Map<PatientAddress>(patientDataAddressVM);
            return address;  
        }
        //[Get Method]
        //<--Edit-->
        public PatientDataAddressVM PatientEdit(int Id)
        {
            var data = new PatientDataAddressVM();
            var edit = _db.Patients.Where(x => x.Id == Id).First();
            var Ab = _db.PatientAddresses.Where(x => x.AddressId == edit.AddressId).First();
            data.Id = edit.Id;
            data.Name = edit.Name;
            data.Age = edit.Age;
            data.Contact = edit.Contact;
            data.Gender = edit.Gender;
            data.Email = edit.Email;
            data.MedicalConditions = edit.MedicalConditions;
            data.Symptoms = edit.Symptoms;
            data.Note = edit.Note;
            data.AddressId = edit.AddressId;
            data.Address = Ab.Address;
            data.City = Ab.City;
            data.Pincode = Ab.Pincode;
            return data;
        }         
        //<--Delete Method-->
        public PatientDataAddressVM Delete(int Id)
        {
            var data = new PatientDataAddressVM();
            var del= _db.Patients.Where(a => a.Id == Id).FirstOrDefault();
            var ab= _db.PatientAddresses.Where(a => a.AddressId == del.AddressId).FirstOrDefault();
            _db.PatientAddresses.Remove(ab);
            _db.Patients.Remove(del);
            return data;
        }



    } 
}

