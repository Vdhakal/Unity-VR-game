using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    private float waitTimer = 5f;
    public TextMesh infoText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       /* waitTimer -= Time.deltaTime;
        infoText.text = "Timer: "+(int)waitTimer;
        if (waitTimer <= 0)
        {
            Debug.Log("asda");
            SceneManager.LoadScene("Ride Past");
        }*/
	}
}
