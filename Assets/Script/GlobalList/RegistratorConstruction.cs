using Photon.Pun;

public struct RegistratorConstruction//����� ����������� ��� ����������� �����
{
    public int Hash;
    public bool IsDestroyGO { get; set; }
    public ControlInventory ControlInventory;
    public Healt Healt;
    public ShootPlayer ShootPlayer;
    public CameraMove CameraMove;
    public UserInput UserInput;
    public NetworkManager NetworkManager;
    public PickUpItem PickUpItem;
    public PhotonView PhotonView;

}
