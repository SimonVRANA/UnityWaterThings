// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;
using Zenject;

public class ThingJoint
{
	[Inject]
	private readonly IPhysicsSettingsService physicsSettingsService;

	private Vector2 position;
	public Vector2 Position => position;

	private Vector2 velocity;
	public Vector2 Velocity => velocity;

	public ThingJoint(Vector2 position)
	{
		this.position = position;
	}

	public void AddForce(Vector2 force)
	{
		velocity += force;
	}

	public void Update(float deltaTime)
	{
		position += velocity * deltaTime;

		velocity *= 1 - physicsSettingsService.PhysicsSettings.Friction;
	}
}