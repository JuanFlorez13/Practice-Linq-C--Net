using Managers.Context;
using Managers.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using AppContext = Managers.Context.AppContext;

namespace Managers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly AppContext context;
        public ManagersController(AppContext context) { this.context = context; }


        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.managers.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }


        [HttpGet("{id}", Name = "GetOneManager")]
        public ActionResult Get(int id)
        {
            try
            {
                var manager = context.managers.FirstOrDefault(m => m.id == id);
                return Ok(manager);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }


        [HttpPost]
        public ActionResult Post([FromBody] ManagersDB managersDB)
        {
            try
            {
                context.managers.Add(managersDB);
                context.SaveChanges();
                return CreatedAtRoute("GetOneManager", new { id = managersDB.id}, managersDB );
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ManagersDB managersDB)
        {
            try
            {
                if(managersDB.id == id)
                {
                    context.Entry(managersDB).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetOneManager", new { id = managersDB.id }, managersDB);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var manager = context.managers.FirstOrDefault(m => m.id == id);
                if(manager != null)
                {
                    context.managers.Remove(manager);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}