using UnityEngine;
using System.Collections;

// A lire uniquement y'a que Zooff qui modifie les controles, pas de zqsd et autres truc foireux :p
// Playercontrol : Script qui permet le déplacement, l'attaque, et tout autres bordel relatifs aux controles du joueurs, démarre aussi les animations.



public class Playercontrol : MonoBehaviour {
	
	//  Variable du mouvement
	public float maxSpeed = 10f;
	bool facingRight = true;

	Animator anim;


	// Variable du Saut
	bool grounded = false;
	bool doubleJump = false;
	float groundRadius = 0.2f;
	public Transform groundCheck;
	public Transform trans;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;



	void Start()
	{
		anim = GetComponent<Animator> ();

		// Je me sers de la variable trans pour éviter qu'Unity rappelle en boucle la fonction Getcomponent lors de l'utilisation de transform.position
		trans = gameObject.GetComponent<Transform> ();
	}

	// Plus intéressant qu'Update simple car force le code sans attendre la frame. 
	void FixedUpdate()
	{
		// Dis si le Player est collé au sol ou non
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		if (grounded)
			doubleJump = false;

		// Récupération du mouvement
		float move = Input.GetAxis("Horizontal");

		//Lancement de l'animation
		 anim.SetFloat("Speed", Mathf.Abs (move));

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);



		if (move > 0 && !facingRight && grounded)
						Flip ();
		else if (move < 0 && facingRight && grounded)
						Flip ();

	}

	void Update()
	{
				if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.UpArrow)) {
						rigidbody2D.AddForce (new Vector2 (0, jumpForce));
						if (!doubleJump && !grounded)
								doubleJump = true;
				}


		var rightBorder = (Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 1)).x) - 0.5f;

		if (trans.position.x > rightBorder)
						trans.position = trans.position;
		}

	// Fait tourner le personnage vers la direction du mouvement ! Ne s'éxecute pas en l'air.
	void Flip()
	{
				facingRight = !facingRight;

				Vector3 TheScale = transform.localScale;
				TheScale.x *= -1;
				transform.localScale = TheScale;
		}
}


	
