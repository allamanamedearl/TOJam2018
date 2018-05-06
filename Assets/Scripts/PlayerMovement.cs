using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float Speed;
    public float JumpSpeed;
    private bool isJumping;

    //Animation stuff
    const int STATE_IDLE = 0;
    const int STATE_RUN = 1;
    const int STATE_JUMP = 2;
    const int STATE_DEATH = 3;

    private int currentAnimState;
    private string currDirection;

	// Use this for initialization
	void Start ()
    {
        isJumping = false;
        currentAnimState = STATE_IDLE;
        currDirection = "left";
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        direction.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") &&!isJumping)
        {
            //direction.y = 1.0f;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpSpeed),ForceMode2D.Impulse);
            isJumping = true;
            ChangeAnimState(STATE_JUMP);
        }

        if(!isJumping)
        {
            if (direction == Vector3.zero)
            {
                ChangeAnimState(STATE_IDLE);
            }
            else
            {
                if (direction.x < 0)//left
                {
                    ChangeDirection("left");           
                }
                else
                {
                    ChangeDirection("right");
                }

                ChangeAnimState(STATE_RUN);
            }
            
        }
               
        transform.position+=(direction * Speed * Time.deltaTime);        
        
    }

    private void ChangeAnimState(int state)
    {
        if (currentAnimState == state)
            return;
        Animator anim = GetComponent<Animator>();
        Debug.Assert(anim != null);
        if(anim!=null)
        {
            anim.SetInteger("state", state);
            currentAnimState = state;
            Debug.Log("State is " + state);
        }

    }

    private void ChangeDirection(string direction)
    {
        if (currDirection == direction)
            return;
        if(direction=="left")
        {
            transform.Rotate(0, 180, 0);
        }
        else
        {
            transform.Rotate(0, -180, 0);
        }
        currDirection = direction;
    }

    public void StopJumping()
    {

        isJumping = false;
    }
    //public void OnCollisionEnter2D(Collision2D c)
    //{

    //    if((c.gameObject.tag == "Platform" || c.gameObject.name == "Colliders") && isJumping)
    //    {
    //        isJumping = false;
    //    }
    //}
}
