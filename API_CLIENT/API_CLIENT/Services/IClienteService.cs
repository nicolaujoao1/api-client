using API_CLIENT.Models;
using API_CLIENT.Pagination;
using API_CLIENT.Requests;

namespace API_CLIENT.Services
{
    public interface IClienteService
    {
        Task<Cliente> CreateAsync(ClienteRequest request, CancellationToken cancellationToken = default);
        Task<PagedResult<Cliente>> GetClientesAsync(
            int pageNumber,
            int pageSize,
            string? nome = null,
            string? email = null,
            CancellationToken cancellationToken = default);

    }
}
