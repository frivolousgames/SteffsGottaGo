using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ExtrasBoxController : MonoBehaviour
{
    //242 spawn pos

    public static bool isSwitching;
    string direction;
    bool switched;

    public Transform rightSpawnPos;
    public Transform leftSpawnPos;
    public Transform centerPos;
    Vector3 currentPos;
    Vector3 nextPos;


    public GameObject[] slides;
    public static int currentSlideIndex;
    public static int nextSlideIndex;

    public static GameObject currentSlide;
    public static GameObject nextSlide;

    public static GameObject slidePrefab;
    public static GameObject currentPrefab;

    public static float switchSpeed;

    public Transform slideParent;

    public GameObject toggle;
    Image toggleButton;

    public UnityEvent toggleOff;

    private void Awake()
    {
        toggleButton = toggle.GetComponent<Image>();
    }

    private void OnEnable()
    {
        switchSpeed = 9;
        currentSlide = slides[0];
        currentSlideIndex = 0;
        currentPos = centerPos.position;
        if (currentPrefab == null)
        {
            currentPrefab = Instantiate(currentSlide, currentPos, Quaternion.identity, slideParent);
        }
        currentPrefab.transform.localPosition = slideParent.localPosition;
        currentPrefab.name = currentSlide.name;
        SetToggleColor();
    }

    private void OnDisable()
    {
        Destroy(slidePrefab);
        Destroy(currentPrefab);
    }

    private void Update()
    {

    }

    public void Click()
    {
        if(isSwitching == false)
        {
            isSwitching = true;
            toggleButton.raycastTarget = false;
            toggleOff.Invoke();
            if (gameObject.name == "LeftButton")
            {
                //Debug.Log("LEFT");
                if (direction == "Right")
                {
                    switchSpeed = -switchSpeed;
                }
                direction = "Left";
                nextPos = rightSpawnPos.localPosition;
                if (currentSlideIndex != 0)
                {
                    nextSlide = slides[currentSlideIndex - 1];
                    nextSlideIndex = currentSlideIndex - 1;
                }
                else
                {
                    nextSlide = slides[slides.Length - 1];
                    nextSlideIndex = slides.Length - 1;
                }
            }
            else
            {
                //Debug.Log("RIGHT");
                direction = "Right";
                Mathf.Abs(switchSpeed);
                nextPos = leftSpawnPos.localPosition;
                if (currentSlideIndex != slides.Length - 1)
                {
                    nextSlide = slides[currentSlideIndex + 1];
                    nextSlideIndex = currentSlideIndex + 1;
                }
                else
                {
                    nextSlide = slides[0];
                    nextSlideIndex = 0;
                }
            }
            slidePrefab = Instantiate(nextSlide, nextPos, Quaternion.identity, slideParent);
            slidePrefab.transform.localPosition = nextPos;
            slidePrefab.name = nextSlide.name;
            StartCoroutine("NextSlide");
        }
    }



    IEnumerator NextSlide()
    {
        while(slidePrefab.transform.position != centerPos.position)
        {
            slidePrefab.transform.position = Vector3.MoveTowards(slidePrefab.transform.position, centerPos.position, switchSpeed * Time.deltaTime);
            currentPrefab.transform.position = Vector3.MoveTowards(currentPrefab.transform.position, -nextPos, switchSpeed * Time.deltaTime);
            yield return null;
        }
        Destroy(currentPrefab);
        currentPrefab = slidePrefab;
        currentPrefab.name = slidePrefab.name;
        currentSlideIndex = nextSlideIndex;
        SetToggleColor();
        isSwitching = false;
    }

    void SetToggleColor()
    {
        if(PlayerPrefs.GetInt("CheatPUs", 0) == 0)
        {
            if (PlayerPrefs.GetInt(currentPrefab.name, 0) < 1)
            {
                toggleButton.raycastTarget = false;
                toggleButton.color = Color.gray;
                //Debug.Log(currentPrefab.name);
            }
            else
            {
                toggleButton.raycastTarget = true;
                toggleButton.color = Color.black;

            }
        }

        else
        {
            toggleButton.raycastTarget = true;
            toggleButton.color = Color.black;
        }
        //Debug.Log(currentPrefab.name);
    }

    public void ConfirmToggleOn()
    {
        if(ToggleButton.isOn == true)
        {
            PlayerPrefs.SetString(currentPrefab.name + "Used", "True");
        }
    }
}
