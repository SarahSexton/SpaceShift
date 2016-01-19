using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This script  makes the character move when the screen is pressed and handles the jump
public class CharacterFinal : MonoBehaviour
{
	//public bool jump = false;				// Condition for whether the player should jump.	
	public float jumpForce = 5.0f;			// Amount of force added when the player jumps.
	private bool grounded = false;			// Whether or not the player is grounded.
	public int movementSpeed = 100;			// The vertical speed of the movement
	private Animator anim;					// The animator that controls the characters animations

	void Awake()
	{
		anim = GetComponent<Animator>();
        transform.localScale = new Vector3(1, 1, 1);
        Physics2D.gravity = new Vector2(0f, -Mathf.Abs(Physics2D.gravity.y));
	}
	

	//This method is called when the character collides with a collider (could be a platform).
	void OnCollisionEnter2D(Collision2D hit)
	{
		grounded = true;
		print ("isground");
	}

	//The update method is called many times per second
	void Update()
	{
		if(Input.GetButtonDown("Fire1"))
		{
            //Inverting the gravity 
            Physics2D.gravity = -Physics2D.gravity;

            //Inverting the character's sprite's local scale on the Y axis 
            //transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);

            anim.SetTrigger("Flip");

            Invoke("FlipCharacterSprite", 0.2f);
		}
	}

    void FlipCharacterSprite()
    {
        //Inverting the character's sprite's local scale on the Y axis 
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);


        
    }

	//Since we are using physics for movement, we use the FixedUpdate method
	void FixedUpdate ()
	{
		//if died that 
		rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y );
		//else
		//moving
		
		// If jump is set to true we add a quick force impulse for the jump
        //if(jump == true)
        //{
        //    // Add a vertical force to the player.
        //    rigidbody2D.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
			
        //    // We set the variable to false again to avoid adding force constantly
        //    jump = false;
        //}
	}
}
