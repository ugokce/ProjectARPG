using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animatorObject;

    private void Start()
    {
        animatorObject = GetComponent<Animator>();
        EventManager.getInstance().playerEvents.onPlayerMove.AddListener(Move);
        EventManager.getInstance().playerEvents.onPlayerPressedShift.AddListener(SetIsRunning);
        EventManager.getInstance().playerEvents.onPlayerAttack.AddListener(Attack);
        EventManager.getInstance().playerEvents.onPlayerJump.AddListener(Jump);
        EventManager.getInstance().playerEvents.onPlayerTurn.AddListener(Turn);
    }

    public void Attack(float movementHorizontal)
    {
        animatorObject.SetTrigger("Attack");
        //animatorObject.SetFloat("MovementHorizontal", movementHorizontal);
    }

    public void Turn(float angularVelocity)
    {
        animatorObject.SetFloat("RotationAcc", angularVelocity);
    }

    public void Move(Vector3 direction)
    {
        resetMoveStates();

        animatorObject.SetFloat("MovementHorizontal", direction.x, 0.2f, Time.deltaTime);
        animatorObject.SetFloat("MoveSpeed", direction.z, 0.1f, Time.deltaTime);

       if (direction.z > 0)
        {
            animatorObject.SetBool("MoveForward", true);
        }
        else if(direction.z < 0)
        {
            animatorObject.SetBool("MoveBackward", true);
        }

       if(direction.x > 0 || direction.x < 0)
        {
            animatorObject.SetBool("MoveHorizontal", true);
        }
    }

    public void Jump()
    {
        if(!animatorObject.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            animatorObject.SetTrigger("Jump");
        }
    }

    public void SetIsRunning(bool isRunning)
    {
        if(animatorObject.GetBool("MoveBackward"))
        {
            return;
        }

        if (isRunning)
        {
            animatorObject.SetFloat("MoveSpeed", 1, 0.1f, Time.deltaTime);
        }
        else
        {
            animatorObject.SetFloat("MoveSpeed", 0.5f, 0.1f, Time.deltaTime);
        }
    }

    private void resetMoveStates()
    {
        animatorObject.SetBool("MoveForward", false);
        animatorObject.SetBool("MoveBackward", false);
        animatorObject.SetBool("MoveHorizontal", false);
    }
}
