using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float acceleration = 0.5f;
    public float maxSpeed = 30f;
    public float chancesRemaining = 10f;
    private float speed = 0f;
    private float obstacleSlowdown = 0.4f;
    private float stayingInMaxSpeed = 0f;
    private float ultraMaxSpeed = 50f;
    void Start () {
		
	}


    void Update () {
        // accelerate the player
        speed += acceleration * Time.deltaTime;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
            stayingInMaxSpeed += Time.deltaTime;
        }

        if (stayingInMaxSpeed >= 1 )
        {
            speed += 1;
            maxSpeed += 1;
            stayingInMaxSpeed = 0;
        }
        if (maxSpeed > ultraMaxSpeed)
        {
            maxSpeed = ultraMaxSpeed;
        }
        Debug.Log("Speed: " + speed);
        // make player move
        Vector3 direction = new Vector3(
            transform.forward.x,
            0,
            transform.forward.z
            );
        transform.position += direction.normalized * Time.deltaTime * speed;

        if (transform.position.x < -5f)
        {
            transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 5f)
        {
            transform.position = new Vector3(5f, transform.position.y, transform.position.z);
        }
        if (transform.rotation.y > 49f)
        {
            
            
            transform.rotation = Quaternion.Euler(transform.rotation.x, 49f, transform.rotation.z);
            Debug.Log("wsadesadsa");
        }
        if (transform.rotation.y < -49f)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, -49f, transform.rotation.z);
        }

    }
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.tag =="Enemy" )
        {
            speed *= obstacleSlowdown;
            chancesRemaining -= 1;
            maxSpeed = 30f;
        }
    }
}
