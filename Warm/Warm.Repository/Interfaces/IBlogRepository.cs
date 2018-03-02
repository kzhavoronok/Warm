using System.Collections.Generic;
using System.Threading.Tasks;
using Warm.Models;
using System;

namespace Warm.Repository.Interfaces
{
	public interface IBlogRepository
	{
		Task<Page<Post>> GetPosts(int index, int pageSize, string tag = null);
		Task<Post> GetPost(Guid id);
		Task AddComment(Comment comment);
		Task<List<string>> GetAllTagNames();
		Task AddPost(Post post);
	}
}
