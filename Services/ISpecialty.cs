using System.Collections.Generic;
using Sample.API.Models;

namespace Sample.API.Services
{
    public interface ISpecialty
    {
        IEnumerable<Specialty> GetAll();
        Specialty GetSpecialtyById(int id);
        void AddSpecialty(Specialty sp);
        void RemoveSpecialty(Specialty sp);
        void UpdateSpecialty(Specialty sp);
        bool ExistSpecialty(int id);
    }
}