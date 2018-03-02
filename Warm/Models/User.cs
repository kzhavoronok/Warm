using System;

namespace Warm.Models
{
    public class User
    {
	    public Guid Id { get; set; }
	    public bool IsAdmin { get; set; }
	    public string Login { get; set; }
		public string Password { get; set; }
    }
}
