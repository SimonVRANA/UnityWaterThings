// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SpeedParticles : MonoBehaviour
{
	[SerializeField]
	private float speedMultiplier = 10.0f;

	private ParticleSystem particleSystemComponent = null;

	private Vector3 previousPosition;

	private void OnValidate()
	{
		particleSystemComponent = GetComponent<ParticleSystem>();
	}

	private void OnEnable()
	{
		previousPosition = transform.position;
	}

	private void Update()
	{
		if (particleSystemComponent != null)
		{
			float speed = Vector3.Distance(previousPosition, transform.position);

			ParticleSystem.MainModule mainModule = particleSystemComponent.main;
			mainModule.startSpeed = speedMultiplier * speed;

			Vector3 movementDirection = transform.position - previousPosition;
			float angle = Vector3.SignedAngle(movementDirection, Vector3.right, Vector3.forward);
			ParticleSystem.ShapeModule shapeModule = particleSystemComponent.shape;
			shapeModule.rotation = new Vector3(angle, 0.0f, 0.0f);
		}

		previousPosition = transform.position;
	}
}