// GENERATED AUTOMATICALLY FROM 'Assets/GameObjects/Characters/Scripts/Controller/InputSystem/InputControllSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControllSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControllSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControllSystem"",
    ""maps"": [
        {
            ""name"": ""Ground"",
            ""id"": ""7e68a9cc-32d8-4ae2-9aad-d4b9ed8f8d12"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ffa47b4d-39ac-4c69-a5d4-3da1403d93ee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f591ee95-f270-47df-b5d0-d28768ec836f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""67b45876-0225-41a4-ad65-0bebbc9592b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bc31cfd5-05f6-4f85-bc9d-0457995b60bb"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f6b20e05-5870-4134-a8f4-929ec27156ae"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a80afbd-0909-4fb6-bc2c-14276654569a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""596160fa-0b74-43f7-8b0c-cfd268bb9073"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""groups"": ""PC"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Axis"",
                    ""id"": ""65a440b0-a8f2-400d-80ff-dadd7a371d82"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""c336bb42-5132-483d-8f6e-82011cfa8304"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""3311ec02-41a3-4d7b-9c62-3414d9577ee0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""cd162318-fa8b-4a57-9ea4-e6649f08b173"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""6a1b9757-117f-4b52-ba98-cdcd9669eb19"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Ground
        m_Ground = asset.FindActionMap("Ground", throwIfNotFound: true);
        m_Ground_Movement = m_Ground.FindAction("Movement", throwIfNotFound: true);
        m_Ground_Attack = m_Ground.FindAction("Attack", throwIfNotFound: true);
        m_Ground_Jump = m_Ground.FindAction("Jump", throwIfNotFound: true);
        m_Ground_Rotate = m_Ground.FindAction("Rotate", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Ground
    private readonly InputActionMap m_Ground;
    private IGroundActions m_GroundActionsCallbackInterface;
    private readonly InputAction m_Ground_Movement;
    private readonly InputAction m_Ground_Attack;
    private readonly InputAction m_Ground_Jump;
    private readonly InputAction m_Ground_Rotate;
    public struct GroundActions
    {
        private @InputControllSystem m_Wrapper;
        public GroundActions(@InputControllSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Ground_Movement;
        public InputAction @Attack => m_Wrapper.m_Ground_Attack;
        public InputAction @Jump => m_Wrapper.m_Ground_Jump;
        public InputAction @Rotate => m_Wrapper.m_Ground_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Ground; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GroundActions set) { return set.Get(); }
        public void SetCallbacks(IGroundActions instance)
        {
            if (m_Wrapper.m_GroundActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GroundActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GroundActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GroundActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_GroundActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GroundActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GroundActionsCallbackInterface.OnAttack;
                @Jump.started -= m_Wrapper.m_GroundActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GroundActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GroundActionsCallbackInterface.OnJump;
                @Rotate.started -= m_Wrapper.m_GroundActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_GroundActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_GroundActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_GroundActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public GroundActions @Ground => new GroundActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IGroundActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
}
