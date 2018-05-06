using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour {

    public PlayerMovement Player;
	// Use this for initialization
	void Start ()
    {
		
	}
	

    public void OnCollisionEnter2D(Collision2D c)
    {
        Debug.Assert(Player != null);
        if(Player!=null)
        {
            Player.StopJumping();
        }
    }
}
