using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroanMeterController : MonoBehaviour
{
    Slider groanMeter;

    public float rechargeSpeed;

    public GameObject oFace;
    public GameObject groanWave;

    public Animator groanBarAnim;
    public bool isRecharging;

    private void Awake()
    {
        groanMeter = GetComponent<Slider>();
        isRecharging = false;
    }

    private void Update()
    {
        groanBarAnim.SetBool("isRecharging", isRecharging);
        IsRecharging();
        //Debug.Log("Recharging: " + isRecharging);
    }

    public void Groan()
    {
        if(PlayerController.isHit == false && CameraMover.isMoving == true)
        {
            if (groanMeter.value == 100)
            {
                groanWave.SetActive(true);
                groanMeter.value = 0;
                oFace.SetActive(true);
                StartCoroutine("DeactivateOFace");
                isRecharging = true;
                StartCoroutine("Recharge");
            }
        }
    }

    IEnumerator DeactivateOFace()
    {
        yield return new WaitForSeconds(.3f);
        oFace.SetActive(false);
    }

    IEnumerator Recharge()
    {
        while(isRecharging == true)
        {
            groanMeter.value += rechargeSpeed * Time.deltaTime;
            yield return null;
        }
    }

    void IsRecharging()
    {
        if (TimerController.counting == true)
        {
            if (groanMeter.value < 100)
            {
                isRecharging = true;
            }
            else
            {
                isRecharging = false;
            }
        }
        else
        {
            isRecharging = false;
        }
    }
}
