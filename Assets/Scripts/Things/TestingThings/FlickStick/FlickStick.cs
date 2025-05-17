// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;
using Zenject;

public class FlickStick : MonoBehaviour
{
	[Header("Flick")]
	[SerializeField]
	private float flickCooldown = 5f;

	[SerializeField]
	private float minXForce = 1000.0f;

	[SerializeField]
	private float maxXForce = 2000.0f;

	[SerializeField]
	private float minYForce = 1000.0f;

	[SerializeField]
	private float maxYForce = 2000.0f;

	[Header("Links")]
	[SerializeField]
	private Transform jointVisual1;

	[SerializeField]
	private Transform jointVisual2;

	[SerializeField]
	private ThingBoneVisualizer boneVisualizer;

	private ThingJoint joint1;
	private ThingJoint joint2;
	private ThingBone bone;

	private float timeBeforeNextFlick = 0f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Start()
	{
		joint1 = new ThingJoint(transform.position);
		joint2 = new ThingJoint(transform.position + new Vector3(0, -1f, 0));
		bone = new ThingBone(joint1, joint2);

		boneVisualizer.Joint1 = joint1;
		boneVisualizer.Joint2 = joint2;

		Context parentContext = transform.GetComponentInParent<Context>();

		if (parentContext != null)
		{
			parentContext.Container.Inject(joint1);
			parentContext.Container.Inject(joint2);
			parentContext.Container.Inject(bone);
		}
		else
		{
			DiContainer sceneContext = ProjectContext.Instance.Container.Resolve<SceneContextRegistry>().GetContainerForScene(gameObject.scene);
			sceneContext.Inject(joint1);
			sceneContext.Inject(joint2);
			sceneContext.Inject(bone);
		}
	}

	// Update is called once per frame
	private void Update()
	{
		if (timeBeforeNextFlick > 0f)
		{
			timeBeforeNextFlick -= Time.deltaTime;
		}
		else
		{
			timeBeforeNextFlick = flickCooldown;

			// Generate random positive or negative force for x and y
			float x = (minXForce + Random.Range(0f, 1f) * (maxXForce - minXForce)) * (Random.value > 0.5f ? 1 : -1);
			float y = (minYForce + Random.Range(0f, 1f) * (maxYForce - minYForce)) * (Random.value > 0.5f ? 1 : -1);

			// Apply the calculated forces to joint1
			joint1.AddForce(new Vector2(x, y));
		}

		bone.Update();
		joint1.Update(Time.deltaTime);
		joint2.Update(Time.deltaTime);

		jointVisual1.position = joint1.Position;
		jointVisual2.position = joint2.Position;
	}
}