namespace Warm.Repository.Interfaces
{
	public interface IRepositoryContextFactory
	{
		RepositoryContext CreateDbContext(string connectionString);
	}
}