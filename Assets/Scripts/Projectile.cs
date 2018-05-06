using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float Speed;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5.0f);
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;	
	}
    public void OnCollisionEnter2D(Collision2D c)
    {
        string cTag = c.gameObject.tag;

        if (cTag == "Player" || cTag == "Trap" || cTag == "Platform")
        {
            if(cTag == "Player")
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<PlayerMovement>().KillPlayer();
            }
            Destroy(gameObject);
        }
    }
}
