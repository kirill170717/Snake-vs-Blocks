using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    public static BannerAds instance;

    public BannerPosition bannerPosition;
    public string androidAdUnitId = "Banner_Android";
    public string iOSAdUnitId = "Banner_iOS";

    private string adUnitId;

    private void Awake()
    {
        instance = this;
        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdUnitId : androidAdUnitId;
    }

    private void Start()
    {
        Advertisement.Banner.SetPosition(bannerPosition);
        LoadAd();
    }

    private IEnumerator LoadBannerAds()
    {
        yield return new WaitForSeconds(1f);
        LoadAd();
    }

    public void LoadAd()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };
        Advertisement.Banner.Load(adUnitId, options);
    }

    private void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        ShowAd();
    }

    private void OnBannerError(string message)
    {
        Debug.Log($"Banner error: {message}");
    }

    public void ShowAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };
        Advertisement.Banner.Show(adUnitId, options);
    }

    private void OnBannerClicked()
    {

    }
    
    private void OnBannerShown()
    {

    }

    private void OnBannerHidden()
    {

    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }
}