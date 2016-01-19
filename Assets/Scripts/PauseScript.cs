using UnityEngine;

public class PauseScript : MonoBehaviour
{
	float timeScale;
	bool isPaused = false;

	void Awake()
	{
		timeScale = Time.timeScale;
	}

	public void TogglePause()
	{
		if (isPaused)
			Time.timeScale = timeScale;
		else
			Time.timeScale = 0f;

		isPaused = !isPaused;
	}
}
