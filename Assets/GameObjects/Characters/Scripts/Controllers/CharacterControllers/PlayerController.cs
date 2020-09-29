using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
    CharacterController characterController;

    public PlayerAttributesController PlayerAttributesController { get; private set; }
    public PlayerAnimationController AnimationController { get; private set; }

    public Vector3 playerVelocity;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        PlayerAttributesController = (PlayerAttributesController) AttributesController;
        AnimationController = GetComponent<PlayerAnimationController>();
    }

    void FixedUpdate()
    {
        //TODO THESE WILL BE REMOVED
        /*Move(new Vector3(Input.GetAxis("Horizontal"), 0, Mathf.Clamp(Input.GetAxis("Vertical"), -1, .5f)));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack(Input.GetAxis("Horizontal"));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            EventManager.getInstance().playerEvents.onPlayerPressedShift.Invoke(Input.GetKey(KeyCode.LeftShift));
        }

        CalculateVerticalPosition();

        Turn();*/
    }

    private void CalculateVerticalPosition()
    {
        if (!characterController.isGrounded)
        {
            playerVelocity.y += PlayerAttributesController.Gravity * Time.deltaTime;
        }

        PlayerAttributesController.JumpSpeed = AnimationController.GetFloat(PlayerAnimationController.JUMP_SPEED);
        playerVelocity.y = PlayerAttributesController.JumpSpeed * Time.deltaTime;

        characterController.Move(playerVelocity);
    }

    public void Attack()
    {
        EventManager.getInstance().playerEvents.onPlayerAttack.Invoke();
    }

    public void Jump()
    {
        EventManager.getInstance().playerEvents.onPlayerJump.Invoke();
    }

    public void Move(Vector3 direction)
    {
        EventManager.getInstance().playerEvents.onPlayerMove.Invoke(direction);
    }

    public void Turn()
    {
        //TODO THIS WILL BE HANDLED BY PAWN CONTROLLER
        /*float mouseAccX = Mathf.Clamp(Input.GetAxis("Mouse X"), -1f, 1f);
        float rotationOnY = PlayerAttributesController.RotateSpeed * mouseAccX;

        transform.Rotate(0, rotationOnY, 0);

        float animatorRotAccValue = AnimationController.GetFloat(PlayerAnimationController.ROTATION_ACC);
        EventManager.getInstance().playerEvents.onPlayerTurn.Invoke(Mathf.Lerp(animatorRotAccValue, mouseAccX, 0.1f));*/
    }

    #region Damage

    public override void ApplyDamage(float damage, DamageType damageType)
    {

    }

    #endregion
}