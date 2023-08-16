using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taco_Bell.Models;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taco_Bell.Controllers
{
    [Route("api/[controller]")]
    public class TacoController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();
        //dbContext.Taco

        [HttpGet]
        public List <Taco> GetAll()
        {
            return dbContext.Tacos.ToList();
        }

        [HttpGet("{name}")]
        public Taco GetInfo(string name)
        {
            return dbContext.Tacos.FirstOrDefault(c => c.Name == name);
        }

        [HttpPost]
        public Taco AddTaco(string name, float cost, bool softshell, bool dorito)
        {
            Taco newTaco = new Taco();
            newTaco.Name = name;
            newTaco.Cost = cost;
            newTaco.SoftShell = softshell;
            newTaco.Dorito = dorito;
            dbContext.Tacos.Add(newTaco);

            dbContext.SaveChanges();

            return newTaco;
        }

    }
}

