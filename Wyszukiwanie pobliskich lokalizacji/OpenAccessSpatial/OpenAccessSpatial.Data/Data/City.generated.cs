#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Microsoft.SqlServer.Types;


namespace OpenAccessSpatial.Core.Data	
{
	public partial class City
	{
		private int id;
		public virtual int Id 
		{ 
		    get
		    {
		        return this.id;
		    }
		    set
		    {
		        this.id = value;
		    }
		}
		
		private string name;
		public virtual string Name 
		{ 
		    get
		    {
		        return this.name;
		    }
		    set
		    {
		        this.name = value;
		    }
		}
		
		private string postalCode;
		public virtual string PostalCode 
		{ 
		    get
		    {
		        return this.postalCode;
		    }
		    set
		    {
		        this.postalCode = value;
		    }
		}
		
		private SqlGeography coordinates;
		public virtual SqlGeography Coordinates 
		{ 
		    get
		    {
		        return this.coordinates;
		    }
		    set
		    {
		        this.coordinates = value;
		    }
		}
		
	}
}