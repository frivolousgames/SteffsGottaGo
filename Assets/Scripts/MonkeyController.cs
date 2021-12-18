using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour
{
    Animator anim;

    public bool isCocked;

    public GameObject poop;
    public Transform poopSpawn;

    public GameObject screech;
    public GameObject chuckle;
    GameObject chucklePrefab;

    GameObject mainCam;

    bool throwTime;
    public float throwWait;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        throwTime = true;
    }

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        anim.SetBool("isCocked", isCocked);
        if(isCocked == true)
        {
            if(ThrowReady() == false)
            {
                isCocked = false;
                throwTime = true;
            }
        }
    }

    public void Cock()
    {
        if(throwTime == true && ThrowReady() == true)
        {
            throwTime = false;
            isCocked = true;
            chucklePrefab = Instantiate(chuckle, null);
        }  
    }

    IEnumerator ThrowWait()
    {
        yield return new WaitForSeconds(throwWait);
        throwTime = true;
    }

    public void Throw()
    {
        if(isCocked == true && ThrowReady() == true)
        {
            isCocked = false;
            if (chucklePrefab != null)
            {
                Destroy(chucklePrefab);
            }
            Instantiate(screech, null);
            StartCoroutine("ThrowWait");
        }
    }

    public void PoopSpawn()
    {
        Instantiate(poop, poopSpawn.position, poopSpawn.rotation, mainCam.transform);
    }

    bool ThrowReady()
    {
        if(PlayerController.isHit == false && PlayerController.hit == false && TimerController.counting == true && CameraMover.isMoving == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
