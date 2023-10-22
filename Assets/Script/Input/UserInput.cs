using UnityEngine;

public class UserInput : MonoBehaviour
{
    private InputData inputData;//��������� ������
    public InputData InputData { get { return inputData; } /*set { inputData = value; }*/ }

    private bool isMove=true;//���������� �� ������� ��������
    public bool IsMove { get { return isMove; } /*set { isMove = value; }*/ }

    private MapCurrent inputAction;//��� ���������� ������ MapCurrent(new input)

    private void Start()
    {
        inputAction = new MapCurrent();//�������������� ����� input
        inputData = new InputData();

        if (inputAction != null)//�������� �� null
        {
            //�������� �� event ������� ������� � �������� �������� ��������� ���������
            inputAction.UIMap.WASD.performed += context =>
            {
                inputData.Move = context.ReadValue<Vector2>();
                //if (context.ReadValue<Vector2>() != null) { isMove = true; } else{isMove = false;}
            };
            inputAction.UIMap.WASD.started += context =>
            {
                inputData.Move = context.ReadValue<Vector2>();
                //if (context.ReadValue<Vector2>() != null) { isMove = true; }else{isMove = false;}
            };
            inputAction.UIMap.WASD.canceled += context =>
            {
                inputData.Move = context.ReadValue<Vector2>();
                //if (context.ReadValue<Vector2>() != null) { isMove = false; }else{isMove = true;}
            };

            inputAction.Map.WASD.performed += context =>
            {
                inputData.Move = context.ReadValue<Vector2>();
                //if (context.ReadValue<Vector2>() != null) { isMove = true; } else { isMove = false; }
            };
            inputAction.Map.WASD.started += context =>
            {
                inputData.Move = context.ReadValue<Vector2>();
                //if (context.ReadValue<Vector2>() != null) { isMove = true; }else{isMove = false;}
            };
            inputAction.Map.WASD.canceled += context =>
            {
                inputData.Move = context.ReadValue<Vector2>();
                //if (context.ReadValue<Vector2>() != null) { isMove = false; }else{isMove = true;}
            };

            inputAction.Map.Look.performed += context =>
            {
                inputData.Mouse = context.ReadValue<Vector2>();
                //if (context.ReadValue<Vector2>() != null) { isMove = true; }else{isMove = false;}
            };
            inputAction.Map.Look.started += context =>
            {
                inputData.Mouse = context.ReadValue<Vector2>();
                //if (context.ReadValue<Vector2>() != null) { isMove = true; }else{isMove = false;}
            };
            inputAction.Map.Look.canceled += context =>
            {
                inputData.Mouse = context.ReadValue<Vector2>();
                //if (context.ReadValue<Vector2>() != null) { isMove = false; }else{isMove = true;}
            };

            inputAction.Map.Shoot.performed += context => { inputData.Shoot = context.ReadValue<float>(); };
            inputAction.Map.Shoot.started += context => { inputData.Shoot = context.ReadValue<float>(); };
            inputAction.Map.Shoot.canceled += context => { inputData.Shoot = context.ReadValue<float>(); };

            inputAction.Map.Pull.performed += context => { inputData.Pull = context.ReadValue<float>(); };
            inputAction.Map.Pull.started += context => { inputData.Pull = context.ReadValue<float>(); };
            inputAction.Map.Pull.canceled += context => { inputData.Pull = context.ReadValue<float>(); };

            inputAction.Map.ModePlayer.performed += context => { inputData.Mode = context.ReadValue<float>(); };
            inputAction.Map.ModePlayer.started += context => { inputData.Mode = context.ReadValue<float>(); };
            inputAction.Map.ModePlayer.canceled += context => { inputData.Mode = context.ReadValue<float>(); };

            //�������� 
            inputAction.Enable();
        }
        else
        {
            Debug.LogError("��� ����� � ������� MapCurrent");
        }
    }

}
