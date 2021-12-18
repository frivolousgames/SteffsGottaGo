using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusController : MonoBehaviour
{
    public GameObject bonusTextObj;
    GameObject bonusPrefab;
    string bonusText;

    public Transform canvas;

    public AudioSource sound;

    public void SpawnBonusText()
    {
        StartCoroutine(SpawnWait());
    }

    IEnumerator SpawnWait()
    {
        yield return new WaitForSeconds(.2f);
        bonusText = MainSceneController.bonusText;
        bonusPrefab = Instantiate(bonusTextObj, canvas);
        bonusPrefab.GetComponentInChildren<Text>().text = bonusText;
        Instantiate(sound, null);
    }
   
}
