// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;
using Zenject;

public class FlickStick : MonoBehaviour
{
	[Header("Flick")]
	[SerializeField]
	private float flickCooldown = 2f;

	[SerializeField]
	private float maxXForce = 10.0f;

	[SerializeField]
	private float maxYForce = 10.0f;

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
		joint2 = new ThingJoint(transform.position + new Vector3(0, -1, 0));
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
			joint1.AddForce(new Vector2(Random.Range(-maxXForce, maxXForce), Random.Range(-maxYForce, maxYForce)));
		}

		bone.Update();
		joint1.Update(Time.deltaTime);
		joint2.Update(Time.deltaTime);

		jointVisual1.position = joint1.Position;
		jointVisual2.position = joint2.Position;
	}
}