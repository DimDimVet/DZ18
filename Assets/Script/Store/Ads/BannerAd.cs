using UnityEngine;
using UnityEngine.Advertisements;
using static EventManager;

//������� Banner
public class BannerAd : AdsInitializer
{
    [SerializeField] BannerPosition bannerPosition;

    [SerializeField] string androidAdID = "Banner_Android";
    [SerializeField] string iOSAdID = "Banner_iOS";
    private string adID;

    private void Start()
    {
        adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdID : androidAdID;
        Advertisement.Banner.SetPosition(bannerPosition);
    }

    private void OnEnable()
    {
        OnTrigerBannerAd += SwithBanner;
    }

    private void SwithBanner(bool _isStatus)
    {
        if (_isStatus)
        {
            ShowAd(_isStatus);
        }
        else
        {
            CloseAd(_isStatus);
        }
    }

    private void ShowAd(bool _isStatus)
    {
        BannerLoadOptions optionsLoad = new BannerLoadOptions { loadCallback = OnBannerLoaded, errorCallback = OnBannerError };
        Advertisement.Banner.Load(adID, optionsLoad);

        BannerOptions optionsShow = new BannerOptions { clickCallback = OnBannerClicked, hideCallback = OnBannerHidden, showCallback = OnBannerShow };
        Advertisement.Banner.Show(adID, optionsShow);
    }

    private void CloseAd(bool _isStatus)
    {
        Advertisement.Banner.Hide(_isStatus);
    }

    private void OnBannerLoaded()
    {
        print("������ ��������");
    }

    private void OnBannerError(string message)
    {
        print($"������ �������� �������: {message}");
    }

    private void OnBannerClicked()
    {
        print("������ ��� �������");
    }

    private void OnBannerHidden()
    {
        print("������ ��� �����");
    }

    private void OnBannerShow()
    {
        print("������ ��� �������");
    }
    //��� ������, ������ ��� ������� ��� �� ����� ����� �� ����������,
    //�� ����������� ����� ���������� bannerPosition, ������� �������� �� ������� ������������ ��������.
    //��� ������� ����� ������� � ������� ���� Inspector. ����� ��� ��, ��� � � ���� ������ ��������,
    //������������ ����� ShowAd() ��� ������ �������.
}
