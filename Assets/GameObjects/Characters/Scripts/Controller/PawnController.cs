using System.Collections;
using System.Collections.Generic;
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PawnController : MonoBehaviour
{
    private InputControllSystem inputSystemController;

    public PlayerController pawn;

    public void AttachPawn(PlayerController newPawn)
    {
        pawn = newPawn;
        RegisterEvents();
    }

    private void OnEnable()
    {
        inputSystemController.Enable();
        RegisterEvents();
    }

    private void OnDisable()
    {
        inputSystemController.Disable();
    }

    void Awake()
    {
        inputSystemController = new InputControllSystem();
    }

    private void Start()
    {
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        if (pawn == null)
        {
            return;
        }

        inputSystemController.Ground.Movement.performed += ctx => pawn.Move(new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y));
        inputSystemController.Ground.Attack.performed += _ => pawn.Attack();
        inputSystemController.Ground.Jump.performed += _ => pawn.Jump();
    }
}
