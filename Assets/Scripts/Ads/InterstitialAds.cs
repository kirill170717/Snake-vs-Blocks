using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static InterstitialAds instance;

    public string androidAdUnitId = "Interstitial_Android";
    public string iOSAdUnitId = "Interstitial_iOS";

    private string adUnitId;

    private void Awake()
    {
        instance = this;
        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdUnitId : androidAdUnitId;
    }

    private void Start()
    {
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
        Advertisement.Show(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Loading ad Unit successfully");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {placementId} - {error} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit: {placementId} - {error} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAd();
    }
}