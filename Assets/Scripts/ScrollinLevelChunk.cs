using UnityEngine;

public class ScrollinLevelChunk : MonoBehaviour
{
    public int movementSpeed;	// The vertical speed of the movement
    public bool bReady;
    public float xRespawnPos;

    void FixedUpdate()
    {
        if (bReady)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        //call game manager to disable and add back to resource pool which is disabledChunks
        if (transform.position.x < xRespawnPos)
        {
            GameManager.Instance.DisableChunk(gameObject);
        }   
    }
}
