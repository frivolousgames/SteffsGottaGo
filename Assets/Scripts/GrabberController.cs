using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GrabberController : MonoBehaviour
{
    Animator anim;

    public static bool turning;
    public static bool opening;
    public bool resetting;

    public static bool dropping;
    public static bool rising;

    public static bool working;

    public float movement;

    public GameObject returnCollider;
    public GameObject bottomCollider;

    public float moveSpeed;

    public Transform rightBarrier;
    public Transform leftBarrier;

    Vector3 startPos;

    float relativeXPos = 1;

    public GameObject[] nuggetLights;

    //Coins
    public Text coinAmountText;
    int coins;

    //Splash
    public GameObject splashSpawn;
    public GameObject splash;

    public GameObject drip;
    public float dripOffset;

    //Items
    public static bool empty;
    bool foundGoldNugget;
    bool foundGarbage;
    bool lost;

    int nuggets;

    public GameObject grabberNugget;
    public GameObject grabberGoldNugget;
    public GameObject grabberShart;

    GameObject grabberItem;

    GameObject nuggetPrefab;

    public GameObject[] shartFace;
    public GameObject shartScreen;

    //Shart
    public Animator ssAnim;

    //screen
    public GameObject itemScreen;
    public Image itemScreenImage;
    public Text itemScreenHeading;
    public Text itemScreenSummary;
    public Text itemScreenCoins;
    public GameObject itemScreenBanner;
    public AudioSource itemScreenSound;

    int selector;
    string selectedGroup;

    string selectedItem;

    int selectedCoins;
    public GameObject coinAdder;
    Color coinAdderColor;
    Text coinAdderText;
    

    //Audio
    public AudioSource grabberPlayer;
    public AudioClip[] grabberSounds;

    public GameObject nugLost;

    AudioSource coinAdderAudio;
    public AudioClip[] coinAdderClips;

    public AudioSource winSoundPlayer;
    public AudioClip[] winSounds;

    //Prize
    public GameObject prizeScreen;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        working = false;
        dropping = false;
        rising = false;
        empty = true;
        turning = false;
        startPos = transform.position;

        //PlayerPrefs.SetInt("Nuggets", 0);

        //Coins
        //PlayerPrefs.SetInt("Coins", 50);
        if (PlayerPrefs.GetInt("CheatCoins", 0) == 0)
        {
            coins = PlayerPrefs.GetInt("Coins", 0);
        }
        else
        {
            coins = 999999;
        }
        if (coins > 999)
        {
            coinAmountText.text = "999";
        }
        else
        {
            coinAmountText.text = coins.ToString();
        }
    }

    private void Start()
    {
        coinAdderText = coinAdder.GetComponent<Text>();
        coinAdderColor = coinAdderText.color;
        coinAdderAudio = coinAdder.GetComponent<AudioSource>();
        nuggets = PlayerPrefs.GetInt("Nuggets", 0);
        SetStartNuggets(nuggets);
        //coinTextColor = itemScreenCoins.color;
    }

    private void Update()
    {
        anim.SetBool("opening", opening);
        anim.SetBool("resetting", resetting);
        anim.SetFloat("movement", movement);

        nuggets = PlayerPrefs.GetInt("Nuggets", 0);

        //Coins
        if (PlayerPrefs.GetInt("CheatCoins", 0) == 0)
        {
            coins = PlayerPrefs.GetInt("Coins", 0);
        }
        else
        {
            coins = 999999;
        }

        if(coins > 999)
        {
            coinAmountText.text = "999";
        }
        else
        {
            coinAmountText.text = coins.ToString();
        }
            
        

        if(selectedGroup == "superRareItems")
        {
            itemScreenBanner.SetActive(true);
        }
        else
        {
            itemScreenBanner.SetActive(false);
        }
        Debug.Log("Nuggets: " + nuggets);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == bottomCollider)
        {
            //Debug.Log("Hit");
            opening = false;
            dropping = false;
            if(empty == false)
            {
                SetItemGroup();
                SetSelectedItem(selectedGroup);
                nuggetPrefab = Instantiate(grabberItem, new Vector2(transform.position.x, transform.position.y - 1.69f), Quaternion.identity, transform);
            }
            StartCoroutine("CloseWait");
        }

        if(other.gameObject == returnCollider)
        {
            //Debug.Log("Returned");
            //rising = false;
        }

        if(other.gameObject == splashSpawn)
        {
            Instantiate(splash, new Vector3(transform.position.x, splashSpawn.transform.position.y, 0f), Quaternion.identity, null);
        }
    }

    IEnumerator CloseWait()
    {
        yield return new WaitForSeconds(1f);
        rising = true;
        if(grabberItem == grabberGoldNugget)
        {
            nuggetLights[nuggets - 1].SetActive(true);
        }
        Instantiate(drip, new Vector2(transform.position.x, transform.position.y - dripOffset), Quaternion.identity, transform);
        StartCoroutine("FindTop");
    }

    public void MoveRight()
    {
        if(working == false && coins > 0/*&& transform.position != rightBarrier.position*/)
        {
            //Debug.Log("turning right");
            movement = .2f;
            turning = true;
            StartCoroutine("GoRight");   
        }
    }

    IEnumerator GoRight()
    {
        GrabberBuzzPlay();
        while (Input.GetMouseButton(0) == true )
        {
            transform.position = Vector3.MoveTowards(transform.position, rightBarrier.position, Time.deltaTime * moveSpeed);
            /*if(transform.position == rightBarrier.position)
            {
                movement = 0f;
                break;
            }*/
            yield return null;
        }
        GrabberUnBuzzPlay();
    }

    public void MoveLeft()
    {
        if (working == false && coins > 0/* && transform.position != leftBarrier.position*/)
        {
            //Debug.Log("turning left");
            movement = -.2f;
            turning = true;
            StartCoroutine("GoLeft");
        }
    }

    IEnumerator GoLeft()
    {
        GrabberBuzzPlay();
        while (Input.GetMouseButton(0) == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftBarrier.position, Time.deltaTime * moveSpeed);
            /*if (transform.position == leftBarrier.position)
            {
                movement = 0f;
                break;
            }*/
            yield return null;
        }
        GrabberUnBuzzPlay();
    }

    public void ResetTurn()
    {
        if(working == false)
        {
            //Debug.Log("reset");
            turning = false;
            movement = 0f;
        }  
    }

    public void Drop()
    {
        if(turning == false && working == false && coins > 0)
        {
            working = true;
            dropping = true;
            opening = true;
            StartCoroutine("FindBottom");
        }
    }

    IEnumerator FindBottom()
    {
        GrabberBuzzPlay();
        while (dropping == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, bottomCollider.transform.position.y, 0f), Time.deltaTime * moveSpeed);
            yield return null;
        }
        grabberPlayer.Stop();
    }

    IEnumerator FindTop()
    {
        GrabberBuzzPlay();
        while (transform.position.y < startPos.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, startPos.y, 0f), Time.deltaTime * moveSpeed);
            yield return null;
        }
        rising = false;
        grabberPlayer.Stop();
        if (empty == true)
        {
            StartCoroutine("ResetWait");
        }
        else if(selectedGroup == "shark")
        {
            shartScreen.SetActive(true);
        }
        else
        {
            itemScreen.SetActive(true);
        }
    }

    IEnumerator ResetWait()
    {
        resetting = true;
        Destroy(nuggetPrefab);
        yield return new WaitForSeconds(.8f);
        GrabberBuzzPlay();
        turning = true;
        if(transform.position.x > startPos.x)
        {
            relativeXPos = -relativeXPos;
        }
        StartCoroutine("ResetPos");
    }

    IEnumerator ResetPos()
    {
        movement = .2f * relativeXPos;
        while (transform.position.x != startPos.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * moveSpeed);
            yield return null;
        }
        working = false;
        turning = false;
        GrabberUnBuzzPlay();
        movement = 0f;
        relativeXPos = 1;
        resetting = false;
    }

    public void ResetAfterWin()
    {
        empty = true;

        if (selectedCoins != 0)
        {
            StartCoroutine("AddCoins");
        }
        else if (nuggets == 3)
        {
            StartCoroutine("WinPrize");
        }
        else
        {
            itemScreen.SetActive(false);
            StartCoroutine("ResetWait");
        }
    }

   
    //Items
    void SetItemGroup()
    {
        selector = Random.Range(0, 1001);
        Debug.Log("Selector: " + selector);
        if(PlayerPrefs.GetInt("Nuggets", 0) <= 1)
        {
            if (selector < 600)
            {
                selectedGroup = "items";
            }
            else if (selector > 599 && selector < 865)
            {
                selectedGroup = "goldenNugget";
            }
            else if (selector > 864 && selector < 985)
            {
                selectedGroup = "rareItems";
            }
            else
            {
                selectedGroup = "superRareItems";
            }
        }

        else
        {
            if (selector < 425)
            {
                selectedGroup = "items";
            }
            else if(selector > 424 && selector < 645)
            {
                selectedGroup = "shark";
            }
            else if (selector > 644 && selector < 865)
            {
                selectedGroup = "goldenNugget";
            }
            else if(selector > 864 && selector < 985)
            {
                selectedGroup = "rareItems";
            }
            else
            {
                selectedGroup = "superRareItems";
            }
        }
        //rare items = 900 - 1000
        //nugget = 550 - 899
        //items = 0 - 549

        //if nuggets > 1
        //nugget = 650 - 899
        //shark = 400 - 649
        //items = 0 - 399
    }

    void SetSelectedItem(string selectedGroup)
    {
        int i = 0;
        switch (selectedGroup)
        {
            case "superRareItems":
                i = Random.Range(0, ItemInfo.superRareItemsArt.Length);
                itemScreenHeading.text = ItemInfo.superRareItemsHeadings[i];
                itemScreenSummary.text = ItemInfo.superRareItemsTexts[i];
                itemScreenImage.sprite = ItemInfo.superRareItemsArt[i];

                selectedCoins = ItemInfo.superRareItemsCoins[i];
                //itemScreenCoins.text = "COINS: " + selectedCoins.ToString();
                SetCoinText(selectedCoins);

                grabberItem = grabberNugget;

                winSoundPlayer.clip = winSounds[0];

                PlayerPrefs.SetString(ItemInfo.superRareItemsHeadings[i], "Unlocked");
                break;

            case "rareItems":
                i = Random.Range(0, ItemInfo.rareItemsArt.Length);
                itemScreenHeading.text = ItemInfo.rareItemsHeadings[i];
                itemScreenSummary.text = ItemInfo.rareItemsTexts[i];
                itemScreenImage.sprite = ItemInfo.rareItemsArt[i];

                selectedCoins = ItemInfo.rareItemsCoins[i];

                //itemScreenCoins.text = "COINS: " + selectedCoins.ToString();
                SetCoinText(selectedCoins);

                winSoundPlayer.clip = null;

                grabberItem = grabberNugget;

                PlayerPrefs.SetString(ItemInfo.rareItemsHeadings[i], "Unlocked");
                break;

            case "items":
                i = Random.Range(0, ItemInfo.itemsArt.Length);
                itemScreenHeading.text = ItemInfo.itemsHeadings[i];
                itemScreenSummary.text = ItemInfo.itemsTexts[i];
                itemScreenImage.sprite = ItemInfo.itemsArt[i];

                selectedCoins = 0;
                itemScreenCoins.text = null;

                grabberItem = grabberNugget;

                winSoundPlayer.clip = null;

                PlayerPrefs.SetString(ItemInfo.itemsHeadings[i], "Unlocked");
                break;

            case "goldenNugget":
                itemScreenHeading.text = ItemInfo.nuggetHeading;
                PlayerPrefs.SetInt("Nuggets", nuggets + 1);
                itemScreenSummary.text = ItemInfo.nuggetTexts[nuggets];
                itemScreenImage.sprite = ItemInfo.nuggetArt;

                selectedCoins = 0;
                itemScreenCoins.text = null;

                if(nuggets > 1)
                {
                    winSoundPlayer.clip = winSounds[1];
                }
                else
                {
                    winSoundPlayer.clip = winSounds[0];
                }

                grabberItem = grabberGoldNugget;
                break;

            case "shark":
                /*itemScreenHeading.text = ItemInfo.shartHeading;
                itemScreenSummary.text = ItemInfo.shartText;
                itemScreenImage.sprite = ItemInfo.shartArt;

                selectedCoins = 0;
                itemScreenCoins.text = null;*/

                grabberItem = grabberShart;
                break;

            case null:
                itemScreenHeading.text = "Whoops";
                itemScreenSummary.text = "Ok so I screwed something up. It happens ok. Don't judge me!";
                Debug.Log("ERROR NO ITEM SELECTED");
                break;

            default:
                itemScreenHeading.text = "Whoops";
                itemScreenSummary.text = "Ok so I screwed something up. It happens ok. Don't judge me!";
                break;
        }
        selectedItem = itemScreenImage.name;
        
        if(selectedCoins > 0)
        {
            coinAdderText.color = Color.green;
            coinAdderText.text = "+" + selectedCoins.ToString();
            coinAdderAudio.clip = coinAdderClips[0];
            //itemScreenCoins.color = coinTextColor;
        }
        else
        {
            coinAdderText.color = Color.red;
            coinAdderText.text = selectedCoins.ToString();
            coinAdderAudio.clip = coinAdderClips[1];
            //itemScreenCoins.color = coinTextColor;
        }
    }

    void SetCoinText(int selectedCoin)
    {
        if(selectedCoin > 0)
        {
            itemScreenCoins.text = "+" + selectedCoins.ToString() + " COINS";
        }
        else
        {
            itemScreenCoins.text = selectedCoins.ToString() + " COINS";
        }
    }

    //Coins

    public void UseCoin()
    {
        if (PlayerPrefs.GetInt("CheatCoins", 0) == 0)
        {
            if (working == false && turning == false)
            {
                if (coins > 0)
                {
                    int i = coins;
                    PlayerPrefs.SetInt("Coins", i - 1);
                }
            }
        }
    }

    IEnumerator AddCoins()
    {
        if (PlayerPrefs.GetInt("CheatCoins", 0) == 0)
        {
            if(selectedCoins < 0 && Mathf.Abs(selectedCoins) > coins)
            {
                PlayerPrefs.SetInt("Coins", 0);
            }
            else
            {
                int i = coins;
                PlayerPrefs.SetInt("Coins", i + selectedCoins);
            }
        }
        coinAdder.SetActive(true);
        selectedCoins = 0;
        yield return new WaitForSeconds(.8f);
        itemScreen.SetActive(false);
        StartCoroutine("ResetWait");
    }

    IEnumerator WinPrize()
    {
        PlayerPrefs.SetInt("Nuggets", 0);
        foreach(GameObject nuglight in nuggetLights)
        {
            nuglight.SetActive(false);
        }
        itemScreen.SetActive(false);
        prizeScreen.SetActive(true);
        yield return null;
    }
    
    public void ResetEvent()
    {
        StartCoroutine("ResetWait");
    }

    void SetStartNuggets(int nuggets)
    {
        for(int i = 0; i < nuggets; i++)
        {
            nuggetLights[i].SetActive(true);
        }
    }

    //Shart
    public void LoseNuggets()
    {
        StartCoroutine("LoseNugs");
    }
    public IEnumerator LoseNugs()
    {
        PlayerPrefs.SetInt("Nuggets", 0);
        foreach (GameObject nuglight in nuggetLights)
        {
            if(nuglight.activeInHierarchy == true)
            {
                nuglight.SetActive(false);
                Instantiate(nugLost, null);
                yield return new WaitForSeconds(.5f);
            }
        }
        yield return new WaitForSeconds(.2f);
        ssAnim.SetTrigger("outro");
        StartCoroutine("ResetWait");
    }

    //Audio
    public void GrabberBuzzPlay()
    {
        grabberPlayer.loop = true;
        grabberPlayer.clip = grabberSounds[0];
        grabberPlayer.Play();
    }

    public void GrabberUnBuzzPlay()
    {
        grabberPlayer.clip = grabberSounds[1];
        grabberPlayer.loop = false;
        grabberPlayer.Play();
    }

    public void GrabberBuzzStop()
    {
        grabberPlayer.Stop();
    }
}
