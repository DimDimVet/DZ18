using UnityEngine;
using UnityEngine.Advertisements;
using static EventManager;

//������� Rewarded
public class RewardedAds : AdsInitializer
{
    [SerializeField] string androidAdID = "Rewarded_Android";
    [SerializeField] string iOSAdID = "Rewarded_iOS";
    private string adID;

    private void Start()
    {
        adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdID : androidAdID;
    }

    private void OnEnable()
    {
        OnTrigerRewardedAds += ShowAd;
    }

    public void ShowAd()
    {
        Advertisement.Load(adID, this);
        Advertisement.Show(adID, this);
    }

    public override void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            // ��� ��� ��� ���������� ������� ������.
            IAPController(1);
            print("����� �������� ����� �������, � ������� ������ ������.");
        }
    }
    //��� ������, ��� ����� ����� ��, ��� � ����������. ����� ������� ��� �� �������� ��� ������ ������ ShowAd().
    //������������, �� ��� �������� �� �������� ��������, ��� �� ����� OnUnityAdsShowComplete() � ������ #46.
    //����� �� ����� �������� ���, ������� ����� ��������� ��������� ������ �� �������� �������.
}
