﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace InitialCore.Data.Entities
{
	public class ApplicationRole : IdentityRole<Guid>
	{
		public ApplicationRole() : base()
		{
		}

		public ApplicationRole(string name, string description) : base(name)
		{
			this.Description = description;
		}

		[StringLength(250)]
		public string Description { get; set; }
	}
}