using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InitialCore.Infrastructure.SharedKernel;

namespace InitialCore.Data.Entities
{
	[Table("Footers")]
	public class Footer : DomainEntity<string>
	{
		[Required]
		public string Content { set; get; }
	}
}