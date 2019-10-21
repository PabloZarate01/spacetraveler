using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class AdStart : MonoBehaviour {
    public static AdStart instance;
    private BannerView bannerAd;
    private string bannerAdId = "ca-app-pub-7621807775957751/2769113891";
    private InterstitialAd interstitialAd;
    private string interstitialAdId = "ca-app-pub-7621807775957751/2090457043";
    private RewardedAd rewardedAd;
    private string rewardAdId = "ca-app-pub-7621807775957751/9777375370";

    private string appId = "ca-app-pub-7621807775957751~1438622877";
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        MobileAds.Initialize(appId);
        RequestBanner();
        RequestInterstitial();
        RequestVideoAd();
    }
    private void RequestBanner()
    {
        //TESTING
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        bannerAd = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        bannerAd.LoadAd(request);
        //TESTING
        //PROD
        //AdSize adSize = new AdSize(250, 250);
        //bannerAd = new BannerView(bannerAdId, adSize, AdPosition.Top);
        //AdRequest request = new AdRequest.Builder().Build();
        //bannerAd.LoadAd(request);
        //PROD


    }
    public void RequestInterstitial()
    {
        //TESTING
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        interstitialAd = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        interstitialAd.LoadAd(request);
        //TESTING
        //PROD
        //interstitialAd = new InterstitialAd(interstitialAdId);
        //AdRequest request = new AdRequest.Builder().Build();
        //interstitialAd.LoadAd(request);
        //PROD
    }
    public void RequestVideoAd()
    {
        //TESTING
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        rewardedAd = new RewardedAd(adUnitId);
        AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        rewardedAd.LoadAd(request);
        //TESTING
        //PROD
        //rewardedAd = new RewardedAd(rewardAdId);
        // Create an empty ad request.
        //AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        //rewardedAd.LoadAd(request);
        //PROD
    }
    public void DisplayBannerAd()
    {
        Debug.Log("Show");
        bannerAd.Show();
    }
    public void HideBannerAd()
    {
        Debug.Log("Hide");
        bannerAd.Hide();
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
        {
            rewardedAd.Show();
        }
        else
        {
            Debug.Log("Not Loaded  adReward");
        }
    }
    public void HandlerRewardAdEvents(bool suscribe)
    {
        if (suscribe)
        {
            // Called when an ad request has successfully loaded.
            this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
            // Called when an ad request failed to load.
            this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
            // Called when an ad is shown.
            this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
            // Called when an ad request failed to show.
            this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
            // Called when the user should be rewarded for interacting with the ad.
            this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            // Called when the ad is closed.
            this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        }

    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAd>>>Loaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            ">>>>>>>HandleRewardedAdRewarded event received for REVIVE"
                        + amount.ToString() + " " + type);
    }
    /*
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
    */
    /*
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

        
    }*/
}
