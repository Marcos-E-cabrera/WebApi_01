using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApiYerbas.Models;
using WebApiYerbas.Services;

namespace WebApiYerbas.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class YerbaController : Controller
    {


        [HttpGet]
        public List<Yerba> Get()
        {
            return YerbaServices.Get();
        }


        [HttpGet("{id}")]
        public Yerba GetById(int id)
        {
            return YerbaServices.GetById(id);
        }


        [HttpPut]
        public bool Put(Yerba yerba)
        {
            return YerbaServices.Update(yerba);
        }

        [HttpPost]
        public bool Post(Yerba yerba)
        {
            return YerbaServices.Add(yerba);
        }

  
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return YerbaServices.Delete(id);
        }


    }
}
    