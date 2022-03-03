using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitialization : MonoBehaviour, IUnityAdsInitializationListener
{
    public bool testMode;
    public string androidGameId = "4638783";
    public string iOSGameId = "4638782";

    private string gameId;

    private void Awake() => InitializeAds();

    public void InitializeAds()
    {
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSGameId : androidGameId;
        Advertisement.Initialize(gameId, testMode);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads initialization complete!: {error} - {message}");
    }
}