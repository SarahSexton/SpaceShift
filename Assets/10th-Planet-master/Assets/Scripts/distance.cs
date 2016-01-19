using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class distance : MonoBehaviour {

	public Text metersText;
	public Text metersFinal;
    public float meters;
    public float distanceIncrement = 5;

	// Update is called once per frame
	void Update () {
        if (metersText != null)
        {
            meters += (distanceIncrement * Time.deltaTime);
            metersText.text = meters.ToString("F2") + "m";
        }
	}
}
