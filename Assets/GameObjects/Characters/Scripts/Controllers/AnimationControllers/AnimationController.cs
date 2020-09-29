using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : CustomMonoBehaviour
{
    public Animator _Animator { get; protected set; }

    protected static int ATTACK = Animator.StringToHash("Attack");
    protected static int MOVE_SPEED = Animator.StringToHash("MoveSpeed");

    protected virtual void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    public virtual void Attack()
    {
        _Animator.SetTrigger(ATTACK);
        //animatorObject.SetFloat("MovementHorizontal", movementHorizontal);
    }

    public virtual void Move(Vector3 direction)
    {
        ResetMoveStates();

        _Animator.SetFloat(MOVE_SPEED, direction.z, 0.1f, Time.deltaTime);
    }

    protected virtual void ResetMoveStates()
    {
    }
}
