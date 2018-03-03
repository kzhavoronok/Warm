using System;
using System.Collections.Generic;


namespace Warm.Models
{
	public class Post
	{
		public Guid Id { get; set; }
		public string Header { get; set; }
		public string Body { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public ICollection<Tag> Tags { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
	}
}
