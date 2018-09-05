using System;
using System.ComponentModel.DataAnnotations;
using InitialCore.Data.Enums;
using InitialCore.Data.Interfaces;
using InitialCore.Infrastructure.SharedKernel;

namespace InitialCore.Data.Entities
{
	public class SystemConfig : DomainEntity<string>, ISwitchable
	{
		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		public string Value1 { get; set; }

		public int? Value2 { get; set; }

		public bool? Value3 { get; set; }

		public DateTime? Value4 { get; set; }

		public decimal? Value5 { get; set; }

		public Status Status { get; set; }
	}
}