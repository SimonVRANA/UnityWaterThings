// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;
using Zenject;

public class FlickChain : MonoBehaviour
{
	[Header("Flick")]
	[SerializeField]
	private float flickCooldown = 5f;

	[SerializeField]
	private float minXForce = 100.0f;

	[SerializeField]
	private float maxXForce = 200.0f;

	[SerializeField]
	private float minYForce = 100.0f;

	[SerializeField]
	private float maxYForce = 200.0f;

	[Header("Links")]
	[SerializeField]
	private Transform jointVisual1;

	[SerializeField]
	private Transform jointVisual2;

	[SerializeField]
	private Transform jointVisual3;

	[SerializeField]
	private Transform jointVisual4;

	[SerializeField]
	private Transform jointVisual5;

	[SerializeField]
	private Transform jointVisual6;

	[SerializeField]
	private ThingBoneVisualizer boneVisualizer1;

	[SerializeField]
	private ThingBoneVisualizer boneVisualizer2;

	[SerializeField]
	private ThingBoneVisualizer boneVisualizer3;

	[SerializeField]
	private ThingBoneVisualizer boneVisualizer4;

	[SerializeField]
	private ThingBoneVisualizer boneVisualizer5;

	private ThingJoint joint1;
	private ThingJoint joint2;
	private ThingJoint joint3;
	private ThingJoint joint4;
	private ThingJoint joint5;
	private ThingJoint joint6;
	private ThingBone bone1;
	private ThingBone bone2;
	private ThingBone bone3;
	private ThingBone bone4;
	private ThingBone bone5;

	private float timeBeforeNextFlick = 0f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Start()
	{
		joint1 = new ThingJoint(transform.position);
		joint2 = new ThingJoint(transform.position + new Vector3(0, -1, 0));
		joint3 = new ThingJoint(transform.position + new Vector3(0, -2, 0));
		joint4 = new ThingJoint(transform.position + new Vector3(0, -3, 0));
		joint5 = new ThingJoint(transform.position + new Vector3(0, -4, 0));
		joint6 = new ThingJoint(transform.position + new Vector3(0, -5, 0));
		bone1 = new ThingBone(joint1, joint2);
		bone2 = new ThingBone(joint2, joint3);
		bone3 = new ThingBone(joint3, joint4);
		bone4 = new ThingBone(joint4, joint5);
		bone5 = new ThingBone(joint5, joint6);

		boneVisualizer1.Joint1 = joint1;
		boneVisualizer1.Joint2 = joint2;

		boneVisualizer2.Joint1 = joint2;
		boneVisualizer2.Joint2 = joint3;

		boneVisualizer3.Joint1 = joint3;
		boneVisualizer3.Joint2 = joint4;

		boneVisualizer4.Joint1 = joint4;
		boneVisualizer4.Joint2 = joint5;

		boneVisualizer5.Joint1 = joint5;
		boneVisualizer5.Joint2 = joint6;

		Context parentContext = transform.GetComponentInParent<Context>();

		if (parentContext != null)
		{
			parentContext.Container.Inject(joint1);
			parentContext.Container.Inject(joint2);
			parentContext.Container.Inject(joint3);
			parentContext.Container.Inject(joint4);
			parentContext.Container.Inject(joint5);
			parentContext.Container.Inject(joint6);
			parentContext.Container.Inject(bone1);
			parentContext.Container.Inject(bone2);
			parentContext.Container.Inject(bone3);
			parentContext.Container.Inject(bone4);
			parentContext.Container.Inject(bone5);
		}
		else
		{
			DiContainer sceneContext = ProjectContext.Instance.Container.Resolve<SceneContextRegistry>().GetContainerForScene(gameObject.scene);
			sceneContext.Inject(joint1);
			sceneContext.Inject(joint2);
			sceneContext.Inject(joint3);
			sceneContext.Inject(joint4);
			sceneContext.Inject(joint5);
			sceneContext.Inject(joint6);
			sceneContext.Inject(bone1);
			sceneContext.Inject(bone2);
			sceneContext.Inject(bone3);
			sceneContext.Inject(bone4);
			sceneContext.Inject(bone5);
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

		bone1.Update();
		bone2.Update();
		bone3.Update();
		bone4.Update();
		bone5.Update();

		joint1.Update(Time.deltaTime);
		joint2.Update(Time.deltaTime);
		joint3.Update(Time.deltaTime);
		joint4.Update(Time.deltaTime);
		joint5.Update(Time.deltaTime);
		joint6.Update(Time.deltaTime);

		jointVisual1.position = joint1.Position;
		jointVisual2.position = joint2.Position;
		jointVisual3.position = joint3.Position;
		jointVisual4.position = joint4.Position;
		jointVisual5.position = joint5.Position;
		jointVisual6.position = joint6.Position;
	}
}