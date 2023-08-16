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
    public class BurritoController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        [HttpGet]
        public List<Burrito> GetAll()
        {
            return dbContext.Burritos.ToList();
        }

        [HttpGet("{name}")]
        public Burrito GetInfo(string name)
        {
            return dbContext.Burritos.FirstOrDefault(c => c.Name == name);

        }

        [HttpPost]
        public Burrito AddBurrito(string name, float cost, bool bean)
        {
            Burrito newBurrito = new Burrito();
            newBurrito.Name = name;
            newBurrito.Cost = cost;
            newBurrito.Bean = bean;
            dbContext.Burritos.Add(newBurrito);

            dbContext.SaveChanges();

            return newBurrito;
        }
    }
}

