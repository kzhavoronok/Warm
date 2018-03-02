using System;
using System.Collections.Generic;
using System.Text;

namespace Warm.Models
{
    public class Page<T> where T:class
    {
	    public int CurrentPage { get; set; }
	    public int PageSize { get; set; }
		public List<T> Records { get; set; }
		public int TotalPages { get; set; }

	    public Page()
	    {
		    Records = new List<T>();
	    }

	    public Page(IEnumerable<T> records)
	    {
		    Records = new List<T>(records);
	    }
	}
}
