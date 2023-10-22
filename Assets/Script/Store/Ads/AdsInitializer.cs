using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string androidGameID = "5440097";
    [SerializeField] string iOSGameID = "5440096";
    [SerializeField] bool testMode = true;
    private string gameID;

    private void Awake()
    {
        gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSGameID : androidGameID;
        Advertisement.Initialize(gameID, testMode, this);
    }

    public void OnInitializationComplete()
    {
        print("������������� ������ �������.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print($"������ �������������: {error.ToString()} - {message}");
    }

    //� ������ #2 �� ���������� ���������� UnityEngine.Advertisements, ��� ��� �������� � ��������. � ���� ���� ��������� �������� IUnityAdsInitializationListener.
    //� ������� #6-7 �� ������� ����������, � ������� ���������� ������� ID ����� ���� ��� �������� � ������.
    //� ������ #8 �� ������, ��� ������� ������ ������������ � �������� ������. ��� ���������� ���������� ����, ���������� �������� ������ �������� �� false.
    //� ������ Awake() �� ��������� ���������� ������, ���� ��� �����, �� � ���������� gameID ������� ID ������, ����� � ������ ���������� ������� ID ��������.
    //�� � � ������ #14, � ������� ������ Initialize() �� �������� ����������� � ��������� ����. ���� ����������� ������ �������, �� ���������� ����� OnInitializationComplete(), � ���� ��������� ������, �� ���������� ����� OnInitializationFailed().

    public void OnUnityAdsAdLoaded(string placementId)
    {
        print("������� ���������: " + placementId);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print($"������ �������� �������: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print($"������ ������ �������: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        print("����� ������ �������: " + placementId);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        print("���� �� �������: " + placementId);
    }

    public virtual void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            // ��� ��� ��� ���������� ������� ������.
            print("����� �������� ����� �������, � ������� ������ ������.");
        }
    }
}
