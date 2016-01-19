using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;   
    public static GameManager Instance { get { return _instance; } } 
    
    public List<GameObject> levelChunkPrefabs;  //List of potential chunks to spawn
    public List<GameObject> activeChunks;       //"bucket 1" instantiate them from the game manager
    public List<GameObject> disabledChunks;     //"bucket 2" already in the scene and put in the Disabled list from the Inspector

    public int startingChunks;
    public float firstChunkXPos;
    public float xDistanceBetweenChunks;


    public Text restartText;
    public Text scoreText; 
    public Text gameOverText; 

    //public GUIText ScoreText;
    public int score;

    //public Pickup pickupScript;

    private bool gameOver;

    void Start()
    {
        gameOver = false;
//        restartText.text = "";
//       gameOverText.text = "";
        score = 0;

    }

    public void GameOver()
    {
        gameOver = true;
    }

    public void Awake() //initializing the two lists (bucket 1 and bucket 2) 
    {
        _instance = this;   

        activeChunks = new List<GameObject>();
        disabledChunks = new List<GameObject>();

        foreach (GameObject chunk in levelChunkPrefabs){    //for however many chunks we need to have, create one. (all at once the first time)
            for (int i = 0; i < startingChunks; ++i)
            {
                CreateChunk(chunk);     //for every potential piece... we probably don't need more than 3 of every piece... for reach one of these, spawn three
            }
        }

        ActivateChunk(Vector3.right * firstChunkXPos); //Vector3.right is (1,0,0). 
        GetNewChunk();  //call two more times to put two more pieces to the right of each procedurally generated level chunk
        GetNewChunk();
        GetNewChunk();
        GetNewChunk();
        GetNewChunk();
        GetNewChunk();
    }


    public void GetNewChunk()   //code for finding the chunk farthest to the right.
    {
        GameObject RightmostChunk = null;
        foreach (GameObject chunk in activeChunks)
        {
            //if there is nothing here, automatically set this chunk to be the rightmost chunk. 
            if (RightmostChunk == null || chunk.transform.position.x > RightmostChunk.transform.position.x)
            {
                RightmostChunk = chunk;
            }
        }
        ActivateChunk(RightmostChunk.transform.position + Vector3.right * xDistanceBetweenChunks);
    }

    public void ActivateChunk(Vector3 pos){   //looks at the list of disabled chunks and randomly picks one to take out of the disabled list and put into the active list
        GameObject chunk = disabledChunks[UnityEngine.Random.Range(0, disabledChunks.Count)];
        activeChunks.Add(chunk);
        disabledChunks.Remove(chunk);
        //THE LEVEL CHUNKS ARE POSITIONED USING THE LINE BELOW
        chunk.transform.position = pos;
        //Debug.Log(chunk.transform.position);
        chunk.SetActiveRecursively(true);  //enables and properly positions the chunk. 
        chunk.GetComponent<ScrollinLevelChunk>().bReady = true;
        //Debug.Log(pos);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Physics2D.gravity = -Physics2D.gravity;
        }
    }

    public void CreateChunk(){      //randomly picks from the list of prefabs. 
        CreateChunk(levelChunkPrefabs[UnityEngine.Random.Range(0, levelChunkPrefabs.Count)]);
    }

    public void CreateChunk(GameObject template)    //or specifically sends in a prefab
    {
        GameObject chunk = (GameObject)Instantiate(template);
        chunk.transform.parent = transform; //parents the chunk to the Game Manager (all the chunks are its children)
        chunk.SetActive(false);
        disabledChunks.Add(chunk);
    }

    public void DisableChunk(GameObject chunk)  //we're gonna send in a game object
    {
        //opposite of activate chunk
        chunk.SetActive(false);
        activeChunks.Remove(chunk); //remove is a function of a list, which activeChunks is

        //if the name of the active chunk is not Level Beginning, add to disabled chunk list
        if (chunk.name != "LevelBeginning")
        {
            disabledChunks.Add(chunk); //so is add
        }
        
        //every time one goes away, we know that we immediately need to spawn a new one from the disabled chunks function. 
        GetNewChunk();
    }

    //This function will set the text property of the ScoreText component to the string
    // "Score :" plus whatever our current score value is, held by our score variable. 
    // This feeds our score value to our GUI text component. 
    //void UpdateScore()
    //{
        //ScoreText.text = "Score: " + score;
    //}
    //THIS SCORING CODE HAS BEEN MOVED TO THE PICKUP CLASS.
}
