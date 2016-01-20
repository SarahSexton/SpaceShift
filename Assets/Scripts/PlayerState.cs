using UnityEngine;

//This script destroys an object when the player picks it.(collides with it).
public class PlayerState : MonoBehaviour
{
	[SerializeField] ScoreManager scoreManager;

    Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
		scoreManager.PlayerStarted();
	}

	//This method is called when an object (with RigidBody2D and Collider2D) collides with this
	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player collided with a fuel can
		if(col.tag == "Can")
		{
			col.gameObject.SetActive (false);
			scoreManager.AddScore(1f);
		}
        
        // If the player collided with a laser
        if(col.tag == "Laser" || col.tag == "OutOfBounds")
        {
			anim.SetTrigger("Shock");
			scoreManager.PlayerDied();
        }
	}
}

