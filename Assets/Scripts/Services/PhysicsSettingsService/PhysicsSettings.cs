// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;

[CreateAssetMenu(fileName = "PhysicsSettings", menuName = "Scriptable Objects/Physics Settings")]
public class PhysicsSettings : ScriptableObject
{
	[SerializeField]
	private float friction = 0.2f;

	public float Friction => friction;
}