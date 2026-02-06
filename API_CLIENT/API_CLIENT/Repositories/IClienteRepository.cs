using API_CLIENT.Models;
using API_CLIENT.Pagination;

namespace API_CLIENT.Repositories
{
    public interface IClienteRepository
    {
        Task<PagedResult<Cliente>> GetClientesAsync(int pageNumber,
                                                    int pageSize,
                                                    string? nome = null,
                                                    string? email = null,
                                                    CancellationToken cancellationToken = default);
        Task<Cliente> CreateAsync(Cliente cliente, CancellationToken cancellationToken = default);
    }
}
