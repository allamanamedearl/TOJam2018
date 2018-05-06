﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AnimationEvent(int frameNum)
    {
        GetComponent<Trap>().UpdateColliders(frameNum);
    }

    public void AnimationEnd()
    {
        GetComponent<Trap>().StartCoroutine("ResetTrap");
    }
}
