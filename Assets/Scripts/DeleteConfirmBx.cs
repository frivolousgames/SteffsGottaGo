using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteConfirmBx : MonoBehaviour
{
    public GameObject confirmBox;
    public GameObject cheatButton;

    public GameObject sound;

    public void OpenConfirmBox()
    {
        confirmBox.SetActive(true);
    }

    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
        confirmBox.SetActive(false);
        Instantiate(sound, null);
        if(cheatButton.activeInHierarchy == true)
        {
            cheatButton.SetActive(false);
        }
        StartCoroutine(ResetWait());
    }

    IEnumerator ResetWait()
    {
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("LevelSelect");
    }
    public void CloseBox()
    {
        confirmBox.SetActive(false);
    }
}
