using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerSample;
    public List<Transform> SpawnPonts;
    private int id;
    //
    public List<GameObject> InterObject;
    public List<Transform> InterTransformObject;

    private List<RegistratorConstruction> rezultList;

    private GameObject tempDestroy;

    //Bulls
    public List<GameObject> bulls;

    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();//�������� �������� ������-������
    }

    //������� � �������� OnConnectedToMaster() ��� �������� ��������� ������-�������
    public override void OnConnectedToMaster()
    {
        //������� �������.��������, ������� ���������, ������ ��������
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 4,
            IsVisible = false
        };
        //��� ������, ���� �������, ��� �� ��������� - ������� � �������.�����������
        PhotonNetwork.JoinOrCreateRoom("TestDZ13", roomOptions, TypedLobby.Default);
    }

    //������� � �������� OnJoinedRoom()
    public override void OnJoinedRoom()
    {
        id = PhotonNetwork.LocalPlayer.ActorNumber;

        //�������� �� ������ ����������
        if (id > (SpawnPonts.Count + 1))
        {
            Debug.Log("��� ��������� �����");
        }
        else
        {
            GameObject tr = PhotonNetwork.Instantiate(PlayerSample.name, SpawnPonts[id - 1].position, Quaternion.identity);
            tr.name = $"Id {id}";
            if (id == 1)//GO
            {
                for (int i = 0; i < InterTransformObject.Count; i++)
                {

                    PhotonNetwork.Instantiate(InterObject[i].name, InterTransformObject[i].position, Quaternion.identity);
                }
            }
        }
    }

    public void BullInst(Transform outPoint)
    {
        for (int i = 0; i < bulls.Count; i++)
        {
            if (bulls[i] != null)
            {
                PhotonNetwork.Instantiate(bulls[i].name, outPoint.position, outPoint.rotation);
            }
        }

    }

    public void DestroyThisGO(GameObject go)
    {
        if (tempDestroy == go)
        {
            return;
        }
        else
        {
            tempDestroy = go;
            if (PhotonView.Get(go).IsMine)
            {
                PhotonNetwork.Destroy(go);
            }
            else
            {
                this.photonView.RPC("DestroyGO", RpcTarget.All, (int)PhotonView.Get(go).ViewID);
            }
        }
    }

    [PunRPC]//��� ���� ���� ����� ���� � ������ ������
    public void DestroyGO(int go)
    {
        // rezultList = GetDataList();

        for (int i = 0; i < rezultList.Count; i++)
        {
            if (rezultList[i].Healt != null)
            {
                rezultList[i].Healt.DestoyGO();
            }
        }
    }

    public void DestroyThisLut(GameObject go)
    {
        if (tempDestroy == go)
        {
            return;
        }
        else
        {
            tempDestroy = go;

            if (PhotonView.Get(go).IsMine)
            {
                PhotonNetwork.Destroy(go);
            }
            else
            {
                this.photonView.RPC("DestroyGO", RpcTarget.All, (int)PhotonView.Get(go).ViewID);
            }
        }
    }

    [PunRPC]//��� ���� ���� ����� ���� � ������ ������
    public void DestroyLut(int go)
    {
        // rezultList = GetDataList();

        for (int i = 0; i < rezultList.Count; i++)
        {

            if (rezultList[i].PickUpItem != null)
            {
                rezultList[i].PickUpItem.DestoyGO();
            }


        }

    }
    public void SayHello()//������� ������ ��������� �������� �����
    {
        //����� photonView �������� ����������� ������, ��������� ��������� �� gameobject(�����������) � �������
        //������ ��������� � ����������:�������������

        //��� ������ ������,������ ��������,������ ������������ ���������(� ������� ����� ���� ���������� �������)
        this.photonView.RPC("Hello", RpcTarget.All, (byte)PhotonNetwork.LocalPlayer.ActorNumber);
    }

    [PunRPC]//��� ���� ���� ����� ���� � ������ ������
    public void Hello(byte playerId)
    {
        Debug.Log($"����� ID {playerId} ������� ������");
    }

}
