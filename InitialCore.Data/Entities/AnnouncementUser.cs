﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InitialCore.Infrastructure.SharedKernel;

namespace InitialCore.Data.Entities
{
	[Table("AnnouncementUsers")]
	public class AnnouncementUser : DomainEntity<int>
	{
		[StringLength(128)]
		[Required]
		public string AnnouncementId { get; set; }

		public Guid UserId { get; set; }

		public bool? HasRead { get; set; }

		[ForeignKey("AnnouncementId")]
		public virtual Announcement Announcement { get; set; }
	}
}