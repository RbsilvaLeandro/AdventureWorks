using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Intefraces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.API.Controllers
{
    [Route("Competitor")]
    [ApiController]
    public class CompetitorController : Controller
    {
        private readonly IApplicationCompetitor _applicationCompetitor;

        public CompetitorController(IApplicationCompetitor applicationCompetitor)
        {
            _applicationCompetitor = applicationCompetitor;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           return Ok(_applicationCompetitor.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Ok(_applicationCompetitor.GetByIdAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompetitorDTO competitorDto)
        {
            try
            {
                if (competitorDto == null)
                    return NotFound();

                await _applicationCompetitor.CreateAsync(competitorDto);
                return Ok("Successfully registered competitor");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] CompetitorDTO competitorDto)
        {
            try
            {
                if (competitorDto == null)
                    return NotFound();

                var dataCompetitor = _applicationCompetitor.GetByIdAsync(competitorDto.Id);

                if (competitorDto == null)
                    return NotFound();

                await _applicationCompetitor.UpdateAsync(competitorDto);
                return Ok("Competitor updated successfully");
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
                if (id == 0)
                    return NotFound();

                var dataCompetitor = _applicationCompetitor.GetByIdAsync(id);

                if (dataCompetitor == null)
                    return NotFound();


                await _applicationCompetitor.DeleteAsync(id);
                return Ok("Competitor successfully excluded");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
