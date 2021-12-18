using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public abstract class ObstacleController : MonoBehaviour
{
    protected GameObject player;
    protected MonoBehaviour playerController;
    protected Rigidbody2D rb;

    protected Animator playerAnim;
    protected Animator anim;

    protected Collider2D col;

    protected bool hit;

    public float speed;

    protected GameObject groanWave;

    public GameObject explosion;
    public GameObject screenSpatter;

    protected GameObject mainCamera;
    protected GameObject mainCanvas;

    public GameObject destroySmoke;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            PlayerController.hit = true;
            SurivialPlayerController.hit = true;
            hit = true;
            col.enabled = false;
            //anim.SetTrigger("hit");
        }
        if(other.gameObject == groanWave)
        {
            //Instantiate(spatter, new Vector2(Random.Range(cam.gameObject.transform.position.x - 1.2f, cam.gameObject.transform.position.x + 1.2f), Random.Range(-.2f, .2f)), new Quaternion(0f, 0f, Random.Range(0, 360), 1), canvas.transform);
            Instantiate(screenSpatter, new Vector2(Random.Range(mainCamera.gameObject.transform.position.x - 1.2f, mainCamera.gameObject.transform.position.x + 1.2f), Random.Range(-.2f, .2f)), new Quaternion(0f, 0f, Random.Range(0, 360), 1), mainCanvas.transform);
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity, mainCamera.transform);
            Destroy(gameObject);
        }
    }

    /*public virtual IEnumerator FadeOut()
    {
        float faded = .03f;
        foreach(SpriteRenderer s in sr)
        {
            while (s.color.a > 0)
            {
                s.color = new Color(s.color.r, s.color.g, s.color.b, s.color.a - faded);
                Debug.Log("Fading");
                yield return null;
            }
        }
        Destroy(gameObject);
    }*/

    public virtual void DestroyAtEnd()
    {
        if(SceneManager.GetActiveScene().name != "Survival")
        {
            if (TimerController.counting == false || MainSceneController.won == true || MainSceneController.popActive == true)
            {
                Instantiate(destroySmoke, transform.position, Quaternion.identity, mainCamera.transform);
                Destroy(gameObject);
            }
        }
        else
        {
            if (SurvivalTimer.counting == false)
            {
                Instantiate(destroySmoke, transform.position, Quaternion.identity, mainCamera.transform);
                Destroy(gameObject);
            }
        }
    }
}
