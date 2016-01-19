using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIManagerScript : MonoBehaviour {

    private Pickup pickupScript;
    public Text scoreText;
    private distance distanceScript;
    public Text distanceText;


    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            pickupScript = player.GetComponent<Pickup>();
            scoreText.text = pickupScript.score.ToString();
            distanceScript = GameObject.FindWithTag("Player").GetComponent<distance>();
            distanceText.text = distanceScript.meters.ToString("F2") + " M";

            //How to save high scores locally to player's computer
            //Only save highest score. Test to see if the new score is higher than all other scores
            float oldScore = PlayerPrefs.GetFloat("Cans");
            float newScore = pickupScript.score;

            float oldDistance = PlayerPrefs.GetFloat("Distance");
            float newDistance = distanceScript.meters;

            if(newScore > oldScore)
            {PlayerPrefs.SetFloat("Cans", pickupScript.score);}

            if (newDistance > oldDistance)
            {PlayerPrefs.SetFloat("Distance", distanceScript.meters);}
            
            PlayerPrefs.Save();

            //Print values
            Debug.Log(PlayerPrefs.GetFloat("Cans"));
            Debug.Log(PlayerPrefs.GetFloat("Distance"));
        }
        else
        {
            scoreText.text = PlayerPrefs.GetFloat("Cans").ToString();
            distanceText.text = PlayerPrefs.GetFloat("Distance").ToString();
        }
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

    public void PauseGame()
    {
        if (Time.timeScale == 1.0)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
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
