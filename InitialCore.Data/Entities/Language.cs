using System.ComponentModel.DataAnnotations;
using InitialCore.Data.Enums;
using InitialCore.Data.Interfaces;
using InitialCore.Infrastructure.SharedKernel;

namespace InitialCore.Data.Entities
{
	public class Language : DomainEntity<string>, ISwitchable
	{
		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		public bool IsDefault { get; set; }

		public string Resources { get; set; }

		public Status Status { get; set; }
	}
}