using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STransito.DAL.DbContext;
using STransito.DAL.Entidades;
using STransito.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STransito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductorController : ControllerBase
    {
        private readonly TransitoDb _context;
        #region Constructor
        public ConductorController(TransitoDb context)
        {
            _context = context;
        }
        #endregion Constructor

        #region Mostrar todos
        // GET: api/<ConductorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOConductor>>> Get()
        {
            try
            {
                var co = await _context.Conductor.Select(x => new DTOConductor
                {
                    Identificacion = x.Identificacion,
                    Nombre = x.Nombre,
                    Apellidos = x.Apellidos,
                    Direccion = x.Direccion,
                    Telefono = x.Telefono,
                    Email = x.Email,
                    FechaNacimiento = x.FechaNacimiento,
                    Activo = x.Activo,
                    IdMAtricula = x.IdMAtricula,
                    FechaExpedicion = x.Matricula.FechaExpedicion,
                    ValidaHasta = x.Matricula.ValidaHasta
                }).ToListAsync();
                if (co == null)
                {
                    return NotFound();
                }
                else
                {
                    return co;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion Mostar todos

        #region Mostrar por Id
        // GET api/<ConductorController>/5
        [HttpGet("{Identificacion}")]
        public async Task<ActionResult<DTOConductor>> Get(string Identificacion)
        {
            try
            {
                var co = await _context.Conductor.Select(x => new DTOConductor
                {
                    Identificacion = x.Identificacion,
                    Nombre = x.Nombre,
                    Apellidos = x.Apellidos,
                    Direccion = x.Direccion,
                    Telefono = x.Telefono,
                    Email = x.Email,
                    FechaNacimiento = x.FechaNacimiento,
                    Activo = x.Activo,
                    IdMAtricula = x.IdMAtricula,
                    FechaExpedicion = x.Matricula.FechaExpedicion,
                    ValidaHasta = x.Matricula.ValidaHasta

                }).FirstOrDefaultAsync(x => x.Identificacion == Identificacion);
                if (co == null)
                {
                    return NotFound();
                }
                else
                {
                    return co;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion Mostrar por Id

        #region Agregar conductor
        // POST api/<ConductorController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(DTOConductor co)
        {
            try
            {
                var entity = new Conductor()
                {
                    Identificacion = co.Identificacion,
                    Nombre = co.Nombre,
                    Apellidos = co.Apellidos,
                    Direccion = co.Direccion,
                    Telefono = co.Telefono,
                    Email = co.Email,
                    FechaNacimiento = co.FechaNacimiento,
                    Activo = co.Activo,
                    IdMAtricula = co.IdMAtricula
                };
                _context.Conductor.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;



        }
        #endregion Agregar conductor

        #region Actualizar conductor
        // PUT api/<ConductorController>/5
        [HttpPut("{Identificacion}")]
        public async Task<HttpStatusCode> Put(DTOConductor co)
        {
            try
            {
                var entity = await _context.Conductor.FirstOrDefaultAsync(cond => cond.Identificacion == co.Identificacion);
                entity.Identificacion = co.Identificacion;
                entity.Nombre = co.Nombre;
                entity.Apellidos = co.Apellidos;
                entity.Direccion = co.Direccion;
                entity.Telefono = co.Telefono;
                entity.Email = co.Email;
                entity.FechaNacimiento = co.FechaNacimiento;
                entity.Activo = co.Activo;
                entity.IdMAtricula = co.IdMAtricula;
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.NoContent;
        }
        #endregion Actualizar conductor

        #region Eliminar Conductor
        // DELETE api/<ConductorController>/5
        [HttpDelete("{Identificacion}")]
        public async Task<HttpStatusCode> Delete(string Identificacion)
        {
            var co = await _context.Conductor.FindAsync(Identificacion);
            if (co == null)
            {
                return HttpStatusCode.BadRequest;
            }
            else
            {
                _context.Entry(co).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            return HttpStatusCode.OK;
        }
        #endregion Eliminar Conductor
    }
}
