using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenuScript : MonoBehaviour
{
	[SerializeField] Text distanceText;
	[SerializeField] Text scoreText;

	void Awake ()
	{
		float highScore = PlayerPrefs.GetFloat("Cans");
		float highDistance = PlayerPrefs.GetFloat("Distance");

		distanceText.text = highDistance + " M";
		scoreText.text = highScore.ToString();
	}

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

}
