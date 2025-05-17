// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;

[CreateAssetMenu(fileName = "ThingsSettings", menuName = "Scriptable Objects/Things Settings")]
public class ThingsSettings : ScriptableObject
{
	[SerializeField]
	private float boneLength = 1f;

	public float BoneLength => boneLength;

	[SerializeField]
	private float boneElasticity = 0.2f;

	public float BoneElasticity => boneElasticity;
}