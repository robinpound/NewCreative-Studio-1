using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordAttack : MonoBehaviour
{
    //Player
    public GameObject player;
    public Animator animator;

    //Input action
    public InputActions action;

    //Attacking
    public int isAttacking;
    public bool isAttackPressed;
    public bool attack;
    public bool attacking;

    public bool swordEquipped;

    private void Awake()
    {
        //Initializing the input action system
        action = new InputActions();
        if (swordEquipped) 
        {
            //Attack
            action.PlayerActions.SwordAttack.started += OnPlayerAttack;
            action.PlayerActions.SwordAttack.canceled += OnPlayerAttack;
            action.PlayerActions.SwordAttack.performed += OnPlayerAttack;
        }


        //Getting animator component
        animator = GetComponent<Animator>();
        //wiil play animation based on integer value
        isAttacking = Animator.StringToHash("sword");

    }
    private void FixedUpdate()
    {
        AttackAnimation();
    }
    void OnPlayerAttack(InputAction.CallbackContext context)
    {
        isAttackPressed = context.ReadValueAsButton();
        StartCoroutine(Wait());
    }

    public void AttackAnimation()
    {
        attack = animator.GetBool(isAttacking);

        //Walk animation
        if (isAttackPressed && !attack)
        {
            animator.SetBool(isAttacking, true);
            attack = true;
        }
        //Stop walk animation
        else if (!isAttackPressed && attack)
        {
            animator.SetBool(isAttacking, false);
            attack = false;
        }
    }
    IEnumerator Wait()
    {
        attacking = true;
        yield return new WaitForSeconds(2);
        attacking = false;
    }
    private void OnEnable()
    {
        action.PlayerActions.Enable();
    }
    private void OnDisable()
    {
        action.PlayerActions.Disable();
    }
}

