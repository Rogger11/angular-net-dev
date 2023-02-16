using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Back.Data;
using Back.Models;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly BackContext _context;

        public PersonasController(BackContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public IEnumerable<Persona> GetPersonas()
        {
            return _context.Personas.ToList();
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public ActionResult<Persona> GetPersona(int id)
        {
            var persona = _context.Personas.Find(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // POST: api/Personas
        [HttpPost]
        public ActionResult<Persona> PostPersona(Persona persona)
        {
            persona.FechaCreacion = DateTime.Now;
            persona.NumeroIdentificacionCompleto = persona.TipoIdentificacion + persona.NumeroIdentificacion;
            persona.NombresApellidos = persona.Nombres + " " + persona.Apellidos;

            _context.Personas.Add(persona);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPersona), new { id = persona.Id }, persona);
        }
    }
}
