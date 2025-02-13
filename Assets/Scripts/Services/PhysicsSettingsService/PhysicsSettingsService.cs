// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

public class PhysicsSettingsService : IPhysicsSettingsService
{
	public PhysicsSettings PhysicsSettings { get; }
	public PhysicsSettingsService(PhysicsSettings physicsSettings)
	{
		this.PhysicsSettings = physicsSettings;
	}
}