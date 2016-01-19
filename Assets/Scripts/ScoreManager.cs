using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] Text scoreText;
	[SerializeField] Text distanceText;
	[SerializeField] float distanceIncrement = 5;
	[SerializeField] float deathDelay = 2f;

	bool isRunning = false;
	float score;
	float meters;
	

	void Start()
	{
		scoreText.text = "0";
		distanceText.text = "0 M";
	}

	void Update()
	{
		if (!isRunning)
			return;

		meters += (distanceIncrement * Time.deltaTime);
		distanceText.text = meters.ToString("F2") + " M";
	}

	public void AddScore(float amount)
	{
		score += amount;
		scoreText.text = score.ToString();
	}

	public void PlayerStarted()
	{
		isRunning = true;
	}

	public void PlayerDied()
	{
		isRunning = false;

		//score
		float oldScore = PlayerPrefs.GetFloat("Cans");
		if (score > oldScore)
			PlayerPrefs.SetFloat("Cans", score); 

		//meters
		float oldDistance = PlayerPrefs.GetFloat("Distance");
		if (meters > oldDistance)
			PlayerPrefs.SetFloat("Distance", meters);

		PlayerPrefs.Save();

		Invoke("LoadMenu", deathDelay);
	}

	void LoadMenu()
	{
		SceneManager.LoadScene("EndMenu");
	}
}
