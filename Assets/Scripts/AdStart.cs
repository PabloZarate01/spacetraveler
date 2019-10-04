using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class AdStart : MonoBehaviour {
    public AdStart instance;
    private BannerView bannerAd;
    private string bannerAdId = "ca-app-pub-7621807775957751/2769113891";
    private InterstitialAd interstitialAd;
    private string interstitialAdId = "ca-app-pub-7621807775957751/2090457043";
    private RewardedAd rewardedAd;
    private string rewardAdId = "ca-app-pub-7621807775957751/9777375370";
    public void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestBanner();
        RequestInterstitial();
        RequestVideoAd();
        DisplayBannerAd();
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // Initialize the Google Mobile Ads SDK.
    }
    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        //PROD

        //PROD
        //TESTING
        AdSize adSize = new AdSize(250, 250);
        bannerAd = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        // Load the banner with the request.
        bannerAd.LoadAd(request);
        //TESTING
    }
    public void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        //PROD
        //PROD
        //TESTING
        interstitialAd = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        // Load the banner with the request.
        interstitialAd.LoadAd(request);
        //TESTING
    }
    private void RequestVideoAd()
    {
        //PROD
        //PROD
        //TESTING
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        rewardedAd = new RewardedAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        // Load the banner with the request.
        rewardedAd.LoadAd(request);
        //TESTING
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    public void DisplayBannerAd()
    {
        bannerAd.Show();
    }
    public void DestroyBannerAd()
    {
        bannerAd.Destroy();
    }
    public void DisplayInterstitialAd()
    {
        Debug.Log("DisplayInter");
        if(interstitialAd.IsLoaded())
            interstitialAd.Show();
    }
    public void DisplayRewardAd()
    {
        if (rewardedAd.IsLoaded())
            rewardedAd.Show();
    }
    void HandlerBannerAdEvents ( bool suscribe)
    {
        if ( suscribe)
        {
            // Called when an ad request has successfully loaded.
            bannerAd.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAd.OnAdOpening += HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAd.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAd.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        }else
        {
            // Called when an ad request has successfully loaded.
            bannerAd.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAd.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAd.OnAdOpening -= HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAd.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAd.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }

        
    }
}
