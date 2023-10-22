using UnityEngine;
using UnityEngine.Advertisements;
using static EventManager;

//������� Interstitial
public class InterstitialAds : AdsInitializer
{
    [SerializeField] string androidAdID = "Interstitial_Android";
    [SerializeField] string iOSAdID = "Interstitial_iOS";
    private string adID;

    private int adsCount = 20;
    private int tempCount;

    private void Start()
    {
        adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdID : androidAdID;

    }

    private void OnEnable()
    {
        OnTrigerInterstitialAds += ShowAd;
        OnTrigerCount += ADSCount;
    }

    private void ADSCount()
    {
        tempCount++;
        if (tempCount >= adsCount)
        {
            ShowAd();
            tempCount = 0;
        }
    }

    public void ShowAd()
    {
        Advertisement.Load(adID, this);
        Advertisement.Show(adID, this);
    }

    public override void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        print("����� �������� ����� �������.");
    }
    //��������� ������ ������ �� �� �����, ��������� �� ����� ����� �� ����������.��-����, ����� ��� �� ������
    //���������� ��� Android � iOS, � ���������� ���������� ������������.����� ��� �� ������� 6 ������������ �������,
    //������� � ������� ������� ��������� �����������.

    //�����! ������������ �� ��� �������� �� �������� ��������, ��� �� ����� ShowAd(),
    //������� ������� � ������� ������ Load() ���������� �������,
    //� ����� � ������� ������ Show() ���������� � �� ������ ��� ������������.������ ���� ����� � ����� �������� �����,
    //����� ��� ���������� ���������� ������� �� ������� �����.
    //�������� ����� ������� ������ ����� ���������� ����� ����� ������� �� ����������� ������.
}
