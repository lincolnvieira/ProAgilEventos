using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IProAgilRepository _repository;
        public EventoController(IProAgilRepository repository)
        {
            _repository = repository;
        }

                // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllEventoAsync(true);

                return Ok(results);
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var results = await _repository.GetAllEventoAsyncById(eventoId, true);

                return Ok(results);
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");
            }
        }

        [HttpGet("getByTema{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                var results = await _repository.GetAllEventoAsyncByTema(tema, true);

                return Ok(results);
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento evento)
        {
            try
            {
                _repository.Add(evento);

                if(await _repository.SaveChangesAsync())
                {
                    return Created($"/api/evento/{evento.EventoId}", evento);
                }
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int eventoId, Evento evento)
        {
            try
            {
                var eventoEncontrado = await _repository.GetAllEventoAsyncById(eventoId, false);
 
                if(eventoEncontrado == null) return NotFound();
                
                _repository.Update(evento);
                
                if(await _repository.SaveChangesAsync())
                {
                    return Created($"/api/evento/{evento.EventoId}", evento);
                }
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int eventoId)
        {
            try
            {
                var eventoEncontrado = await _repository.GetAllEventoAsyncById(eventoId, false);
 
                if(eventoEncontrado == null) return NotFound();
                
                _repository.Delete(eventoEncontrado);
                
                if(await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");
            }

            return BadRequest();
        }
    }
}