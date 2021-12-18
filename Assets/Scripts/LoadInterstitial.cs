using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadInterstitial : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _showAdButton;
    [SerializeField] Image _showAdButtonImage;
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;
    [SerializeField] int _multi;

    //[SerializeField] string _nextScene;
    [SerializeField] string _sceneId;

    bool multipleAds;

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;

        //Disable button until ad is ready to show
        _showAdButton.interactable = false;
        _showAdButtonImage.raycastTarget = false;
        multipleAds = false;
    }

    private void Start()
    {
        Debug.Log("ID pre: " + PlayerPrefs.GetInt(_sceneId, 1));
        if (PlayerPrefs.GetInt(_sceneId, 1) % _multi == 0)
        {
            LoadAd();

        }
        else
        {
            int i = PlayerPrefs.GetInt(_sceneId, 1);
            PlayerPrefs.SetInt(_sceneId, i + 1);
        }
        //Debug.Log("ID post: " + PlayerPrefs.GetInt(_sceneId, 1));
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        if (multipleAds == false)
        {
            Debug.Log("Loading Ad: " + _adUnitId);
            Advertisement.Load(_adUnitId, this);
            multipleAds = true;
        }
            // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
            
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
                _showAdButton.onClick.AddListener(ShowAd);
                _showAdButton.interactable = true;
                _showAdButtonImage.raycastTarget = true;
                // Configure the button to call the ShowAd() method when clicked:

            // Enable the button for users to click:

        }
    }

    // Implement a method to execute when the user clicks the button.
    public void ShowAd()
    {
        // Disable the button: 
        _showAdButton.interactable = false;
        _showAdButtonImage.raycastTarget = false;
        Debug.Log("Interactable False");

        int i = PlayerPrefs.GetInt(_sceneId, 1);
        PlayerPrefs.SetInt(_sceneId, i + 1);
        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
        Debug.Log("AdShowed");
        
    }
    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.

            // Load another ad:
            //Advertisement.Load(_adUnitId, this);
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        _showAdButton.onClick.RemoveAllListeners();
        Debug.Log("Removed");
    }
}
