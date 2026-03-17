using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/enterprises")]
    public class EnterpriseController : ControllerBase
    {
        private readonly IEnterpriseRepository _enterpriseRepository;
        private readonly ICodeRepository _codeRepository;

        public EnterpriseController(
            IEnterpriseRepository enterpriseRepository,
            ICodeRepository codeRepository)
        {
            _enterpriseRepository = enterpriseRepository;
            _codeRepository = codeRepository;
        }

        // GET api/enterprises
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enterprises = await _enterpriseRepository.GetAll();
            return Ok(enterprises);
        }

        // GET api/enterprises/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var enterprise = await _enterpriseRepository.GetById(id);

            if (enterprise == null)
                return NotFound("Empresa no encontrada");

            return Ok(enterprise);
        }

        // GET api/enterprises/{id}/codes
        [HttpGet("{id}/codes")]
        public async Task<IActionResult> GetCodes(int id)
        {
            var codes = await _codeRepository.GetByEnterprise(id);
            return Ok(codes);
        }

        // GET api/enterprises/by-nit/{nit}
        [HttpGet("by-nit/{nit}")]
        public async Task<IActionResult> GetByNit(long nit)
        {
            var enterprise = await _enterpriseRepository.GetByNit(nit);

            if (enterprise == null)
                return NotFound("Empresa no encontrada");

            return Ok(enterprise);
        }

        // POST api/enterprises
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Enterprise enterprise)
        {
            await _enterpriseRepository.Add(enterprise);

            return CreatedAtAction(nameof(GetById), new { id = enterprise.Id }, enterprise);
        }

        // PATCH api/enterprises/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Enterprise enterprise)
        {
            var existingEnterprise = await _enterpriseRepository.GetById(id);

            if (existingEnterprise == null)
                return NotFound("Empresa no encontrada");

            existingEnterprise.Name = enterprise.Name;
            existingEnterprise.Nit = enterprise.Nit;
            existingEnterprise.Gln = enterprise.Gln;

            await _enterpriseRepository.Update(existingEnterprise);

            return NoContent();
        }
    }
}
