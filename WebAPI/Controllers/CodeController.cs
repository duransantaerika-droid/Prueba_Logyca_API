using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodeController : ControllerBase
    {
        private readonly ICodeRepository _codeRepository;

        public CodeController(ICodeRepository codeRepository)
        {
            _codeRepository = codeRepository;
        }

        // GET api/code/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var code = await _codeRepository.GetById(id);

            if (code == null)
                return NotFound("Código no encontrado");

            return Ok(code);
        }

        // POST api/code
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Code code)
        {
            await _codeRepository.Add(code);

            return CreatedAtAction(nameof(GetById), new { id = code.Id }, code);
        }

        // PATCH api/code/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Code codeUpdate)
        {
            // 1. Buscamos el código real que está en la base de datos para no perder el Owner original
            var existingCode = await _codeRepository.GetById(id);

            if (existingCode == null)
            {
                return NotFound($"No se encontró el código con ID {id}");
            }

            // 2. SOLO actualizamos los campos que el usuario envió en el JSON
            if (!string.IsNullOrEmpty(codeUpdate.Name))
            {
                existingCode.Name = codeUpdate.Name;
            }

            if (codeUpdate.Description != null)
            {
                existingCode.Description = codeUpdate.Description;
            }

            // Si el usuario envía un Owner (Id de empresa) nuevo y válido, lo actualizamos
            if (codeUpdate.Owner != 0)
            {
                existingCode.Owner = codeUpdate.Owner;
            }

            try
            {
                // 3. Guardamos los cambios en la base de datos
                await _codeRepository.Update(existingCode);
                return Ok(existingCode);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar: {ex.InnerException?.Message ?? ex.Message}");
            }
        }




        // GET api/code/{id}/enterprise
        [HttpGet("{id}/enterprise")]
        public async Task<IActionResult> GetEnterpriseByCode(int id)
        {
            var code = await _codeRepository.GetById(id);

            if (code == null)
                return NotFound("Código no encontrado");

            return Ok(code.Enterprise);
        }
    }
}
