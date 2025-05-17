// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;

public class ThingBoneVisualizer : MonoBehaviour
{
	public ThingJoint Joint1 { get; set; }
	public ThingJoint Joint2 { get; set; }

	private void Update()
	{
		if (Joint1 == null
			|| Joint2 == null)
		{
			return;
		}
		transform.position = (Joint1.Position + Joint2.Position) / 2;

		Vector2 targetPos = Joint1.Position;
		Vector3 thisPos = transform.position;
		targetPos.x -= thisPos.x;
		targetPos.y -= thisPos.y;
		float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}