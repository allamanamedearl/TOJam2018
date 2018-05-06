using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
    
    public enum TrapType
    {
        TV,
        DESK,
        LAMP,
        WATERCOOLER
    }
    public float ResetTrapTime;
    public TrapType CurrTrap;
    public float TvFallSpeed;

    public GameObject Projectile;

    public PolygonCollider2D[] LampColliders;
    public BoxCollider2D[] DeskColliders;
    //Animation stuff
    public const int STATE_IDLE = 0;
    public const int STATE_FAKEOUT = 1;
    public const int STATE_TRIGGER = 2;

    private int currentAnimState;
    private bool isTVFalling;
    private Vector3 startPos;
    // Use this for initialization
    void Start ()
    {
        currentAnimState = STATE_IDLE;
        isTVFalling = false;
        startPos = transform.position;

    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void UpdateColliders(int frameNum)
    {
        if(CurrTrap == TrapType.LAMP)
        {
            PolygonCollider2D mainColl = GetComponent<PolygonCollider2D>();

            mainColl.SetPath(0, LampColliders[frameNum].GetPath(0));
        }
        else if(CurrTrap == TrapType.DESK)
        {
            BoxCollider2D mainColl = GetComponent<BoxCollider2D>();
            if(DeskColliders.Length>0)
            {
                mainColl.size = DeskColliders[frameNum].size;
                mainColl.offset = DeskColliders[frameNum].offset;
            }
            
        }
       
    }

    public void ChangeAnimState(int state)
    {
        Debug.Log(gameObject.name + " currState " + currentAnimState + " state" + state);
        if (currentAnimState == state)
            return;
        Animator anim = GetComponent<Animator>();
        Debug.Assert(anim != null);
        if (anim != null)
        {
            if(state == STATE_TRIGGER)
            {
                //special exception bc broken anim doesn't play until tv hits the ground
                if(CurrTrap == TrapType.TV &&!isTVFalling)
                {
                    DropTV();
                    return;
                }               
            }
            anim.SetInteger("state", state);
            currentAnimState = state;
            Debug.Log("State is " + state);
        }

    }

    private void DropTV()
    {
        isTVFalling = true;
        Debug.Log("DROP TV");
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -TvFallSpeed), ForceMode2D.Impulse);
    }

    public void OnCollisionEnter2D(Collision2D c)
    {
        string cTag = c.gameObject.tag;
        if (cTag != "Player" && cTag != "Trap" && cTag != "Platform")
            return;

        if (CurrTrap == TrapType.WATERCOOLER)
            return;//only projectiles kill player

        if (CurrTrap == TrapType.TV && isTVFalling)
        {
            //show broken tv anim
            ChangeAnimState(STATE_TRIGGER);
            Destroy(GetComponent<Rigidbody2D>());
            
        }
        else if(CurrTrap == TrapType.DESK)
        {

        }

        if (c.gameObject.tag == "Player" && currentAnimState == STATE_TRIGGER)
        {
            //player dead
            Debug.Log("Player dead");
            //inform player of death
        }

        StartCoroutine("ResetTrap");


    }

    public void SpawnProjectile()
    {
        Transform child = gameObject.GetComponentInChildren<Transform>();
        Instantiate(Projectile, child.position, child.rotation);
    }

    IEnumerator ResetTrap()
    {
        Debug.Log("Started Reset Trap Coroutine");
        yield return new WaitForSeconds(ResetTrapTime);
        transform.position = startPos;
        //fuck it for some reason currAnimState is already idle so it skips setting the anim to idle for realsies
        //Animator anim = GetComponent<Animator>();
        //anim.SetInteger()
        ChangeAnimState(STATE_IDLE);
        if(CurrTrap==TrapType.TV)
        {
            isTVFalling = false;
        }

    }
}
