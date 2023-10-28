using Unity.Mathematics;
using UnityEngine;
using static EventManager;

public class MovePlayer :UserInput
{
    [SerializeField] private MoveSettings moveSettings;
    [SerializeField] private Transform cameraPoint;

    public float speedMove;
    private Transform transformCamera;
    private float2 angleCamera;

    public bool isRun = false;//���������� �� ������

    private RegistratorConstruction rezultCamera;

    private void OnEnable()
    {
        speedMove = moveSettings.SpeedMove;
    }

    private void GetConnectEvent()//�������� ���������� �� ���������� ������ �� �����
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            rezultCamera = GetCamera();//�������� ������ �� �����

            if (IsMove && rezultCamera.CameraMove != null)
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

    public void Move()
    {
        if (/*PhotonView.Get(this.gameObject).IsMine &&*/ isRun)//�������� �������������� �������� ������� � ����������
        {
            //������
            if (rezultCamera.CameraMove != null)
            {
                rezultCamera.CameraMove.GetTransformPointCamera = transformCamera;
                angleCamera = rezultCamera.CameraMove.AngleCamera;
                //���
                transform.Rotate(Vector3.up, angleCamera.x);//������� �����
                transformCamera = cameraPoint;
            }

            //������ � ������
            if (InputData.Move.y > 0)
            {
                transform.position += transform.forward / speedMove;
            }
            if (InputData.Move.y < 0)
            {
                
                transform.position -= transform.forward / speedMove;
            }

            if (InputData.Move.x > 0)
            {
               
                transform.position += transform.right / speedMove;
            }
            if (InputData.Move.x < 0)
            {
                
                transform.position -= transform.right / speedMove;
            }

        }
    }
    private void FixedUpdate()
    {
        if (!isRun)//���� ��� ����������, �������� ���������� ����
        {
            GetConnectEvent();
            return;//�� ������������ ���� �� ����� ������ ������ ��������
        }

        //if (IsMove)//���� ���� �������, ������� �����
        //{
            Move();
        //}

    }
}

