// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;

[CreateAssetMenu(fileName = "InfinitParrallaxParametters", menuName = "Scriptable Objects/Infinite Parallax/Infinite Parallax Parameters")]
public class InfiniteParallaxParameters : ScriptableObject
{
	[Header("Front")]
	[SerializeField]
	private InfiniteParallaxItem frontPrefab;

	public InfiniteParallaxItem FrontPrefab => frontPrefab;

	[SerializeField]
	private int numberOfFrontItems;

	public int NumberOfFrontItems => numberOfFrontItems;

	[Header("Back")]
	[SerializeField]
	private InfiniteParallaxItem backPrefab;

	public InfiniteParallaxItem BackPrefab => backPrefab;

	[SerializeField]
	private int numberOfBackItems;

	public int NumberOfBackItems => numberOfBackItems;
}