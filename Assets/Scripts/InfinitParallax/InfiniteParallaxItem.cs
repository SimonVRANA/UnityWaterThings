// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using System;
using UnityEngine;

public class InfiniteParallaxItem : MonoBehaviour
{
	[SerializeField]
	private float minimumSize;

	public float MinimumSize => minimumSize;

	[SerializeField]
	private float maximumSize;

	public float MaximumSize => maximumSize;

	public EventHandler onWentOutOfScreen;

	[SerializeField]
	private float minimumFollowCameraSpeed;

	[SerializeField]
	private float maximumFollowCameraSpeed;

	private float followCameraSpeed;

	private Transform cameraTransform;

	private Vector3 lastCameraPosition;

	private void Awake()
	{
		cameraTransform = Camera.main.transform;
		RandomizeFollowCameraSpeed();
	}

	private void OnEnable()
	{
		lastCameraPosition = cameraTransform.position;
	}

	private void Update()
	{
		Vector3 cameraMovement = cameraTransform.position - lastCameraPosition;

		this.transform.position += cameraMovement * followCameraSpeed;

		lastCameraPosition = cameraTransform.position;

		float horizontalMinRange = cameraTransform.position.x - InfiniteParallax.halfScreenWidth - transform.lossyScale.x;
		float horizontalMaxRange = cameraTransform.position.x + InfiniteParallax.halfScreenWidth + transform.lossyScale.x;
		float verticalMinRange = cameraTransform.position.y - InfiniteParallax.halfScreenHeight - transform.lossyScale.y;
		float verticalMaxRange = cameraTransform.position.y + InfiniteParallax.halfScreenHeight + transform.lossyScale.y;
		if (transform.position.x < horizontalMinRange
			|| transform.position.x > horizontalMaxRange
			|| transform.position.y < verticalMinRange
			|| transform.position.y > verticalMaxRange)
		{
			onWentOutOfScreen?.Invoke(this, EventArgs.Empty);
		}
	}

	public void RandomizeFollowCameraSpeed()
	{
		followCameraSpeed = UnityEngine.Random.Range(minimumFollowCameraSpeed, maximumFollowCameraSpeed);
	}
}