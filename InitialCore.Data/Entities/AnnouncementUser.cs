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

		[StringLength(450)]
		[Required]
		public string UserId { get; set; }

		public bool? HasRead { get; set; }

		[ForeignKey("UserId")]
		public virtual ApplicationUser ApplicationUser { get; set; }

		[ForeignKey("AnnouncementId")]
		public virtual Announcement Announcement { get; set; }
	}
}