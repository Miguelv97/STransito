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
    public class MatriculaController : ControllerBase
    {
        private readonly TransitoDb _context;
        #region Constructor
        public MatriculaController(TransitoDb context)
        {
            _context = context;
        }
        #endregion Constructor

        #region Mostrar todos
        // GET: api/<MatriculaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOMatricula>>> Get()
        {
            try
            {
                var mat = await _context.Matricula.Select(x => new DTOMatricula
                {
                    Numero = x.Numero,
                    FechaExpedicion = x.FechaExpedicion,
                    ValidaHasta = x.ValidaHasta,
                    Activo = x.Activo
                }).ToListAsync();
                if (mat == null)
                {
                    return NotFound();
                }
                else
                {
                    return mat;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion Mostrar todos

        #region Mostrar por Numero Matricula
        // GET api/<MatriculaController>/5
        [HttpGet("{Numero}")]
        public async Task<ActionResult<DTOMatricula>> Get(string Numero)
        {
            try
            {
                var mat = await _context.Matricula.Select(x => new DTOMatricula
                {
                    Numero = x.Numero,
                    FechaExpedicion = x.FechaExpedicion,
                    ValidaHasta = x.ValidaHasta,
                    Activo = x.Activo
                }).FirstOrDefaultAsync(x => x.Numero == Numero);
                if (mat == null)
                {
                    return NotFound();
                }
                else
                {
                    return mat;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion Mostrar por Numero Matricula

        #region Agregar Matricula
        // POST api/<MatriculaController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(DTOMatricula mat)
        {
            try
            {
                var entity = new Matricula()
                {
                    Numero = mat.Numero,
                    FechaExpedicion = mat.FechaExpedicion,
                    ValidaHasta = mat.ValidaHasta,
                    Activo = mat.Activo
                };
                _context.Matricula.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;

        }
        #endregion Agregar matricula

        #region Actualizar matricula
        // PUT api/<MatriculaController>/5
        [HttpPut("{Numero}")]
        public async Task<HttpStatusCode> Put(DTOMatricula mat)
        {
            try
            {
                var entity = await _context.Matricula.FirstOrDefaultAsync(x => x.Numero == mat.Numero);
                entity.Numero = mat.Numero;
                entity.FechaExpedicion = mat.FechaExpedicion;
                entity.ValidaHasta = mat.ValidaHasta;
                entity.Activo = mat.Activo;
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.NoContent;
        }
        #endregion Actualizar matricula

        #region Eliminar matricula
        // DELETE api/<MatriculaController>/5
        [HttpDelete("{Numero}")]
        public async Task<HttpStatusCode> Delete(string Numero)
        {
            var mat = await _context.Matricula.FindAsync(Numero);
            if (mat == null)
            {
                return HttpStatusCode.BadRequest;
            }
            else
            {
                _context.Entry(mat).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            return HttpStatusCode.OK;
        }
        #endregion Eliminar matricula
    }
}
