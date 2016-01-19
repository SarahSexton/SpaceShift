using UnityEngine;
using UnityEngine.EventSystems;

//This script  makes the character move when the screen is pressed and handles the jump
public class CharacterMovement : MonoBehaviour
{
	Animator anim;                  // The animator that controls the characters animations
	const float gravity = -9.81f;


	void Awake()
	{
		anim = GetComponent<Animator>();
		Physics2D.gravity = new Vector2(0f, gravity);
	}

	//The update method is called many times per second
	void Update()
	{
		if(Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject())
		{
            //Inverting the gravity 
            Physics2D.gravity = -Physics2D.gravity;

            anim.SetTrigger("Flip");
			transform.localScale = new Vector3(transform.localScale.x, 
				-transform.localScale.y, 
				transform.localScale.z);
		}
	}
}
