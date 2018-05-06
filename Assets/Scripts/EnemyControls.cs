using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour {

    public Trap Tv;
    public Trap Desk;
    public Trap Watercooler;
    public Trap Lamp;

    private string currButton;
    private string prevButtonTap;
    private Time lastTapTimeStamp;
    private float timeElapsed;
    private int timesTapped;
    private const float TIME_BETWEEN_TAPS = 0.5f;

    private bool routineTriggered;


	// Use this for initialization
	void Start ()
    {
        Debug.Assert(Tv != null);
        Debug.Assert(Desk != null);
        Debug.Assert(Watercooler != null);
        Debug.Assert(Lamp != null);

        timeElapsed = 0.0f;
        routineTriggered = false;
        timesTapped = 0;
        currButton = "";

    }
	
	// Update is called once per frame
	void Update ()
    {
        prevButtonTap = currButton;
        bool isPressed = false;
        if(Input.GetButtonDown("Fire1"))//A TV
        {
            currButton = "Fire1";
            isPressed = true;

        }
        else if(Input.GetButtonDown("Fire2"))//B DESK
        {
            currButton = "Fire2";
            isPressed = true;
        }
        else if (Input.GetButtonDown("Fire3"))//X WATERCOOLER
        {
            currButton = "Fire3";
            isPressed = true;
        }
        else if (Input.GetButtonDown("Fire4"))//Y LAMP
        {
            currButton = "Fire4";
            isPressed = true;
        }


        if (isPressed)//button has been pressed
        {
            timesTapped++;
            if(!routineTriggered)
            {
                routineTriggered = true;
                //do co routine
                StartCoroutine("SingleOrDoublePress");

            }
        }


    }

    IEnumerator SingleOrDoublePress()
    {
        yield return new WaitForSeconds(0.3f);
        if (timesTapped == 1)
        {
            Debug.Log("Tapped " + currButton + " once");
            if (currButton == "Fire1")
                Tv.ChangeAnimState(Trap.STATE_FAKEOUT);
            else if (currButton == "Fire2")
                Desk.ChangeAnimState(Trap.STATE_FAKEOUT);
            else if (currButton == "Fire3")
                Watercooler.ChangeAnimState(Trap.STATE_FAKEOUT);
            else if (currButton == "Fire4")
                Lamp.ChangeAnimState(Trap.STATE_FAKEOUT);
        }
        else if(timesTapped > 1)
        {
            Debug.Log("Tapped " + currButton + " " + prevButtonTap);
            if(currButton == prevButtonTap)
            {
                //double tap
                if(currButton == "Fire1")
                    Tv.ChangeAnimState(Trap.STATE_TRIGGER);
                else if (currButton == "Fire2")
                    Desk.ChangeAnimState(Trap.STATE_TRIGGER);
                else if (currButton == "Fire3")
                    Watercooler.ChangeAnimState(Trap.STATE_TRIGGER);
                else if (currButton == "Fire4")
                    Lamp.ChangeAnimState(Trap.STATE_TRIGGER);

            }
            else
            {
                if (prevButtonTap == "Fire1")
                    Tv.ChangeAnimState(Trap.STATE_FAKEOUT);
                else if (prevButtonTap == "Fire2")
                    Desk.ChangeAnimState(Trap.STATE_FAKEOUT);
                else if (prevButtonTap == "Fire3")
                    Watercooler.ChangeAnimState(Trap.STATE_FAKEOUT);
                else if (prevButtonTap == "Fire4")
                    Lamp.ChangeAnimState(Trap.STATE_FAKEOUT);

                if (currButton == "Fire1")
                    Tv.ChangeAnimState(Trap.STATE_FAKEOUT);
                else if (currButton == "Fire2")
                    Desk.ChangeAnimState(Trap.STATE_FAKEOUT);
                else if (currButton == "Fire3")
                    Watercooler.ChangeAnimState(Trap.STATE_FAKEOUT);
                else if (currButton == "Fire4")
                    Lamp.ChangeAnimState(Trap.STATE_FAKEOUT);

            }
        }
        routineTriggered = false;
        timesTapped = 0;

    }

   
}
