using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        PlayerAttributesController = (PlayerAttributesController)AttributesController;
        AnimationController = GetComponent<PlayerAnimationController>();
    }

    void FixedUpdate()
    {
        Move(new Vector3(Input.GetAxis("Horizontal"), 0, Mathf.Clamp(Input.GetAxis("Vertical"), -1, .5f)));

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

        Turn();
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

    void Attack(float movementHorizontal)
    {
        EventManager.getInstance().playerEvents.onPlayerAttack.Invoke(movementHorizontal);
    }

    void Jump()
    {
        EventManager.getInstance().playerEvents.onPlayerJump.Invoke();
    }

    void Move(Vector3 direction)
    {
        EventManager.getInstance().playerEvents.onPlayerMove.Invoke(direction);
    }

    void Turn()
    {
        float mouseAccX = Mathf.Clamp(Input.GetAxis("Mouse X"), -1f, 1f);
        float rotationOnY = PlayerAttributesController.RotateSpeed * mouseAccX;

        transform.Rotate(0, rotationOnY, 0);

        float animatorRotAccValue = AnimationController.GetFloat(PlayerAnimationController.ROTATION_ACC);
        EventManager.getInstance().playerEvents.onPlayerTurn.Invoke(Mathf.Lerp(animatorRotAccValue, mouseAccX, 0.1f));
    }

    #region IDamage

    public override void ApplyDamage(IList<AppliedDamageInfo> appliedDamageInfos, DamageType damageType, GameObject damageSource = null)
    {
        if(!IsDamageable)
        {
            return;
        }

        base.ApplyDamage(appliedDamageInfos, damageType, damageSource);

        appliedDamageInfos.DoForAll(appliedDamageInfo =>
        {
            // TODO: Handle status effect damages
        });

        float damageAmount = appliedDamageInfos.Sum(x => x.amount);

        PlayerAttributesController.Health -= damageAmount;

        if (PlayerAttributesController.Health < 1)
        {
            IsDamageable = false;
            Die();
        }
    }

    public override void AddStatus(DamageStatusType damageStatusType)
    {
        base.AddStatus(damageStatusType);

        // TODO: Add status effect logic
    }

    public override void RemoveStatus(DamageStatusType damageStatusType)
    {
        base.RemoveStatus(damageStatusType);

        // TODO: Remove status effect logic
    }

    #endregion

    public override void Die()
    {
        base.Die();
    }
}