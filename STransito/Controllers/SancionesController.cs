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
    public class SancionesController : ControllerBase
    {
        private readonly TransitoDb _context;
        #region Constructor
        public SancionesController(TransitoDb context)
        {
            _context = context;
        }
        #endregion Constructor

        #region Mostrar todo
        // GET: api/<SancionesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOSanciones>>> Get()
        {
            try
            {
                var sa = await _context.Sanciones.Select(x => new DTOSanciones
                {
                    Id = x.Id,
                    Nombre = x.Conductor.Nombre,
                    Apellidos = x.Conductor.Apellidos,
                    FechaActual = x.FechaActual,
                    ConductorId = x.ConductorId,
                    Sancion = x.Sancion,
                    Observacion = x.Observacion,
                    Valor = x.Valor
                    
                }).ToListAsync();
                if (sa == null)
                {
                    return NotFound();
                }
                else
                {
                    return sa;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    # endregion Mostrar todo

        #region Mostrar por ID
        // GET api/<SancionesController>/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<DTOSanciones>> Get(int Id)
        {
            try
            {
                var sa = await _context.Sanciones.Select(x => new DTOSanciones
                {
                    Id = x.Id,
                    Nombre = x.Conductor.Nombre,
                    Apellidos = x.Conductor.Apellidos,
                    FechaActual = x.FechaActual,
                    ConductorId = x.ConductorId,
                    Sancion = x.Sancion,
                    Observacion = x.Observacion,
                    Valor = x.Valor
                }).FirstOrDefaultAsync(x => x.Id == Id);
                if (sa == null)
                {
                    return NotFound();
                }
                else
                {
                    return sa;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion Mostrar por ID

        #region Agregar Sancion
        // POST api/<SancionesController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(DTOSanciones san)
        {
            try
            {
                var entity = new Sanciones()
                {
                    Id = san.Id,
                    FechaActual = DateTime.Now,
                    ConductorId = san.ConductorId,
                    Sancion = san.Sancion,
                    Observacion = san.Observacion,
                    Valor = san.Valor
                };
                _context.Sanciones.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;

        }
        #endregion Agregar Sancion

        #region Actualizar
        // PUT api/<SancionesController>/5
        [HttpPut("{Id}")]
        public async Task<HttpStatusCode> Put(DTOSanciones sa)
        {
            try
            {
                var entity = await _context.Sanciones.FirstOrDefaultAsync(san => san.Id == sa.Id);
                entity.Id = sa.Id;
                entity.ConductorId = sa.ConductorId;
                entity.Sancion = sa.Sancion;
                entity.Observacion = sa.Observacion;
                entity.Valor = sa.Valor;
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.NoContent;
        }
        #endregion Actualizar

        #region Delete
        // DELETE api/<SancionesController>/5
        [HttpDelete("{Id}")]
        public async Task<HttpStatusCode> Delete(int Id)
        {
            var sa = await _context.Sanciones.FindAsync(Id);
            if (sa == null)
            {
                return HttpStatusCode.BadRequest;
            }
            else
            {
                _context.Entry(sa).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            return HttpStatusCode.OK;
        }
        #endregion Delete
    }
}
