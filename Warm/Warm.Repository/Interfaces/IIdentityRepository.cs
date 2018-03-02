using System.Threading.Tasks;
using Warm.Models;

namespace Warm.Repository.Interfaces
{
    public interface IIdentityRepository
    {
	    Task<User> GetUser(string userName);
	}
}
