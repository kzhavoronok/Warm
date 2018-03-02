using System.Collections.Generic;
using Warm.Models;

namespace Warm.Repository.Interfaces
{
	public interface ICommentRepository
	{
		List<Comment> GetList();
		void Delete(int commentId);
		void Add(Comment comment);
	}
}
