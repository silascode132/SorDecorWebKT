using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebDecor.Areas.Admin.Models
{
	[DataContract]
	public class DataPoints
    {
		public DataPoints(int x, decimal y)
		{
			this.X = x;
			this.Y = y;
		}

		//Explicitly setting the name to be used while serializing to JSON. 
		[DataMember(Name = "label")]
		public string Label = null;

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<decimal> Y = null;

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "x")]
		public Nullable<int> X = null;

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "z")]
		public Nullable<decimal> Z = null;
	}
}