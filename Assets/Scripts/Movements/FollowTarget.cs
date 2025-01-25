// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	[SerializeField]
	private Transform target;

	[SerializeField]
	private Vector3 offset;

	private void Update()
	{
		if (target != null)
		{
			transform.position = target.position + offset;
		}
	}
}