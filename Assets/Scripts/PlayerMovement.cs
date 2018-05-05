using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float Speed;
    public float JumpSpeed;
    private bool isJumping;
	// Use this for initialization
	void Start ()
    {
        isJumping = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        direction.x = Input.GetAxis("Horizontal");
		//if(Input.GetKey(KeyCode.LeftArrow))
  //      {
  //          direction.x = -1.0f;
  //      }
  //      if (Input.GetKey(KeyCode.RightArrow))
  //      {
  //          direction.x = 1.0f;
  //      }
        if (/*Input.GetKeyDown(KeyCode.Space) || */Input.GetButtonDown("Jump") &&!isJumping)
        {
            //direction.y = 1.0f;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpSpeed),ForceMode2D.Impulse);
            isJumping = true;
        }
        
        transform.Translate(direction * Speed * Time.deltaTime);
        
        
    }

    public void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Platform" && isJumping)
        {
            isJumping = false;
        }
    }
}
