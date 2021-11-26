﻿using M4YFLU_HFT_2021221.Logic;
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
    public class CarController : ControllerBase
    {
        ICarLogic cl;

        public CarController(ICarLogic cl)
        {
            this.cl = cl;
        }




        // GET: /car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return cl.GetAll();
        }

        // GET /car/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return cl.Read(id);
        }

        // POST /car
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            cl.Create(value);


        }

        // PUT car/
        [HttpPut]
        public void Put([FromBody] Car value)
        {
            cl.Update(value);


        }

        // DELETE car/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
