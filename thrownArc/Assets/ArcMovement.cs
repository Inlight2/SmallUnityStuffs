using UnityEngine;
using System.Collections;

public class ArcMovement : MonoBehaviour {

	[SerializeField] float initialVerticalVelocity = 0.5f;
	[SerializeField] float horizontalDistance = 30;
	[SerializeField] float verticalOffset = 0;

	[SerializeField] const float GRAVITY = 0.01f;

	void Awake () {
		StartCoroutine (ArcMoveUpdate ());
	}

	IEnumerator ArcMoveUpdate() {
		float originY = transform.localPosition.y;
		float targetY = originY + verticalOffset;
		int gravTicks = 0;
		float verticalVelocity = initialVerticalVelocity;

		for (float y = originY; y > targetY || verticalVelocity >= 0; gravTicks++) {
			y += verticalVelocity;
			verticalVelocity -= GRAVITY;
		}

		verticalVelocity = initialVerticalVelocity;
		float horizontalSpeed = (float) horizontalDistance / gravTicks;
		while (transform.localPosition.y > targetY || verticalVelocity >= 0) {
			transform.localPosition = new Vector3 (transform.localPosition.x + horizontalSpeed,
			                                       transform.localPosition.y + verticalVelocity,
			                                       transform.localPosition.z);
			verticalVelocity -= GRAVITY;

			yield return null;
		}
	}
}
