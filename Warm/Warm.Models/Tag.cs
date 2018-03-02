using System;

namespace Warm.Models
{
	public class Tag
	{
		public Guid Id { get; set; }
		public string Value { get; set; }
		public Guid PostId { get; set; }
	}
}