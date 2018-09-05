using InitialCore.Data.Enums;

namespace InitialCore.Data.Interfaces
{
	public interface ISwitchable
	{
		Status Status { set; get; }
	}
}