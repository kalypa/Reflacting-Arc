using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltBehaviour : GenericBehaviour
{
    public string atkButton = "Reload";
    public int atkRange;
    public int atkBool;
    public int atkDelay;
    public GameObject handSword;
    public GameObject sword;
    public GameObject skill1Effect;
    public GameObject UltimateEffect;
    public bool isAtkCam;
    private int groundedBool;
    private bool atk;                              
    private bool isColliding;
    void Start()
    {
        atkDelay = Animator.StringToHash("Skill Delay");
        atkBool = Animator.StringToHash("Atk");
        groundedBool = Animator.StringToHash("Grounded");
        behaviourManager.GetAnim.SetBool(groundedBool, true);
    }

    void Update()
    {
        if (!atk && Input.GetButtonDown(atkButton) && !behaviourManager.GetAnim.GetBool(atkBool) && behaviourManager.GetAnim.GetFloat(speedFloat) < 0.1)
        {
            if(behaviourManager.GetAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                isAtkCam = true;
                atk = true;
                behaviourManager.OverrideWithBehaviour(this);
                UltManagement();
            }
        }
    }

    void UltManagement()
    {
        if (atk && !behaviourManager.GetAnim.GetBool(atkBool) && behaviourManager.IsGrounded())
        {
            behaviourManager.LockTempBehaviour(this.behaviourCode);         
            behaviourManager.GetAnim.SetBool(atkBool, true);
            Invoke("Ult", 0.8f);
            Invoke("Delay", 1f);
            Invoke("AtkEnd", 3.3f);
        }
    }
    public void AtkEnd()
    {
        behaviourManager.GetAnim.SetBool(atkBool, false);
        handSword.SetActive(false);
        sword.SetActive(true);
        skill1Effect.SetActive(false);
        UltimateEffect.SetActive(false);
        behaviourManager.GetAnim.SetBool(atkDelay, false);
        atk = false;
        behaviourManager.RevokeOverridingBehaviour(this);
    }
    public void AtkDelay()
    {
        handSword.SetActive(true);
        sword.SetActive(false);
        skill1Effect.SetActive(true);
        isAtkCam = false;
    }
    public void Delay()
    {
        behaviourManager.GetAnim.SetBool(atkDelay, true);
    }
    void Ult()
    {
        UltimateEffect.SetActive(true);
    }
}
