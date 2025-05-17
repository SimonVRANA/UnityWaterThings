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

		// Apply friction as a force opposing velocity
		Vector2 frictionForce = -velocity.normalized * physicsSettingsService.PhysicsSettings.Friction;
		velocity += frictionForce * deltaTime;

		// Prevent velocity from oscillating around zero
		if (velocity.magnitude < 0.01f)
		{
			velocity = Vector2.zero;
		}
	}

	public void ForcePosition(Vector2 position)
	{
		this.position = position;
	}
}