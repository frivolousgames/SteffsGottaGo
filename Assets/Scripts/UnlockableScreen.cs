using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockableScreen : MonoBehaviour
{
    public GameObject lockedItemBox;

    //string[][] itemHeadings;
    //string[][] itemTexts;
    //Sprite[][] itemArt;

    List<string> headings;
    List<string> texts;
    List<Sprite> art;
    List<int> coins;

    //fullscreen
    public static GameObject fullScreenItem;
    public static int selectedItem;

    public Image itemScreenImage;
    public Text itemScreenHeading;
    public Text itemScreenSummary;
    public Text itemScreenCoins;
    public GameObject banner;

    int selectedCoins;

    private void Awake()
    {
        headings = new List<string>();
        texts = new List<string>();
        art = new List<Sprite>();
        coins = new List<int>();
    }

    private void Start()
    {
        fullScreenItem = GameObject.FindGameObjectWithTag("FullScreenItem");
        fullScreenItem.SetActive(false);

        string[][] itemHeadings =
    {
        ItemInfo.superRareItemsHeadings,
        ItemInfo.rareItemsHeadings,
        ItemInfo.itemsHeadings
    };
        string[][] itemTexts =
        {
        ItemInfo.superRareItemsTexts,
        ItemInfo.rareItemsTexts,
        ItemInfo.itemsTexts
    };
        Sprite[][] itemArt =
        {
        ItemInfo.superRareItemsArt,
        ItemInfo.rareItemsArt,
        ItemInfo.itemsArt
    };
        int[][] itemCoins =
        {
        ItemInfo.superRareItemsCoins,
        ItemInfo.rareItemsCoins
    };
        AddToList(itemHeadings, headings);
        AddToList(itemTexts, texts);
        AddSToList(itemArt, art);
        AddIToList(itemCoins, coins);
        StartPopulate();

    }

    private void Update()
    {
        FullSized();
    }

    void AddToList(string[][] s1, List<string> l1)
    {
        foreach(string[] s in s1)
        {
            l1.AddRange(s);
        }
    }
    void AddSToList(Sprite[][] s1, List<Sprite> l1)
    {
        foreach (Sprite[] s in s1)
        {
            l1.AddRange(s);
        }
    }
    void AddIToList(int[][] s1, List<int> l1)
    {
        foreach (int[] s in s1)
        {
            l1.AddRange(s);
        }
    }

    void StartPopulate()
    {
        int i = 0;
        foreach(string s in headings)
        {
            GameObject fab = Instantiate(lockedItemBox, transform);
            if (PlayerPrefs.GetString(s, "Locked") == "Unlocked")
            {
                Image bg = fab.GetComponentsInChildren<Image>()[1];
                bg.color = Color.white;
                Image im = fab.GetComponentsInChildren<Image>()[2];
                im.color = Color.white;
                Text t = fab.GetComponentInChildren<Text>();
                t.text = i.ToString();
                t.color = Color.clear;
                im.sprite = art[i];
                GameObject bnr = fab.GetComponentsInChildren<Image>(true)[3].gameObject;
                Debug.Log(bnr.name);
                if (i < ItemInfo.superRareItemsHeadings.Length)
                {
                    bnr.SetActive(true);
                }
            }
            i++;
        }
    }

    void FullSized()
    {
        itemScreenImage.sprite = art[selectedItem];
        itemScreenHeading.text = headings[selectedItem];
        itemScreenSummary.text = texts[selectedItem];
        if(selectedItem < coins.Count)
        {
            selectedCoins = coins[selectedItem];
            SetCoinText(selectedCoins);
        }
        else
        {
            itemScreenCoins.text = "";
        }
        if(selectedItem < ItemInfo.superRareItemsHeadings.Length)
        {
            banner.SetActive(true);
        }
        else
        {
            banner.SetActive(false);
        }
    }

    void SetCoinText(int selectedCoin)
    {
        if (selectedCoin > 0)
        {
            itemScreenCoins.text = "+" + selectedCoins.ToString() + " COINS";
        }
        else
        {
            itemScreenCoins.text = selectedCoins.ToString() + " COINS";
        }
    }
}
