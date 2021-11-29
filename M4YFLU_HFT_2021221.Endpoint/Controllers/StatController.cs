using M4YFLU_HFT_2021221.Logic;
using M4YFLU_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace M4YFLU_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICarLogic cl;

        public StatController(ICarLogic cl)
        {
            this.cl = cl;
        }

        // GET:  stat/ownerwiththemostexpensivecar
        [HttpGet]
        public Owner OwnerWithTheMostExpensiveCar()
        {
            return cl.OwnerWithTheMostExpensiveCar();
        }





    }
}
