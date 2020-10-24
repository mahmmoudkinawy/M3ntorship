using Laptop.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laptop.Data
{
    public class Repository : ILaptopData
    {
        private readonly List<LaptopObjects> laptopObjects;
        public Repository()
        {
            laptopObjects = new List<LaptopObjects>()
            {
                new LaptopObjects
                {
                    Id = 1 , 
                    Name = "Apple" , 
                    Color = "White" , 
                    Generation = 10 ,
                    HardDisk = 256 , 
                    Model = 2020 , 
                    Ram = 4 
                } ,
                new LaptopObjects
                {
                    Id = 2 ,
                    Name = "Dell" ,
                    Color = "Balck" ,
                    Generation = 7 ,
                    HardDisk = 1000 ,
                    Model = 2017 ,
                    Ram = 8
                } ,
                new LaptopObjects
                {
                    Id = 3 ,
                    Name = "Levovo" ,
                    Color = "Black" ,
                    Generation = 8 ,
                    HardDisk = 500 ,
                    Model = 2018 ,
                    Ram = 16
                } ,
                new LaptopObjects
                {
                    Id = 4 ,
                    Name = "Samsung" ,
                    Color = "Blue" ,
                    Generation = 4 ,
                    HardDisk = 128 ,
                    Model = 2013 ,
                    Ram = 3
                } ,
                new LaptopObjects
                {
                    Id = 5 ,
                    Name = "Alienware" ,
                    Color = "White" ,
                    Generation = 10 ,
                    HardDisk = 1000 ,
                    Model = 2020 ,
                    Ram = 64
                } ,
            };
        }


        //CRUD operations 
        public LaptopObjects Add(LaptopObjects addLaptopObjects)
        {
            laptopObjects.Add(addLaptopObjects);
            addLaptopObjects.Id = laptopObjects.Max(r => r.Id) + 1;
            return addLaptopObjects;
        }

        public LaptopObjects Update(LaptopObjects updatedLaptop)
        {
            var lap = laptopObjects.SingleOrDefault(r => r.Id == updatedLaptop.Id);
            var index = laptopObjects.IndexOf(lap);
            laptopObjects[index] = lap;
            return updatedLaptop;

            //if(lap != null)
            //{
            //    lap.Name = updatedLaptop.Name;
            //    lap.Color = updatedLaptop.Color;
            //    lap.Generation = updatedLaptop.Generation;
            //    lap.HardDisk = updatedLaptop.HardDisk;
            //    lap.Ram = updatedLaptop.Ram;
            //}

            //return lap;
        }

        public LaptopObjects GetById(int id)
        {
            return laptopObjects.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<LaptopObjects> GetLaptopByName(string name = null)
        {
            return from r in laptopObjects
                   where string.IsNullOrEmpty(name) || r.Name.Contains(name,StringComparison.InvariantCultureIgnoreCase)
                   orderby r.Name
                   select r;
        }

        //public IEnumerable<LaptopObjects> GetAll()
        //{
        //    return from r in laptopObjects
        //           orderby r.Name
        //           select r;
        //}

        public int Commit()
        {
            return 0;
        }

        public LaptopObjects Delete(int id)
        {
            var laptop = laptopObjects.SingleOrDefault(r => r.Id == id);
            if(laptop != null)
            {
                laptopObjects.Remove(laptop);
            }
            return laptop;
        }
    }
}
