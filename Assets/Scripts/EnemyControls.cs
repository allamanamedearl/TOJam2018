using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour {

    public Trap Tv;
    public Trap Desk;
    public Trap Watercooler;
    public Trap Lamp;

    private string prevButtonTap;
    private Time lastTapTimeStamp;
    private float timeBetweenTaps;
    private int tapCount;

	// Use this for initialization
	void Start ()
    {
        Debug.Assert(Tv != null);
        Debug.Assert(Desk != null);
        Debug.Assert(Watercooler != null);
        Debug.Assert(Lamp != null);
    }
	
	// Update is called once per frame
	void Update ()
    {
        string currButton = "";
        if(Input.GetButtonDown("Fire1"))//A TV
        {
            currButton = "Fire1";
            Tv.ChangeAnimState(Trap.STATE_TRIGGER);
        }
        else if(Input.GetButtonDown("Fire2"))//B DESK
        {
            currButton = "Fire2";
            Desk.ChangeAnimState(Trap.STATE_TRIGGER);
        }
        else if (Input.GetButtonDown("Fire3"))//X WATERCOOLER
        {
            currButton = "Fire3";
            Watercooler.ChangeAnimState(Trap.STATE_TRIGGER);
        }
        else if (Input.GetButtonDown("Fire4"))//Y LAMP
        {
            currButton = "Fire4";
            Lamp.ChangeAnimState(Trap.STATE_TRIGGER);
        }

        if(currButton!="")//a button has been pressed
        {
            //if currButton == prevButton
            //    if within double tap time
            //        trigger
            //    else
            //        fakeOut
            //    set prevButton to ""
            //else if curr != prevButton
            //    prevButton = curr
            //    

            


        }

    }

   
}
