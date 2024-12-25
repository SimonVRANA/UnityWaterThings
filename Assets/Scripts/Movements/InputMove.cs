// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using UnityEngine;
using UnityEngine.InputSystem;

public class InputMove : MonoBehaviour
{
	[SerializeField]
	private float speed = 1.0f;

	private Vector3 movementVetor3D = Vector3.zero;

	public void OnMove(InputValue movementValue)
	{
		Vector2 movementVector = movementValue.Get<Vector2>();

		movementVetor3D = new(movementVector.x, movementVector.y, 0);
	}

	private void Update()
	{
		transform.position += movementVetor3D * speed * Time.deltaTime;
	}
}
