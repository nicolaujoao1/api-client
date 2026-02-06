using API_CLIENT.Requests;
using API_CLIENT.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_CLIENT.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ClienteRequest request,
            CancellationToken cancellationToken)
        {
            var validationResult = ValidateModelState();
            if (validationResult != null)
                return validationResult;
            var cliente = await _clienteService.CreateAsync(request, cancellationToken);

            return Created(nameof(Create), cliente);
        }

        /// <summary>
        /// Lista clientes com paginação e filtros
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetClientes(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? nome = null,
            [FromQuery] string? email = null,
            CancellationToken cancellationToken = default)
        {
            var result = await _clienteService.GetClientesAsync(
                pageNumber,
                pageSize,
                nome,
                email,
                cancellationToken);

            return Ok(result);
        }



    }
}
