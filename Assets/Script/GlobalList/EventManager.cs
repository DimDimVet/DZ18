using System;

public class EventManager
{
    //������ ����� Camera
    public static Func<RegistratorConstruction> OnGetCamera;//�������� �� ������������ ����
    public static RegistratorConstruction GetCamera()
    {
        return (RegistratorConstruction)OnGetCamera?.Invoke();//�������� �� ������������ ����
    }

    //������ ����� Player
    public static Func<RegistratorConstruction> OnGetPlayer;//�������� �� ������������ ����
    public static RegistratorConstruction GetPlayer()
    {
        return (RegistratorConstruction)OnGetPlayer?.Invoke();//�������� �� ������������ ����
    }

    //������ ����� ������� �� hash
    public static Func<int,RegistratorConstruction> OnGetObjectHash;//�������� �� ������������ ����
    public static RegistratorConstruction GetObjectHash(int hash)
    {
        return (RegistratorConstruction)OnGetObjectHash?.Invoke(hash);//�������� �� ������������ ����
    }

    //�������� ����� �� hash
    public static Action<int, int> OnGetDamageHash;//�������� �� ������������ ����
    public static void GetDamageHash(int hash, int damage)
    {
        OnGetDamageHash?.Invoke(hash, damage);//�������� �� ������������ ����
    }

    //������ ����� NetPhoton
    public static Func<RegistratorConstruction> OnGetNetworkManager;//�������� �� ������������ ����
    public static RegistratorConstruction GetNetworkManager()
    {
        return (RegistratorConstruction)OnGetNetworkManager?.Invoke();//�������� �� ������������ ����
    }

    //������ ��������
    public delegate void Trigers();
    public static event Trigers OnTrigerCount;//�������� �� ������������ ����
    public static void TrigerCount()
    {
        OnTrigerCount?.Invoke();//�������� �� ������������ ����
    }

    //������ ����� Inventory
    public static Func<RegistratorConstruction> OnGetInventory;//�������� �� ������������ ����
    public static RegistratorConstruction GetInventory()
    {
        return (RegistratorConstruction)OnGetInventory?.Invoke();//�������� �� ������������ ����
    }

    //������ ������� RewardedAds
    public delegate void TrigerRewardedAds();
    public static event TrigerRewardedAds OnTrigerRewardedAds;//�������� �� ������������ ����
    public static void RewardedAds()
    {
        OnTrigerRewardedAds?.Invoke();//�������� �� ������������ ����
    }

    //������ ������� InterstitialAds
    public delegate void TrigerInterstitialAds();
    public static event TrigerInterstitialAds OnTrigerInterstitialAds;//�������� �� ������������ ����
    public static void InterstitialAds()
    {
        OnTrigerInterstitialAds?.Invoke();//�������� �� ������������ ����
    }

    //������ ������� BannerAd
    public delegate void TrigerBannerAd(bool _isStatus);
    public static event TrigerBannerAd OnTrigerBannerAd;//�������� �� ������������ ����
    public static void BannerAd(bool _isStatus)
    {
        OnTrigerBannerAd?.Invoke(_isStatus);//�������� �� ������������ ����
    }

    //������ ������� InterstitialAds
    public delegate void TrigerIAPController(int _count);
    public static event TrigerIAPController OnTrigerIAPController;//�������� �� ������������ ����
    public static void IAPController(int _count)
    {
        OnTrigerIAPController?.Invoke(_count);//�������� �� ������������ ����
    }
}
