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
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        IOwnerLogic ol;

        public OwnerController(IOwnerLogic ol)
        {
            this.ol = ol;
        }


        // GET: /owner
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return ol.GetAll();
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            return ol.Read(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Owner value)
        {
            ol.Create(value);

        }

        // PUT owner/
        [HttpPut]
        public void Put([FromBody] Owner value)
        {
            ol.Update(value);

        }

        // DELETE /owner/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ol.Delete(id);

        }
    }
}
