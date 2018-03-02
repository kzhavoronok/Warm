using System;

namespace Warm.Models
{
	public class Comment
	{
		public Guid Id { get; set; }
		public User Author { get; set; }
		public string Body { get; set; }
		public DateTime Created { get; set; }
		public Guid PostId { get; set; }
	}
}