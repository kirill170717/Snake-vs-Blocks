using UnityEngine;
using UnityEngine.Purchasing;

public class PurchasingManager : MonoBehaviour, IStoreListener
{
    public GameObject NoAds;
    public GameObject Life;

    IStoreController m_StoreController;

    private string noads = "com.ilink.snakevsblocks.noads";
    private string life = "com.ilink.snakevsblocks.lifex10";

    void Start()
    {
        InitializePurchasing();

        //if (PlayerPrefs.HasKey("firstStart") == false)
        //{
        //    PlayerPrefs.SetInt("firstStart", 1);
        //    RestoreMyProduct();
        //}

        RestoreVariable();
    }

    void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(noads, ProductType.NonConsumable);
        builder.AddProduct(life, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    void RestoreVariable()
    {
        if (PlayerPrefs.HasKey("ads"))
            NoAds.SetActive(false);
    }

    public void BuyProduct(string productName)
    {
        m_StoreController.InitiatePurchase(productName);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        var product = args.purchasedProduct;

        if (product.definition.id == noads)
            Product_NoAds();

        if (product.definition.id == life)
            Product_Life();

        Debug.Log($"Purchase Complete - Product: {product.definition.id}");
        return PurchaseProcessingResult.Complete;
    }

    private void Product_NoAds()
    {
        PlayerPrefs.SetInt("ads", 0);
        NoAds.SetActive(false);
        BannerAds.instance.StopAllCoroutines();
        BannerAds.instance.HideBannerAd();
        RewardedAds.instance.StopAllCoroutines();
        UiManager.instance.persentShowAds = 0;
        UiManager.instance.getLife.SetActive(false);
    }

    private void Product_Life()
    {
        Data.instance.player.life += 10;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log($"In-App Purchasing initialize failed: {error}");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"Purchase failed - Product: '{product.definition.id}', PurchaseFailureReason: {failureReason}");
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("In-App Purchasing successfully initialized");
        m_StoreController = controller;
    }


    //public void RestoreMyProduct()
    //{
    //    if (CodelessIAPStoreListener.Instance.StoreController.products.WithID(noads).hasReceipt)
    //        Product_NoAds();
    //}
}