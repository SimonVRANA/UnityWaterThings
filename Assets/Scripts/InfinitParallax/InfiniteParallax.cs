// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using System;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteParallax : MonoBehaviour
{
	// TODO: find a better way to calculate screen sizes in UUnit.
	public static float halfScreenWidth = 9;

	public static float halfScreenHeight = 5;

	[SerializeField]
	private InfiniteParallaxParameters underwaterInfiniteParallaxParameters;

	private Transform cameraTransform;

	private readonly List<InfiniteParallaxItem> frontItems = new();
	private readonly List<InfiniteParallaxItem> backItems = new();

	private void Awake()
	{
		cameraTransform = Camera.main.transform;
		transform.localScale = Vector3.one;
	}

	private void OnEnable()
	{
		GenerateAllParallaxObjects();
	}

	private void OnDisable()
	{
		DestroyAllParallaxObjects();
	}

	private void GenerateAllParallaxObjects()
	{
		for (int i = 0; i < underwaterInfiniteParallaxParameters.NumberOfFrontItems; i++)
		{
			InfiniteParallaxItem item = Instantiate(underwaterInfiniteParallaxParameters.FrontPrefab);
			frontItems.Add(item);
			PositionItem(item, false);
		}
		for (int i = 0; i < underwaterInfiniteParallaxParameters.NumberOfBackItems; i++)
		{
			InfiniteParallaxItem item = Instantiate(underwaterInfiniteParallaxParameters.BackPrefab);
			backItems.Add(item);
			PositionItem(item, false);
		}
	}

	private InfiniteParallaxItem PositionItem(InfiniteParallaxItem item, bool atScreenBordes = true)
	{
		item.transform.parent = transform;

		float itemSize = item.MinimumSize + UnityEngine.Random.Range(0.0f, 1.0f) * (item.MaximumSize - item.MinimumSize);
		item.transform.localScale = new Vector3(itemSize, itemSize, itemSize);

		float horizontalMinRange = cameraTransform.position.x - halfScreenWidth - itemSize;
		float horizontalMaxRange = cameraTransform.position.x + halfScreenWidth + itemSize;
		float verticalMinRange = cameraTransform.position.y - halfScreenHeight - itemSize;
		float verticalMaxRange = cameraTransform.position.y + halfScreenHeight + itemSize;
		if (atScreenBordes)
		{
			float screenSide = UnityEngine.Random.Range(0.0f, 1.0f);
			if (screenSide < 0.5f)
			{
				item.transform.position = new(screenSide < 0.25f ? horizontalMinRange : horizontalMaxRange,
											  UnityEngine.Random.Range(verticalMinRange, verticalMaxRange),
											  item.transform.position.z);
			}
			else
			{
				item.transform.position = new(UnityEngine.Random.Range(horizontalMinRange, horizontalMaxRange),
											 screenSide < 0.75f ? verticalMinRange : verticalMaxRange,
											 item.transform.position.z);
			}
		}
		else
		{
			item.transform.position = new(UnityEngine.Random.Range(horizontalMinRange, horizontalMaxRange),
										  UnityEngine.Random.Range(verticalMinRange, verticalMaxRange),
										  item.transform.position.z);
		}

		item.RandomizeFollowCameraSpeed();

		item.onWentOutOfScreen += OnItemWentOutOfScreen;

		return item;
	}

	public void OnItemWentOutOfScreen(object sender, EventArgs arguments)
	{
		if (sender is InfiniteParallaxItem item)
		{
			PositionItem(item);
		}
	}

	private void DestroyAllParallaxObjects()
	{
		foreach (InfiniteParallaxItem obj in frontItems)
		{
			frontItems.Remove(obj);
			Destroy(obj);
		}
		foreach (InfiniteParallaxItem obj in backItems)
		{
			frontItems.Remove(obj);
			Destroy(obj);
		}
	}
}