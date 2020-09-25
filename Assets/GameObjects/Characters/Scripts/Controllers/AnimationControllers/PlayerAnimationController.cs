using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AnimationController
{
    #region Animation Hashs

    public static int MOVE_HORIZONTAL = Animator.StringToHash("MoveHorizontal");
    public static int MOVE_FORWARD = Animator.StringToHash("MoveForward");
    public static int MOVE_BACKWARD = Animator.StringToHash("MoveBackward");

    public static int MOVEMENT_HORIZONTAL = Animator.StringToHash("MovementHorizontal");

    public static int JUMP = Animator.StringToHash("Jump");
    public static int JUMP_SPEED = Animator.StringToHash("Jumpspeed");

    public static int ROTATION_ACC = Animator.StringToHash("RotationAcc");

    #endregion


    protected override void Start()
    {
        base.Start();

        EventManager.getInstance().playerEvents.onPlayerMove.AddListener(Move);
        EventManager.getInstance().playerEvents.onPlayerPressedShift.AddListener(SetIsRunning);
        EventManager.getInstance().playerEvents.onPlayerAttack.AddListener(Attack);
        EventManager.getInstance().playerEvents.onPlayerJump.AddListener(Jump);
        EventManager.getInstance().playerEvents.onPlayerTurn.AddListener(Turn);
    }

    public void Jump()
    {
        if (_Animator.GetCurrentAnimatorStateInfo(0).GetHashCode() != JUMP)
        {
            _Animator.SetTrigger(JUMP);
        }
    }

    public override void Move(Vector3 direction)
    {
        base.Move(direction);

        _Animator.SetFloat(MOVEMENT_HORIZONTAL, direction.x, 0.2f, Time.deltaTime);

        if (direction.z > 0)
        {
            _Animator.SetBool(MOVE_FORWARD, true);
        }
        else if (direction.z < 0)
        {
            _Animator.SetBool(MOVE_BACKWARD, true);
        }

        if (direction.x > 0 || direction.x < 0)
        {
            _Animator.SetBool(MOVE_HORIZONTAL, true);
        }
    }

    public void Turn(float angularVelocity)
    {
        _Animator.SetFloat(ROTATION_ACC, angularVelocity);
    }

    public void SetIsRunning(bool isRunning)
    {
        if (_Animator.GetBool(MOVE_BACKWARD))
        {
            return;
        }

        if (isRunning)
        {
            _Animator.SetFloat(MOVE_SPEED, 1, 0.1f, Time.deltaTime);
        }
        else
        {
            _Animator.SetFloat(MOVE_SPEED, 0.5f, 0.1f, Time.deltaTime);
        }
    }

    public float GetFloat(int hashKey)
    {
        return _Animator.GetFloat(hashKey);
    }

    protected override void ResetMoveStates()
    {
        base.ResetMoveStates();

        _Animator.SetBool(MOVE_FORWARD, false);
        _Animator.SetBool(MOVE_BACKWARD, false);
        _Animator.SetBool(MOVE_HORIZONTAL, false);
    }
}