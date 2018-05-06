using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
    
    //Animation stuff
    public const int STATE_IDLE = 0;
    public const int STATE_FAKEOUT = 1;
    public const int STATE_TRIGGER = 2;

    private int currentAnimState;
    // Use this for initialization
    void Start ()
    {
        currentAnimState = STATE_IDLE;

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeAnimState(int state)
    {
        if (currentAnimState == state)
            return;
        Animator anim = GetComponent<Animator>();
        Debug.Assert(anim != null);
        if (anim != null)
        {
            anim.SetInteger("state", state);
            currentAnimState = state;
            Debug.Log("State is " + state);
        }

    }
}
