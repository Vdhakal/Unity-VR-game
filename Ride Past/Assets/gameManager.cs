using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {
    public GameObject obstaclePrefab;
    public GameObject explosion;
    public Player player;
    public float stayTimer = 5f;
    public float spawnDistanceFromPlayer = 20f;
    public float spawnDistanceFromObstacles = 5f;
    public TextMesh[] infoTexts;
    public Text text;
    private float gameTimer = 0f;
    private float distance = 0f;
    private float score;
    private float obstaclePointer;
    private float finalTime;
    private bool isGameOver = false;
    private float gameOverTimer = 3f;
    private bool startGameOverTimer=false;

    // Use this for initialization
    void Start () {
        for(int i = 0; i < infoTexts.Length; i++)
            {
            if (i == 0)
            {
                infoTexts[i].text = "" + (int)player.chancesRemaining;
            }
            else if (i == 1)
            {
                infoTexts[i].text = "DISTANCE " + Mathf.Round((distance / 100));
            }

        }
    }
	
	// Update is called once per frame
	void Update () {
        
        if (obstaclePointer < player.transform.position.z)
        {
            obstaclePointer += spawnDistanceFromObstacles;

            GameObject obstacleObject = Instantiate(obstaclePrefab);
            obstacleObject.transform.position = new Vector3
                (Random.Range(-4f, 4f),
                    1.5f,
                  player.transform.position.z + spawnDistanceFromPlayer
                );
            if (player.transform.position.x == 5f || player.transform.position.x == -5f)
            {
                stayTimer -= Time.deltaTime * 50;
                if (stayTimer <= 0)
                {
                    obstacleObject.transform.position = new Vector3
                    (player.transform.position.x,
                        1.5f,
                      player.transform.position.z + spawnDistanceFromPlayer
                    );
                    stayTimer = 5f;
                }

            }
            else {
                stayTimer = 5f;
            }
            
            distance += player.transform.position.z;
            gameTimer += Time.deltaTime;
            score = distance / gameTimer;
            text.text = "Score: " + (int)(score / 10);
            for (int i = 0; i < infoTexts.Length; i++)
            {
                if (i == 0)
                {
                    infoTexts[i].text = ""+(int)player.chancesRemaining;
                }
                else if (i == 1)
                {
                    infoTexts[i].text = "DISTANCE " + Mathf.Round((distance / 100));
                }
                
            }
            Debug.Log(stayTimer);
        }
        if (gameTimer > 10f)
        {
            GameObject gb = Instantiate(explosion);
            gb.transform.position = obstaclePrefab.transform.position;
        }
        if (!isGameOver)
        {
            if (player.chancesRemaining == 0)
            {
                Debug.Log(SceneManager.GetActiveScene().name);
                isGameOver = true;
                finalTime = gameTimer;
            }
        }
        else
        {
            gameOverTimer -= Time.deltaTime;
            if (gameOverTimer < 0)
            {
                SceneManager.LoadScene("mainMenu");
                
            }
        }
        

    }
   
    }
