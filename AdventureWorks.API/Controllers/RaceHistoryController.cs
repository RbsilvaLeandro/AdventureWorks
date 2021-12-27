using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Intefraces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.API.Controllers
{
    [Route("RaceHistory")]
    [ApiController]

    public class RaceHistoryController : Controller
    {
        private readonly IApplicationRaceHistory _applicationRaceHistory;

        public RaceHistoryController(IApplicationRaceHistory applicationRaceHistory)
        {
            _applicationRaceHistory = applicationRaceHistory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_applicationRaceHistory.ListDetails());
        }

     
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_applicationRaceHistory.ListDetails(id));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RaceHistoryDTO raceHistoryDto)
        {
            try
            {
                if (raceHistoryDto == null)
                    return NotFound();

                await _applicationRaceHistory.CreateAsync(raceHistoryDto);
                return Ok("Successfully registered race history");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromBody] RaceHistoryDTO raceHistoryDTO)
        {
            try
            {
                if (raceHistoryDTO == null)
                    return NotFound();

                await _applicationRaceHistory.UpdateAsync(raceHistoryDTO);
                return Ok("Race history updated successfully");
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
                await _applicationRaceHistory.DeleteAsync(id);
                return Ok("Race history successfully excluded");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
