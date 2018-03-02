using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Warm.Repository;

namespace Warm
{
	//required only for migration utility
	public class DesignTimeRepositoryContextFactory :
		IDesignTimeDbContextFactory<RepositoryContext>
	{
		public RepositoryContext CreateDbContext(string[] args)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");
			var config = builder.Build();

			//вытаскиваем строку подключения из конфига
			var connectionString = config.GetConnectionString("DefaultConnection");
			var repositoryFactory = new RepositoryContextFactory();

			//создаем и возвращаем DBContext
			return repositoryFactory.CreateDbContext(connectionString);
		}
	}
}
