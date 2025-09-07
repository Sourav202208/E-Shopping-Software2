using AutoMapper;

namespace HealthDemo.WebApp.MapperProfile
{
    public class Mapper : Profile
    {
        //Mappng..
        public Mapper()
        {
            CreateMap<Model.Model.PatientDataAddressVM,Data.Entities.Patient>();
            CreateMap<Model.Model.PatientDataAddressVM, Data.Entities.PatientAddress>();
        }
    }
}
