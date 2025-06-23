using api_escola.Controllers.Dtos;
using api_escola.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api_escola.Controllers
{
    [ApiController]
    [Route("api/v1/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;
        public AlunoController(IAlunoService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult CriarAluno([FromBody]AlunoDtoRequest request)
        {
            _service.CriarAluno(request);
            return Created("api/v1/aluno", request);
        }
    }
}
