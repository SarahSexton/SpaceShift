using UnityEngine;
using System.Collections;

//This script acts as a dead zone, so when the Player hits it, the level is reloaded.
public class Respawn : MonoBehaviour
{
    public Animator anim;					// The animator that controls the characters animations

	//This method is called when an object (with RigidBody2D and Collider2D) collides with this
	void OnTriggerEnter2D(Collider2D collider)
	{
        Debug.Log("Collision occurred");
		// If the player was the one who collided
		if(collider.gameObject.tag == "Laser" || collider.gameObject.tag == "OutOfBounds") 
		{
            // Start coroutine
            StartCoroutine(WaitToDieRoutine());
                //WaitToDieRoutine();
            
		}
	}

    //Use a coroutine to make the game wait while she gets shocked
    IEnumerator WaitToDieRoutine()
    {
        anim.SetTrigger("Shock");
        //Stop the scrolling levels from moving and wait 

        foreach( ScrollinLevelChunk chunk in GameObject.FindObjectsOfType<ScrollinLevelChunk>() )
        {
            chunk.bReady = false;
            chunk.rigidbody2D.velocity = Vector3.zero;
        }

        yield return new WaitForSeconds( 0.5f ); //this is the line that makes the wait happen
        //Destroy(gameObject);
        
        Application.LoadLevel("endmenu");
        rigidbody2D.velocity = Vector3.zero;
    }
}