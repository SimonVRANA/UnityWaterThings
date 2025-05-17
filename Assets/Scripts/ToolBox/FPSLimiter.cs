// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
	[SerializeField]
	private int targetFrameRate = 60;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Start()
	{
#if UNITY_EDITOR
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = targetFrameRate;
#endif
	}
}