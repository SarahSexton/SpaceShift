using UnityEngine;

public class died : MonoBehaviour
{
	public Animator childAnimtor;
	public GameObject endMenu;
	public GameObject inGameDisplay;

	void OnTriggerEnter2D(Collider2D col)
	{
		childAnimtor.SetTrigger("died");
		endMenu.SetActive(true);
		inGameDisplay.SetActive(false);
	}
}
