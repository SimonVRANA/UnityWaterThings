// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

public class ThingsSettingsService : IThingsSettingsService
{
	public ThingsSettings ThingsSettings { get; }

	public ThingsSettingsService(ThingsSettings thingsSettings)
	{
		this.ThingsSettings = thingsSettings;
	}
}