using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour {
    public Player player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(
            0,
            0,
            player.transform.position.z*Time.deltaTime 
            );
        if (transform.position.z - player.transform.position.z > 100)
        {
            transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            player.transform.position.z +100
            );
        }
	}
}
