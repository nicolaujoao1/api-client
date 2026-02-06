using Microsoft.AspNetCore.Mvc;

namespace API_CLIENT.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ValidateModelState()
        {
            if (ModelState.IsValid)
                return null!;

            var erros = ModelState
                .Where(x => x.Value!.Errors.Count > 0)
                .Select(x => new
                {
                    Campo = x.Key,
                    Mensagens = x.Value!.Errors.Select(e => e.ErrorMessage)
                });

            return BadRequest(new
            {
                mensagem = "Erro de validação nos campos informados.",
                erros
            });
        }
    }
}
