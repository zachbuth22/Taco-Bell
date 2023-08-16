using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taco_Bell.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taco_Bell.Controllers
{
    [Route("api/[controller]")]
    public class DrinkController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        [HttpGet]
        public List<Drink> GetAll()
        {
            return dbContext.Drinks.ToList();
        }

        [HttpGet("{name}")]
        public Drink GetInfo(string name)
        {
            return dbContext.Drinks.FirstOrDefault(c => c.Name == name);

        }

        [HttpDelete("Delete/{Id}")]
        public Drink DeleteDrink(int Id)
        {
            Drink c = dbContext.Drinks.FirstOrDefault(c => c.Id == Id);
            dbContext.Drinks.Remove(c);
            dbContext.SaveChanges();

            return c;
        }
    }
}

