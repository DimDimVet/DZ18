using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using static EventManager;

public class IAPController : MonoBehaviour
{
    [SerializeField] string PurchaseID1;


    public void OnPurchaseCompleted(Product product)
    {
        print($"������ {PurchaseID1}");
        IAPController(2);
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureDescription reason)
    {
        print($"������� �������� {product.definition.id} ������ {reason}");
    }
}
