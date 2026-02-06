using API_CLIENT.Context;
using API_CLIENT.Models;
using Microsoft.EntityFrameworkCore;

namespace API_CLIENT.Seeding
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (context.Clientes == null) return;


            if (await context.Clientes.AnyAsync()) return;

            var clientes = new List<Cliente>
            {
                new Cliente
                {
                    Nome = "João Silva",
                    Email = "joao.silva@email.com",
                },
                new Cliente
                {
                    Nome = "Maria Souza",
                    Email = "maria.souza@email.com",
                },
                new Cliente
                {
                    Nome = "Carlos Oliveira",
                    Email = "carlos.oliveira@email.com",
                }
            };

            await context.Clientes.AddRangeAsync(clientes);
            await context.SaveChangesAsync();
        }
    }
}
