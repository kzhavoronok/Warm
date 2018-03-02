using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warm.Models;
using Warm.Repository.Interfaces;

namespace Warm.Repository
{
	public class BlogRepository : BaseRepository, IBlogRepository
	{
		public BlogRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

		public async Task<Page<Post>> GetPosts(int index, int pageSize, string tag = null)
		{
			var result = new Page<Post> { CurrentPage = index, PageSize = pageSize };

			using (var context = ContextFactory.CreateDbContext(ConnectionString)) // 1
			{
				var query = context.Posts.AsQueryable();
				if (!string.IsNullOrWhiteSpace(tag))
				{
					query = query.Where(p => p.Tags.Any(t => t.Value == tag));
				}

				result.TotalPages = await query.CountAsync();
				query = query.Include(p => p.Tags).Include(p => p.Comments).OrderByDescending(p => p.Created).Skip(index * pageSize).Take(pageSize); // 2
				result.Records = await query.ToListAsync(); //3
			}

			return result;
		}

		public async Task<List<string>> GetAllTagNames()
		{
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				return await context.Tags.Select(t => t.Value).Distinct().ToListAsync();
			}
		}

		public async Task<Post> GetPost(Guid id)
		{
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				return await context.Posts.Include(p => p.Tags).Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
			}
		}

		public async Task AddComment(Comment comment)
		{
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				context.Comments.Add(comment);
				await context.SaveChangesAsync();
			}
		}

		public async Task AddPost(Post post)
		{
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				context.Posts.Add(post);
				await context.SaveChangesAsync();
			}
		}
	}
}
