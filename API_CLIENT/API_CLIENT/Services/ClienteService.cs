using API_CLIENT.Exceptions;
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
                Nome = request.Nome,
                Email = request.Email
            };

            var createdCliente = await _repository.CreateAsync(cliente, cancellationToken);

            if (createdCliente == null)
                throw new BusinessException("Já existe um cliente cadastrado com este email.");

            return createdCliente;
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
