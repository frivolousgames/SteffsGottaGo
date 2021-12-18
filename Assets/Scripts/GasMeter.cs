using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasMeter : MonoBehaviour
{
    public Slider gasMeter;

    public static bool gasUsed;

    public GameObject beans;

    private void Awake()
    {
        //gasMeter = GetComponent<Slider>();
    }

    private void Start()
    {
        
        if (gasMeter.gameObject.activeInHierarchy == true)
        {
            beans.SetActive(true);
        }
    }

    public void DrainGas()
    {
        if(gasMeter.gameObject.activeInHierarchy == true)
        {
            StartCoroutine("DrainGasWait");
        }
    }

    IEnumerator DrainGasWait()
    {
        yield return new WaitForSeconds(.25f);
        while(Input.GetMouseButton(0) == true && gasMeter.value > 0f && PlayerController.isGrounded == false)
        {
            gasUsed = true;
            gasMeter.value -= .0035f;
            yield return null;
        }
        gasUsed = false;
    }

    /*void RandomNums()
    {
        List<int> nums = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        for(int i = 1; i < 17; i++)
        {
            int x = nums[Random.Range(0, nums.Count)];
            nums.Remove(x);
            print(x);
        }
    }*/
}
