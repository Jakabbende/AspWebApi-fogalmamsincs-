using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspWebApi.Models;
using AspWebApi.Services;
using AspWebApi.DTOs;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GyogyszerController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAllGyogyszer()
        {
            try
            {
                List<Gyogyszer> res = new GyogyszerService().GetAllGyogyszer();
                if (res.Count > 0)
                {
                    return Ok(res);
                }
                else
                {
                    return NotFound("Nincs betölthető adat");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("GetById/{id}")]
        public IActionResult GetGyogyszer(int id)
        {

            try
            {
                Gyogyszer gy = new GyogyszerService().GetbyId(id);
                if (gy is not null)
                    return Ok(gy);
                else
                    return NotFound("Nincs ilyen azonosítójú");
            }
            catch (Exception ex)
            {
                return BadRequest("Hiba történt " + ex.Message);
            }
        }

        [HttpGet("NevHatoanyag")]
        public IActionResult NevHatoanyag()
        {
            try
            {
                List<NevHatoanyagDTO> res = new GyogyszerService().GetAllGyogyszer().Select(g => new NevHatoanyagDTO()
                { Id = g.Id, Nev = g.Nev, Hatoanyag = g.Hatoanyag }).ToList();
                if (res is not null)
                    return Ok(res);
                else
                    return NotFound("Nincs megjeleníthető adat");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("NevHatoanyagId/{id}")]
        public IActionResult NevHatoanyagById(int id)
        {
            try
            {
                Gyogyszer gy = new GyogyszerService().GetbyId(id);

                if (gy is not null)
                {
                    NevHatoanyagDTO gynh = new NevHatoanyagDTO()
                    {
                        Id = gy.Id,
                        Nev = gy.Nev,
                        Hatoanyag = gy.Hatoanyag
                    };

                    return Ok(gynh);
                }
                else
                {
                    return NotFound("Nincs ilyen azonosítójú gyógyszer.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
