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
        IBrandLogic bl;
        //IOwnerLogic ol;

        public StatController(ICarLogic cl, IBrandLogic bl)
        {
            this.cl = cl;
            this.bl = bl;
        }

        // GET:  stat/ownerwiththemostexpensivecar
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> OwnerWithTheMostExpensiveCar()
        {
            return cl.OwnerWithTheMostExpensiveCar();
        }

        //GET: stat/luigiscars
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> LuigisCars()
        {
            return cl.LuigisCars();
        }

        //GET: stat/vwowners
        [HttpGet]
        public IEnumerable<Owner> VWOwners()
        {
            return cl.VWOwners();
        }


        //GET: stat/ownersfrombp
        [HttpGet]
        public IEnumerable<KeyValuePair<Owner, string>> OwnersFromBp()
        {
            return cl.OwnersFromBp();
        }



        //GET: stat/expensivecars
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> ExpensiveCars()
        {
            return cl.ExpensiveCars();
        }











    }
}
