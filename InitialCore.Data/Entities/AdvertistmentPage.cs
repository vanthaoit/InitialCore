using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using InitialCore.Infrastructure.SharedKernel;

namespace InitialCore.Data.Entities
{
	[Table("AdvertistmentPages")]
	public class AdvertistmentPage : DomainEntity<string>
	{
		public string Name { get; set; }

		public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; }
	}
}