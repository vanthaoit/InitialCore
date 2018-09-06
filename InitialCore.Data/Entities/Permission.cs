﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InitialCore.Infrastructure.SharedKernel;

namespace InitialCore.Data.Entities
{
	[Table("Permissions")]
	public class Permission : DomainEntity<int>
	{
		[Required]
		public Guid RoleId { get; set; }

		[StringLength(128)]
		[Required]
		public string FunctionId { get; set; }

		public bool CanCreate { set; get; }
		public bool CanRead { set; get; }

		public bool CanUpdate { set; get; }
		public bool CanDelete { set; get; }


		[ForeignKey("RoleId")]
		public virtual ApplicationRole ApplicationRole { get; set; }

		[ForeignKey("FunctionId")]
		public virtual Function Function { get; set; }
	}
}