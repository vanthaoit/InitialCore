using System;
using System.ComponentModel.DataAnnotations.Schema;
using InitialCore.Data.Enums;
using InitialCore.Data.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace InitialCore.Data.Entities
{
	[Table("ApplicationUsers")]
	public class ApplicationUser : IdentityUser<Guid>, IDateTracking, ISwitchable
	{
		public string FullName { get; set; }

		public DateTime? BirthDay { set; get; }

		public decimal Balance { get; set; }

		public string Avatar { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }

		public Status Status { get; set; }
	}
}