using Microsoft.AspNetCore.Mvc;
using BackendPracticalTest.Services;
using BackendPracticalTest.DTOs;

namespace BackendPracticalTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _service;

        public TransactionController(TransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var transactions = _service.GetAll();
            return Ok(transactions);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TransactionDTO dto)
        {
            _service.Create(dto);
            return Ok(new { message = "Transação criada com sucesso!" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TransactionDTO dto)
        {
            dto.Id = id; // Corrigido: era TransactionId
            _service.Update(dto);
            return Ok(new { message = "Transação atualizada com sucesso!" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok(new { message = "Transação removida com sucesso!" });
        }
    }
}
