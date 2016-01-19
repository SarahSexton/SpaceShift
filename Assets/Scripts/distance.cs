using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
	public Text metersText;
	//public Text metersFinal;
    public float distanceIncrement = 5;

	public float meters;

	// Update is called once per frame
	void Update () {
        if (metersText != null)
        {
            meters += (distanceIncrement * Time.deltaTime);
            metersText.text = meters.ToString("F2") + "m";
        }
	}
}
