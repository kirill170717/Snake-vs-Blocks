using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static RewardedAds instance;

    public Button getLife;
    public Button getCoin;
    public string androidAdUnitId = "Rewarded_Android";
    public string iOSAdUnitId = "Rewarded_iOS";

    private string adUnitId;

    private void Awake()
    {
        instance = this;
        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdUnitId : androidAdUnitId;
        getLife.interactable = false;
    }

    private void Start()
    {
        StartCoroutine(LoadRewardedAds());
    }

    private IEnumerator LoadRewardedAds()
    {
        yield return new WaitForSeconds(1f);
        LoadAd();
    }

    public void LoadAd()
    {
        Debug.Log("Loading Ad:" + adUnitId);
        Advertisement.Load(adUnitId, this);
    }

    public void ShowAd()
    {
        Debug.Log("Showing Ad:" + adUnitId);
        getLife.interactable = false;
        getCoin.interactable = false;
        Advertisement.Show(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad Loaded" + placementId);

        if (placementId.Equals(adUnitId))
        {
            getLife.interactable = true;
            getCoin.interactable = true;
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad: {placementId} - {error} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad: {placementId} - {error} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(placementId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads rewarded ad completed!");

            if(UiManager.instance.gameOver.activeSelf)
            {
                Score.instance.Life++;
                getLife.gameObject.SetActive(false);
            }
            else
            {
                Score.instance.Coin++;
                getCoin.gameObject.SetActive(false);
            }

            Advertisement.Load(adUnitId, this);
        }
    }

    private void OnDestroy()
    {
        getLife.onClick.RemoveAllListeners();
        getCoin.onClick.RemoveAllListeners();
    }
}