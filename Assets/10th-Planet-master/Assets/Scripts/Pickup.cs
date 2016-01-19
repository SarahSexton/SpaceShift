using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This script destroys an object when the player picks it.(collides with it).
public class Pickup : MonoBehaviour
{

	public Text scoretext;						// The amount of cans we pick up
	public float score; 
	public Text scoretextfinal;
	//public GameObject particle ;
	//public AudioClip CollectSound ;
    private Animator anim;

    //on awake, when this script turns on, it marks this object "don't be destroyed." 
    //Use this to keep the character from being destroyed, for puroses of score keeping.
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //Destroy(this.gameObject);
    }

	//This method is called when an object (with RigidBody2D and Collider2D) collides with this
	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player collided with a fuel can
		if(col.gameObject.tag == "Can")
		{
            //particle = col.transform.FindChild("Sparks").gameObject;
            //particle.particleEmitter.emit = true;
            //Destroy the object(the one with this script attached) from the scene.	
			//Destroy (col.gameObject);

            //col.renderer.enabled = false;
			col.gameObject.SetActive (false);
            
			// give a score
			score++;
			scoretext.text = score.ToString();
            //if scoretext is not equal to null...
			//scoretextfinal.text = "" + score;
			//audio.PlayOneShot(CollectSound);
			//Instantiate (particle, col.transform.position, col.transform.rotation );

            //Debug.Log("Can picked up");
         // Debug.Log("score: " + score);
		}
        
        // If the player collided with a laser
        if(col.gameObject.tag == "Lasers")
            {
            anim.SetTrigger("Shock");
            }
	}
}

