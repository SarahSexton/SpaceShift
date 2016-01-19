using UnityEngine;
using System.Collections;

public class PositionLock : MonoBehaviour 
{
    private Vector3 _startPos;
	// Use this for initialization
	void Start () 
    {
        _startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
         Vector3 pos = gameObject.transform.position;
        pos.x = _startPos.x;
        gameObject.transform.position = pos;
	}
}
