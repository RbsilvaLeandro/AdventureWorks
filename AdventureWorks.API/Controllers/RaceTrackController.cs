using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Intefraces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AdventureWorks.API.Controllers
{
    [Route("RaceTrack")]
    [ApiController]

    public class RaceTrackController : Controller
    {
        private readonly IApplicationRaceTrack _applicationRaceTrack;

        public RaceTrackController(IApplicationRaceTrack applicationRaceTrack)
        {
            _applicationRaceTrack = applicationRaceTrack;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_applicationRaceTrack.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_applicationRaceTrack.GetByIdAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RaceTrackDTO raceTrackDto)
        {
            try
            {
                if (raceTrackDto == null)
                    return NotFound();

                await _applicationRaceTrack.CreateAsync(raceTrackDto);
                return Ok("Successfully registered race track");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] RaceTrackDTO raceTrackDTO)
        {
            try
            {
                if (raceTrackDTO == null)
                    return NotFound();

                var dataRaceTrack = _applicationRaceTrack.GetByIdAsync(raceTrackDTO.Id);

                if (dataRaceTrack == null)
                    return NotFound();

                await _applicationRaceTrack.UpdateAsync(raceTrackDTO);
                return Ok("Race track updated successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dataRaceTrack = _applicationRaceTrack.GetByIdAsync(id);

                if (id == 0)
                    return NotFound();

                await _applicationRaceTrack.DeleteAsync(id);
                return Ok("Race track successfully excluded");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
