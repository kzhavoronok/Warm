using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warm.Models;
using Warm.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Warm.Controllers
{
	[Route("api/[controller]")]
	public class BlogsController : Controller
	{
		readonly IBlogRepository _blogRepository;

		public BlogsController(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		[Route("page")]
		[HttpGet]
		public async Task<Page<Post>> GetPosts(int pageIndex, string tag)
		{
			return await _blogRepository.GetPosts(pageIndex, 10, tag);
		}
	}
}
