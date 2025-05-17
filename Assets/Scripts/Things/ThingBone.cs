// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;
using Zenject;

public class ThingBone
{
	[Inject]
	private readonly IThingsSettingsService thingsSettingsService;

	private readonly ThingJoint joint1;
	private readonly ThingJoint joint2;

	public ThingBone(ThingJoint joint1, ThingJoint joint2)
	{
		this.joint1 = joint1;
		this.joint2 = joint2;
	}

	public void Update()
	{
		// apply a force to joint 1 and 2 to keep them at a certain distance

		Vector2 direction = joint2.Position - joint1.Position;
		float distance = direction.magnitude;
		float difference = distance - thingsSettingsService.ThingsSettings.BoneLength;
		joint1.AddForce(0.5f * difference * thingsSettingsService.ThingsSettings.BoneElasticity * direction.normalized);
		joint2.AddForce(-0.5f * difference * thingsSettingsService.ThingsSettings.BoneElasticity * direction.normalized);
		joint1.ForcePosition(joint1.Position + 0.5f * difference * direction.normalized);
		joint2.ForcePosition(joint2.Position - 0.5f * difference * direction.normalized);
	}
}