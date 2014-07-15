using UnityEngine;
using System.Collections;

public class PastequeBehaviour : MonoBehaviour {



	bool grounded = false;
	float groundRadius = 0.2f;
	int alea = 0;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float jumpForce = 225f;


	// Use this for initialization
	void Start () {
		}

	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		alea = Random.Range (0, 100);

	}
	
	// Update is called once per frame
	void Update () {
		if (grounded  && (alea == 0)) {
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
		}
	}	

}
