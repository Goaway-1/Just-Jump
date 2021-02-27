using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Banner : MonoBehaviour
{
    public BannerView bannerView;
    void Start()
    {
        string appId = "ca-app-pub-3257292202721072~1856023211"; //안드로이드 아이디 (테스트용)

        MobileAds.Initialize(appId);
        this.RequestBanner();
    }
    void Update()
    {
        if (Player.delbanner == 1)
        {
            bannerView.Destroy();
            Debug.Log("banner destroy");
            Player.delbanner = 0;
        }
    }
    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3257292202721072/4084738918"; //배너광고 아이디테스트

        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom); //위치 및 특성

        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);
    }
    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args) //로드 실패시
    {
        RequestBanner();
    }
}
