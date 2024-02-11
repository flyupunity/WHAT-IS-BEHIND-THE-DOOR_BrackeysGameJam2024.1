//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""MovePlayer"",
            ""id"": ""0a5b706e-c6be-4c5c-a0d1-f5871e0e889e"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ecab5453-b3d4-4fc2-9d3d-1d57666a8aba"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""914d57a9-72ad-49d9-aec1-e19666f659bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""ee5f83bb-89d3-4c38-89e9-f53aaa2c6332"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""a4dd81d3-f13b-40c9-8cc1-9403c5c06e94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""61db9ce6-57e5-4ca5-ae3e-1077136a799e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Creeper"",
                    ""type"": ""Button"",
                    ""id"": ""378eb0d1-49f4-4b99-83c2-6b31bef1ce4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Axis"",
                    ""id"": ""416c0355-326f-4a72-9bec-de71eaa4468a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8388a2e1-10d7-41d3-8404-b04719c53c0b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b6c54211-e690-456e-959e-a47ebde10e8a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7e5136fa-aa4a-44db-be9f-93fa4399d8d0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38f51ec9-898f-4ab2-9e5d-287dcdc4b576"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4db0132-9066-477e-a0fd-bb467ad4a8e0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b05f6d4-bc8a-41e3-bec1-2ffec246cdf4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e791f766-a5a6-4fe5-bddf-cd552d72215a"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94613a0a-1d44-40c8-b64c-c1edbee0f547"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Creeper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MovePlayer
        m_MovePlayer = asset.FindActionMap("MovePlayer", throwIfNotFound: true);
        m_MovePlayer_Horizontal = m_MovePlayer.FindAction("Horizontal", throwIfNotFound: true);
        m_MovePlayer_Jump = m_MovePlayer.FindAction("Jump", throwIfNotFound: true);
        m_MovePlayer_Crouch = m_MovePlayer.FindAction("Crouch", throwIfNotFound: true);
        m_MovePlayer_Shoot = m_MovePlayer.FindAction("Shoot", throwIfNotFound: true);
        m_MovePlayer_MousePosition = m_MovePlayer.FindAction("MousePosition", throwIfNotFound: true);
        m_MovePlayer_Creeper = m_MovePlayer.FindAction("Creeper", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MovePlayer
    private readonly InputActionMap m_MovePlayer;
    private List<IMovePlayerActions> m_MovePlayerActionsCallbackInterfaces = new List<IMovePlayerActions>();
    private readonly InputAction m_MovePlayer_Horizontal;
    private readonly InputAction m_MovePlayer_Jump;
    private readonly InputAction m_MovePlayer_Crouch;
    private readonly InputAction m_MovePlayer_Shoot;
    private readonly InputAction m_MovePlayer_MousePosition;
    private readonly InputAction m_MovePlayer_Creeper;
    public struct MovePlayerActions
    {
        private @Controls m_Wrapper;
        public MovePlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_MovePlayer_Horizontal;
        public InputAction @Jump => m_Wrapper.m_MovePlayer_Jump;
        public InputAction @Crouch => m_Wrapper.m_MovePlayer_Crouch;
        public InputAction @Shoot => m_Wrapper.m_MovePlayer_Shoot;
        public InputAction @MousePosition => m_Wrapper.m_MovePlayer_MousePosition;
        public InputAction @Creeper => m_Wrapper.m_MovePlayer_Creeper;
        public InputActionMap Get() { return m_Wrapper.m_MovePlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovePlayerActions set) { return set.Get(); }
        public void AddCallbacks(IMovePlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_MovePlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovePlayerActionsCallbackInterfaces.Add(instance);
            @Horizontal.started += instance.OnHorizontal;
            @Horizontal.performed += instance.OnHorizontal;
            @Horizontal.canceled += instance.OnHorizontal;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @MousePosition.started += instance.OnMousePosition;
            @MousePosition.performed += instance.OnMousePosition;
            @MousePosition.canceled += instance.OnMousePosition;
            @Creeper.started += instance.OnCreeper;
            @Creeper.performed += instance.OnCreeper;
            @Creeper.canceled += instance.OnCreeper;
        }

        private void UnregisterCallbacks(IMovePlayerActions instance)
        {
            @Horizontal.started -= instance.OnHorizontal;
            @Horizontal.performed -= instance.OnHorizontal;
            @Horizontal.canceled -= instance.OnHorizontal;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @MousePosition.started -= instance.OnMousePosition;
            @MousePosition.performed -= instance.OnMousePosition;
            @MousePosition.canceled -= instance.OnMousePosition;
            @Creeper.started -= instance.OnCreeper;
            @Creeper.performed -= instance.OnCreeper;
            @Creeper.canceled -= instance.OnCreeper;
        }

        public void RemoveCallbacks(IMovePlayerActions instance)
        {
            if (m_Wrapper.m_MovePlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovePlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_MovePlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovePlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovePlayerActions @MovePlayer => new MovePlayerActions(this);
    public interface IMovePlayerActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnCreeper(InputAction.CallbackContext context);
    }
}
