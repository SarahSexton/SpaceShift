using UnityEngine;
using UnityEngine.UI;

public class ScoreLoader : MonoBehaviour
{
	[SerializeField] Text scoreText;
	[SerializeField] Text distanceText;


	void Start ()
	{
		float score = PlayerPrefs.GetFloat("Cans");
		float meters = PlayerPrefs.GetFloat("Distance");

		scoreText.text = score.ToString();
		distanceText.text = meters.ToString("F2") + " M";
	}
}
