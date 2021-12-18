using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiyWalkLegsController : MonoBehaviour
{
    public Animator legOneAnim;
    public Animator legTwoAnim;

    private void OnEnable()
    {
        legTwoAnim.Play("legAnim", 0, .5f);
    }

}
