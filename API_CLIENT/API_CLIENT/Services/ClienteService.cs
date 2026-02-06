using API_CLIENT.Models;
using API_CLIENT.Pagination;
using API_CLIENT.Repositories;
using API_CLIENT.Requests;

namespace API_CLIENT.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cliente> CreateAsync(ClienteRequest request, CancellationToken cancellationToken = default)
        {
            var cliente = new Cliente
            {
                Nome = request.Name,
                Email = request.Email
            };

            return await _repository.CreateAsync(cliente, cancellationToken);
        }

        public async Task<PagedResult<Cliente>> GetClientesAsync(
            int pageNumber,
            int pageSize,
            string? nome = null,
            string? email = null,
            CancellationToken cancellationToken = default)
        {
            return await _repository.GetClientesAsync(
                pageNumber,
                pageSize,
                nome,
                email,
                cancellationToken);
        }
    }
}
