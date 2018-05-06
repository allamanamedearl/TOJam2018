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
        if(Input.GetButtonDown("Fire1"))//A TV
        {
            Tv.ChangeAnimState(Trap.STATE_TRIGGER);
        }
        else if(Input.GetButtonDown("Fire2"))//B DESK
        {
            Desk.ChangeAnimState(Trap.STATE_TRIGGER);
        }
        else if (Input.GetButtonDown("Fire3"))//X WATERCOOLER
        {
            Watercooler.ChangeAnimState(Trap.STATE_TRIGGER);
        }
        else if (Input.GetButtonDown("Fire4"))//Y LAMP
        {
            Lamp.ChangeAnimState(Trap.STATE_TRIGGER);
        }

    }

   
}
