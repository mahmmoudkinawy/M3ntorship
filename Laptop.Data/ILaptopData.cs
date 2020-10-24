using Laptop.Core;
using System.Collections.Generic;
using System.Text;

namespace Laptop.Data
{
    public interface ILaptopData
    {
        //IEnumerable<LaptopObjects> GetAll();
        IEnumerable<LaptopObjects> GetLaptopByName(string name);
        LaptopObjects Add(LaptopObjects addLaptopObjects);
        LaptopObjects Update(LaptopObjects updatedLaptop);
        LaptopObjects GetById(int id);
        LaptopObjects Delete(int id);
        int Commit();
    }
}
