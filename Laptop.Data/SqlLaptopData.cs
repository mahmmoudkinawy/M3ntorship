using Laptop.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Laptop.Data
{
    public class SqlLaptopData : ILaptopData
    {
        private readonly LaptopObjectsDbContext db;

        public SqlLaptopData(LaptopObjectsDbContext db)
        {
            this.db = db;
        }
        public LaptopObjects Add(LaptopObjects addLaptopObjects)
        {
            db.Add(addLaptopObjects);
            return addLaptopObjects;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public LaptopObjects Delete(int id)
        {
            var laptop = GetById(id);
            if(laptop != null)
            {
                db.laptops.Remove(laptop);
            }
            return laptop;
        }

        public LaptopObjects GetById(int id)
        {
            return db.laptops.Find(id);
        }

        public IEnumerable<LaptopObjects> GetLaptopByName(string name)
        {
            return from r in db.laptops
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public LaptopObjects Update(LaptopObjects updatedLaptop)
        {
            var entity = db.laptops.Attach(updatedLaptop);
            entity.State = EntityState.Modified;
            return updatedLaptop;
        }
    }
}
