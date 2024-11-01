using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Database.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var options = CreateBuilderDbContextOptions(string.Empty);
        return new ApplicationDbContext(options);
    }

    public void RunPendingMigrations(string connectionsString)
    {
        var options = CreateBuilderDbContextOptions(connectionsString);
        var context = new ApplicationDbContext(options);

        if (context.Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator)
        {
            var migrations = context.Database.GetPendingMigrations();

            if (migrations.Any()) context.Database.Migrate();
        }
    }

    private DbContextOptions<ApplicationDbContext> CreateBuilderDbContextOptions(string connectionsString)
    {
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        builder.UseSqlServer(connectionsString);

        return builder.Options;
    }
}