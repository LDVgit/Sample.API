using System.Collections.Generic;
using Sample.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Sample.API.Services
{
    public class SpecialtyService : ISpecialty
    {
        private readonly ApiContext _ctx;
        public SpecialtyService (ApiContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Specialty> GetAll()
        {
            return _ctx.Specialties.Include(doc => doc.Doctors);
        }

        public Specialty GetSpecialtyById(int id)
        {
            if(ExistSpecialty(id))
            {
                return GetAll().ToList().Find(i =>i.Id == id);
            } 
            else
            {
                return null;
            }
            
        }
        public bool ExistSpecialty(int id)
        {
            return _ctx.Specialties.Any(i => i.Id == id);
        }
        public void AddSpecialty(Specialty sp)
        {
            _ctx.Specialties.Add(sp);
            _ctx.SaveChanges();
        }

        public void RemoveSpecialty(int id)
        {
            if(ExistSpecialty(id))
            {
                var sp = GetSpecialtyById(id);
                _ctx.Specialties.Remove(sp);
                _ctx.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Not found");
                throw new System.Exception("Not found");           
            }
        }

        public void UpdateSpecialty(Specialty sp)
        {
            if(ExistSpecialty(sp.Id))
            {
                _ctx.Specialties.Update(sp);
                _ctx.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Not found");
                throw new System.Exception("Not found");
            }
        }
    }
}