using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBehaviour : GenericBehaviour
{
    public enum AnimationState
    {
        None,
        Atk1,
        Atk2,
        Atk3,
        Atk4,
        AtkOver
    }

    public string atkButton = "Fire1";
    public int atkRange;
    public int atkBool;
    public int atkState;
    public GameObject handSword;
    public GameObject sword;
    public GameObject atk1Effect;
    public GameObject atk2Effect;
    public GameObject atk3Effect;
    public GameObject atk4Effect;
    public AnimationState state;
    public bool isAtkCam;
    public bool atk;


    private int groundedBool;
    private bool isColliding;
    private bool isClick = false;
    private int atkchanger = 0;
    // Start is called before the first frame update
    void Start()
    {
        state = AnimationState.None;
        atkBool = Animator.StringToHash("Atk");
        atkState = Animator.StringToHash("AtkState");
        groundedBool = Animator.StringToHash("Grounded");
        behaviourManager.GetAnim.SetBool(groundedBool, true);
        //behaviourManager.SubscribeBehaviour(this);
        //behaviourManager.RegisterDefaultBehaviour(this.behaviourCode);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !behaviourManager.GetAnim.GetBool(atkBool) && behaviourManager.GetAnim.GetFloat(speedFloat) < 0.1)
        {
            AtkManagement();
            if (!isClick)
            {
                AtkStateChange();
                handSword.SetActive(true);
                sword.SetActive(false);
            }
        }
    }
    
    void AtkManagement()
    {
        if (atk && !behaviourManager.GetAnim.GetBool(atkBool) && behaviourManager.IsGrounded())
        {
            behaviourManager.OverrideWithBehaviour(this);
        }
    }
    public void AtkEnd()
    {
        behaviourManager.RevokeOverridingBehaviour(this);
    }
    void AtkStateChange()
    {
        switch (state)
        {
            case AnimationState.None:
                if (behaviourManager.GetAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && state != AnimationState.AtkOver)
                {
                    atk1Effect.SetActive(true);
                    behaviourManager.GetAnim.SetInteger("AtkState", 1);
                    state = AnimationState.Atk1;
                }
                break;
            case AnimationState.Atk1:
                if (behaviourManager.GetAnim.GetCurrentAnimatorStateInfo(0).IsName("Atk1") && state != AnimationState.AtkOver)
                {
                    atk2Effect.SetActive(true);
                    behaviourManager.GetAnim.SetInteger("AtkState", 2);
                    state = AnimationState.Atk2;
                }
                break;
            case AnimationState.Atk2:
                if (behaviourManager.GetAnim.GetCurrentAnimatorStateInfo(0).IsName("Atk2") && state != AnimationState.AtkOver)
                {
                    atk1Effect.SetActive(false);
                    atk2Effect.SetActive(false);
                    atk3Effect.SetActive(true);
                    behaviourManager.GetAnim.SetInteger("AtkState", 3);
                    state = AnimationState.Atk3;
                }
                break;
            case AnimationState.Atk3:
                if (behaviourManager.GetAnim.GetCurrentAnimatorStateInfo(0).IsName("Atk3") && state != AnimationState.AtkOver)
                {
                    atk3Effect.SetActive(false);
                    atk4Effect.SetActive(true);
                    behaviourManager.GetAnim.SetInteger("AtkState", 4);
                    state = AnimationState.Atk4;
                }
                break;
        }
    }
    public void OneClick()
    {
        isClick = false;
    }
}
