// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;
using Zenject;

public class SelfPropelledThingJoint : MonoBehaviour
{
	[SerializeField]
	private float flickCooldown = 2f;

	[SerializeField]
	private float maxXForce = 100.0f;

	[SerializeField]
	private float maxYForce = 100.0f;

	private float timeBeforeNextFlick = 0f;

	private ThingJoint thingJoint;

	private void Start()
	{
		thingJoint = new ThingJoint(transform.position);

		Context parentContext = transform.GetComponentInParent<Context>();

		if (parentContext != null)
		{
			parentContext.Container.Inject(thingJoint);
		}
		else
		{
			DiContainer sceneContext = ProjectContext.Instance.Container.Resolve<SceneContextRegistry>().GetContainerForScene(gameObject.scene);
			sceneContext.Inject(thingJoint);
		}
	}

	private void Update()
	{
		if (timeBeforeNextFlick > 0f)
		{
			timeBeforeNextFlick -= Time.deltaTime;
		}
		else
		{
			timeBeforeNextFlick = flickCooldown;
			thingJoint.AddForce(new Vector2(Random.Range(-maxXForce, maxXForce), Random.Range(-maxYForce, maxYForce)));
		}

		thingJoint.Update(Time.deltaTime);
		transform.position = thingJoint.Position;
	}
}