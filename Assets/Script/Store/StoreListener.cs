using UnityEngine;
using UnityEngine.Purchasing;
using static EventManager;

public class StoreListener : MonoBehaviour, IStoreListener
{
    [SerializeField] private GameObject objectImg;

    void Start()
    {
        OnTrigerIAPController += GetStory;
    }


    private void GetStory(int _count)
    {
        RegistratorConstruction rezultGO = GetPlayer();//�������� ������ �� �����
        RegistratorConstruction rezultInventory = GetInventory();

        for (int i = 0; i < _count; i++)
        {
            print("��� ���� - " + rezultGO.Hash);
            Instantiate(objectImg, rezultInventory.ControlInventory.gridTransform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("������ ������");
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("������ ������");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("������ ������");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"����� {product}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {

        throw new System.NotImplementedException();
    }


}
