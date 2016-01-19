using UnityEngine;
using System.Collections;

public class ScrollinLevelChunk : MonoBehaviour {

    public int movementSpeed;	// The vertical speed of the movement
    public bool bReady;
    public float xRespawnPos;

    void FixedUpdate()
    {
        if (bReady)
        {
            rigidbody2D.velocity = new Vector2(movementSpeed, rigidbody2D.velocity.y);
        }

        //call game manager to disable and add back to resource pool which is disabledChunks
        if (transform.position.x < xRespawnPos)
        {
            GameManager.Instance.DisableChunk(gameObject);
        }   
    }
}
