using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ControlCraft : MonoBehaviour
{
    public CraftSettings CraftSettings;//��������� ������� ������(������)
    [SerializeField] private Button craftButton;//��������� ������ ������
    [SerializeField] private Transform gridUI;//������ ��������� ����� ���� ���������
    private List<ICraft> items = new List<ICraft>();//��������� ���� ��� �������� ��������� �������� � Icraft
    private List<GameObject> select = new List<GameObject>();//��������� ���� ��� �������� ������� ����� � Icraft
    void Start()
    {
        craftButton.onClick.AddListener(EnterCraft);//�������� ������ �� �������
    }
    public void EnterCraft()
    {
        select.Clear();
        items = GetComponentsInChildren<ICraft>().ToList(); //������� ���� ��������� (�����.�������)

        for (int i = 0; i < items.Count; i++)
        {
            MonoBehaviour itemMB = (MonoBehaviour)items[i];
            if (itemMB.gameObject.TryGetComponent<Button>(out Button butt))//���� �� ��������� � ������� ���� ������ �� ������� ����������
            {
                return;
            }
            else//���� �� ��������� � ������� ��� ������ �� �������� ������ � ���������� � ������� �������
            {
                butt = itemMB.gameObject.AddComponent<Button>();
                butt.onClick.AddListener(() => { Select(butt.gameObject); });//� ������ ������� �������� ����� ������
            }
        }
    }

    private void Select(GameObject gameObject)
    {
        if (select.Contains(gameObject))//���� ���������� ������� ����� ������ ������
        {
            select.Remove(gameObject);
            gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            select.Add(gameObject);
            gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
        ComboCheck();
    }

    private void ComboCheck()
    {
        List<string> selectNames = new List<string>();//�������� ����������� ��� ����
        for (int i = 0; i < select.Count; i++)
        {//������ � ������� � ���� ����� �������� ����������� � ICraft
            string _name = select[i].GetComponent<ICraft>().Name;
            selectNames.Add(_name);
        }

        for (int i = 0; i < CraftSettings.combinatItem.Count; i++)//������� ���� � ������������ �� �������
        {
            CraftCombinat findItem = CraftSettings.combinatItem[i];
            if (findItem.Sources.SequenceEqual(selectNames))//������� �� ����� �� ��������� � ������ �� ��������
            {
                for (int y = 0; y < select.Count; y++)
                {
                    Destroy(select[y]);//����� ��������
                }
                GameObject newObject = Instantiate(findItem.rezult, gridUI);//�������� ����� ������ �� ������� �� ��������
            }
        }
    }

}
