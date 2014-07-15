using UnityEngine;
using System.Collections;

public class KunaiBehaviour : MonoBehaviour {

	public float maxSpeed = 20f;
	public float direction = 1f;

	int i;

	// Use this for initialization
	void Start () {

	}
	

	void FixedUpdate () {

		rigidbody2D.velocity = new Vector2 (direction * maxSpeed, rigidbody2D.velocity.y);

		if (i >= 100 && maxSpeed != 0) {

			maxSpeed -= 0.5f;
			rigidbody2D.gravityScale += 0.5f;

			if (maxSpeed < 0)
				maxSpeed = 0;
		}
		else
			i++;

		if (maxSpeed == 0)
			Destroy (gameObject, 6);
	
	}
}
