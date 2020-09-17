using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharController : MonoBehaviour
{
    Animator charAnimator;
    CharacterController characterController;

    public float runSpeed;
    public float rotateSpeed;
    public float jumpSpeed;
    public Vector3 playerVelocity;
    private float gravity = -9.81f;

    private void Awake()
    {
        charAnimator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
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

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
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
            playerVelocity.y += gravity * Time.deltaTime;
        }

        jumpSpeed = GetComponent<Animator>().GetFloat("Jumpspeed");
        playerVelocity.y = jumpSpeed * Time.deltaTime;

        characterController.Move(playerVelocity);
    }

    private void LateUpdate()
    {
   
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
        float rotationOnY = rotateSpeed * mouseAccX;

        transform.Rotate(0, rotationOnY, 0);

        float animatorRotAccValue = charAnimator.GetFloat("RotationAcc");
        EventManager.getInstance().playerEvents.onPlayerTurn.Invoke(Mathf.Lerp(animatorRotAccValue, mouseAccX, 0.1f));
    }
}
