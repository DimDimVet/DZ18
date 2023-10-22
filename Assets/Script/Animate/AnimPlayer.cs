using Unity.Mathematics;
using UnityEngine;
using static EventManager;

public class AnimPlayer : MonoBehaviour
{

    [SerializeField] private AK.Wwise.Event audioEvent;

    [SerializeField] private AnimSettings animSettings;

    private RegistratorConstruction rezultInput;
    //anim
    private float speed;
    private string animSpeed;
    private string animJamp;
    private string animDead;

    private Animator animator;

    private float refDistance = 0.01f;
    private float2 distans;

    private bool isRun;
    private bool IsMoveAK = false;

    private void OnEnable()
    {
        animator = gameObject.GetComponent<Animator>();

        speed = animSettings.Speed;
        animSpeed = animSettings.AnimSpeed;
        animJamp = animSettings.AnimJamp;
        animDead = animSettings.AnimDead;
    }

    private bool ControlGO()
    {
        if (rezultInput.Healt != null)
        {
            return rezultInput.Healt.Dead;
        }
        if (rezultInput.Healt != null)
        {
            return rezultInput.Healt.Dead;
        }
        return false;
    }

    private void GetConnectEvent()//�������� ���������� �� ���������� ������ �� �����
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            rezultInput = GetPlayer();//�������� ������ �� �����

            if (rezultInput.UserInput != null)
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

    private void MoveActiv()
    {
        if (/*PhotonView.Get(this.gameObject).IsMine &&*/ isRun)
        {
            distans.x = Mathf.Abs(rezultInput.UserInput.InputData.Move.x);
            distans.y = Mathf.Abs(rezultInput.UserInput.InputData.Move.y);

            if (distans.x >= refDistance || distans.y >= refDistance)
            {
                if (!IsMoveAK)
                {
                    IsMoveAK=true;
                    audioEvent.Post(this.gameObject);
                }

                animator.SetFloat(animSpeed, speed * math.distancesq(distans.x, -distans.y));
            }
            else
            {
                audioEvent.Stop(this.gameObject);
                IsMoveAK = false;
                animator.SetFloat(animSpeed, 0);
            }

            //pull
            //������� �� ��������, �������� �������� 
            if (rezultInput.UserInput.InputData.Pull > 0f)
            {
                animator.SetBool(animJamp, true);
            }
            else
            {
                animator.SetBool(animJamp, false);
            }

            ////dead
            if (ControlGO())
            {
                animator.SetBool(animDead, true);
            }
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
            MoveActiv();
        }
    }
}
