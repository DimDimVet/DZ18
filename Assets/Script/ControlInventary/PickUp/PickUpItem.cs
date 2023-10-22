using UnityEngine;
using static EventManager;

public class PickUpItem : MonoBehaviour
{
    public PickSettings PickSettings;

    [SerializeField] private GameObject objectImg;

    private Collider collaider;

    private RegistratorConstruction rezultGO;
    private RegistratorConstruction rezultInventory;
    private bool isRun;

    void Start()
    {
        collaider = gameObject.GetComponent<Collider>();
        collaider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        int tempHsh = other.gameObject.GetHashCode();
        ExecutorCollision(tempHsh);

        collaider.enabled = false;
        DestoyGO();
    }
    private void ExecutorCollision(int _hash)
    {
        if (rezultGO.Hash == _hash)
        {
           
        }

        if (rezultInventory.ControlInventory != null)
        {
            print("��� ���� - "+ rezultGO.Hash);
            GameObject.Instantiate(objectImg, rezultInventory.ControlInventory.gridTransform);
        }
        else
        {
            print("No Script" + rezultGO.Hash);
        }
    }

    public void DestoyGO()
    {
        RegistratorConstruction rezult = GetNetworkManager();
        if (rezult.NetworkManager != null)//������ ��������� ����� �����, ������� ����� �����
        {
            rezult.NetworkManager.DestroyThisGO(this.gameObject);
        }
    }

    private void Activ()
    {
        if (/*PhotonView.Get(this.gameObject).IsMine &&*/ isRun)
        {

        }
    }
    private void GetConnectEvent()//�������� ���������� �� ���������� ������ �� �����
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            rezultGO = GetPlayer();//�������� ������ �� �����
            rezultInventory= GetInventory();

            if (rezultGO.UserInput != null && rezultInventory.ControlInventory!=null)
            {
                isRun = true;
            }
            else
            {
                isRun = false;
                return;
            }
        }
        else
        {
            isRun = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isRun)//���� ��� ����������, �������� ���������� ����
        {
            GetConnectEvent();
        }
        else
        {
            Activ();
        }
    }
}
