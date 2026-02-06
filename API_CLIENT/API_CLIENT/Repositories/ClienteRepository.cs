using API_CLIENT.Context;
using API_CLIENT.Models;
using API_CLIENT.Pagination;
using Microsoft.EntityFrameworkCore;

namespace API_CLIENT.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente, CancellationToken cancellationToken = default)
        {
            var emailExiste = await _context.Clientes!
               .AnyAsync(c => c.Email == cliente.Email, cancellationToken);

            if (emailExiste)
                throw new Exception("Já existe um cliente cadastrado com este email.");

            await _context.Clientes!.AddAsync(cliente, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return cliente;
        }

        public async Task<PagedResult<Cliente>> GetClientesAsync(int pageNumber, int pageSize, string? nome = null, string? email = null, CancellationToken cancellationToken = default)
        {
            var query = _context.Clientes!
               .AsNoTracking()
               .AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
            {
                query = query.Where(c => c.Nome.Contains(nome));
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(c => c.Email.Contains(email));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var clientes = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<Cliente>
            {
                Items = clientes,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }

}
