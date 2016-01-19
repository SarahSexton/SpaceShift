using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
	[SerializeField] Text scoreText;
	[SerializeField] Text distanceText;
	[SerializeField] float distanceIncrement = 5;
	[SerializeField] GameManager player;

	Distance distanceScript;

	//Pickup pickupScript;


    void Start()
    {
		if (!player)
		{
			scoreText.text = PlayerPrefs.GetFloat("Cans").ToString();
			distanceText.text = PlayerPrefs.GetFloat("Distance").ToString();
			return;
		}

       // pickupScript = player.GetComponent<Pickup>();
       // scoreText.text = pickupScript.score.ToString();
        distanceText.text = distanceScript.meters.ToString("F2") + " M";

        //How to save high scores locally to player's computer
        //Only save highest score. Test to see if the new score is higher than all other scores
        float oldScore = PlayerPrefs.GetFloat("Cans");
       // float newScore = pickupScript.score;

        float oldDistance = PlayerPrefs.GetFloat("Distance");
        float newDistance = distanceScript.meters;

       // if(newScore > oldScore)
       // {PlayerPrefs.SetFloat("Cans", pickupScript.score);}

        if (newDistance > oldDistance)
        {PlayerPrefs.SetFloat("Distance", distanceScript.meters);}
            
        PlayerPrefs.Save();

        //Print values
        Debug.Log(PlayerPrefs.GetFloat("Cans"));
        Debug.Log(PlayerPrefs.GetFloat("Distance"));

    }

	public void StartGame()
    {
        Destroy(GameObject.FindWithTag("Player"));
        Application.LoadLevel("InfiniteRunner009_W_GameOver");
    }

    public void ResetGame()
    {
        Destroy(GameObject.FindWithTag("Player"));
        Application.LoadLevel("MenuScene");
    }

    public void QuitGame()
    {
        Destroy(GameObject.FindWithTag("Player"));
        Application.Quit();
    }

    public void HighScoresScene()
    {
        Destroy(GameObject.FindWithTag("Player"));
        Application.LoadLevel("HighScoresScene");
    }

    

    //void Update()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {   
    //        Destroy(GameObject.FindWithTag("Player"));  //destroy character now
    //        Application.LoadLevel("InfiniteRunner009_W_GameOver");
    //    }
    //}

}
