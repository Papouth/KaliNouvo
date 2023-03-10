//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Settings/Input System/PlayerMovementInput.inputactions
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

public partial class @PlayerMovementInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerMovementInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerMovementInput"",
    ""maps"": [
        {
            ""name"": ""PlayerMap"",
            ""id"": ""16bfe2a7-9486-4cd8-8132-a5d25d5ace13"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""9e618325-f582-4492-8af3-0645c8dae5c8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f2a93bc9-d57e-4721-9fa0-4b7396a14af1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""e7b91c4b-6809-4f00-88b9-2ad5f895aa5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""ce767d4c-387a-441b-a15c-46bc1ccab678"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Tempo"",
                    ""type"": ""Button"",
                    ""id"": ""4aab2fba-3e5a-489e-b985-e8cdfaab19ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Break"",
                    ""type"": ""Button"",
                    ""id"": ""efabafaa-2529-4e78-9381-c477497c2d6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Osmose"",
                    ""type"": ""Button"",
                    ""id"": ""917770e0-53ee-4475-bf09-6cd203f74a5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ClimbJump"",
                    ""type"": ""Button"",
                    ""id"": ""433f6d40-bd3c-4fe0-9f41-b69aa3bc5915"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Telekinesy"",
                    ""type"": ""Button"",
                    ""id"": ""67edaba9-e781-44a7-bdf5-14e311c1329e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""854916ba-61ea-4f85-addd-09a3d29217f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""4ace2314-4d1a-44ee-9a8a-99d2a2b28cc4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""59e35b97-edc7-4315-b323-ae826e95ab9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseX"",
                    ""type"": ""Value"",
                    ""id"": ""89a802f4-4150-4e81-9d5d-19cb580fddd6"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""Value"",
                    ""id"": ""cf171498-1149-465f-8c83-757c2113038c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6ddd860b-6042-408d-bddf-42124ecf28dd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""34e5cfb1-f9bd-42bb-8848-016da895f0f7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""98126704-79ce-4838-a31a-0816d185d801"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""274bde3a-3f19-47d4-8ead-f7a48e73d258"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f85816be-f9e3-4540-8322-954e7f804f43"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4cdcc1ab-2635-493c-9eea-14bef1c66079"",
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
                    ""id"": ""eea936a3-f895-4b65-bea3-9fb2b6df649a"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19f21dca-3652-4235-9db6-b9e9e0c3230b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73cb61c3-2a7b-4e3c-896b-30c6cf84f9b8"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tempo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68c96919-8c23-4583-83ac-3cf4ea5e85ce"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Break"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""824f73d7-1932-4c8c-893f-efc7d8bacfa5"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Osmose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1b24094-fbd2-423f-9281-04530cb9dc5b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClimbJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8a8900a-dfcf-40c0-a86b-dd8c3fcace43"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Telekinesy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee1ddacf-2ca2-42c4-9ff8-742d6e6fb5a2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""691375fc-0d65-4978-b702-27a37e177240"",
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
                    ""id"": ""6bbb0b76-a655-4bea-b3dc-cdffd24ef413"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cb8651c-2acc-458b-8138-d0fdbc55fd8d"",
                    ""path"": ""<Mouse>/position/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e6e4bc5-eba7-4a85-b9f2-ff76df10e7b8"",
                    ""path"": ""<Mouse>/position/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMap
        m_PlayerMap = asset.FindActionMap("PlayerMap", throwIfNotFound: true);
        m_PlayerMap_Movement = m_PlayerMap.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMap_Jump = m_PlayerMap.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMap_Crouch = m_PlayerMap.FindAction("Crouch", throwIfNotFound: true);
        m_PlayerMap_Interact = m_PlayerMap.FindAction("Interact", throwIfNotFound: true);
        m_PlayerMap_Tempo = m_PlayerMap.FindAction("Tempo", throwIfNotFound: true);
        m_PlayerMap_Break = m_PlayerMap.FindAction("Break", throwIfNotFound: true);
        m_PlayerMap_Osmose = m_PlayerMap.FindAction("Osmose", throwIfNotFound: true);
        m_PlayerMap_ClimbJump = m_PlayerMap.FindAction("ClimbJump", throwIfNotFound: true);
        m_PlayerMap_Telekinesy = m_PlayerMap.FindAction("Telekinesy", throwIfNotFound: true);
        m_PlayerMap_Select = m_PlayerMap.FindAction("Select", throwIfNotFound: true);
        m_PlayerMap_MousePosition = m_PlayerMap.FindAction("MousePosition", throwIfNotFound: true);
        m_PlayerMap_Menu = m_PlayerMap.FindAction("Menu", throwIfNotFound: true);
        m_PlayerMap_MouseX = m_PlayerMap.FindAction("MouseX", throwIfNotFound: true);
        m_PlayerMap_MouseY = m_PlayerMap.FindAction("MouseY", throwIfNotFound: true);
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

    // PlayerMap
    private readonly InputActionMap m_PlayerMap;
    private IPlayerMapActions m_PlayerMapActionsCallbackInterface;
    private readonly InputAction m_PlayerMap_Movement;
    private readonly InputAction m_PlayerMap_Jump;
    private readonly InputAction m_PlayerMap_Crouch;
    private readonly InputAction m_PlayerMap_Interact;
    private readonly InputAction m_PlayerMap_Tempo;
    private readonly InputAction m_PlayerMap_Break;
    private readonly InputAction m_PlayerMap_Osmose;
    private readonly InputAction m_PlayerMap_ClimbJump;
    private readonly InputAction m_PlayerMap_Telekinesy;
    private readonly InputAction m_PlayerMap_Select;
    private readonly InputAction m_PlayerMap_MousePosition;
    private readonly InputAction m_PlayerMap_Menu;
    private readonly InputAction m_PlayerMap_MouseX;
    private readonly InputAction m_PlayerMap_MouseY;
    public struct PlayerMapActions
    {
        private @PlayerMovementInput m_Wrapper;
        public PlayerMapActions(@PlayerMovementInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMap_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerMap_Jump;
        public InputAction @Crouch => m_Wrapper.m_PlayerMap_Crouch;
        public InputAction @Interact => m_Wrapper.m_PlayerMap_Interact;
        public InputAction @Tempo => m_Wrapper.m_PlayerMap_Tempo;
        public InputAction @Break => m_Wrapper.m_PlayerMap_Break;
        public InputAction @Osmose => m_Wrapper.m_PlayerMap_Osmose;
        public InputAction @ClimbJump => m_Wrapper.m_PlayerMap_ClimbJump;
        public InputAction @Telekinesy => m_Wrapper.m_PlayerMap_Telekinesy;
        public InputAction @Select => m_Wrapper.m_PlayerMap_Select;
        public InputAction @MousePosition => m_Wrapper.m_PlayerMap_MousePosition;
        public InputAction @Menu => m_Wrapper.m_PlayerMap_Menu;
        public InputAction @MouseX => m_Wrapper.m_PlayerMap_MouseX;
        public InputAction @MouseY => m_Wrapper.m_PlayerMap_MouseY;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMapActions instance)
        {
            if (m_Wrapper.m_PlayerMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnCrouch;
                @Interact.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnInteract;
                @Tempo.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnTempo;
                @Tempo.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnTempo;
                @Tempo.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnTempo;
                @Break.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnBreak;
                @Break.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnBreak;
                @Break.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnBreak;
                @Osmose.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnOsmose;
                @Osmose.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnOsmose;
                @Osmose.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnOsmose;
                @ClimbJump.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnClimbJump;
                @ClimbJump.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnClimbJump;
                @ClimbJump.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnClimbJump;
                @Telekinesy.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnTelekinesy;
                @Telekinesy.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnTelekinesy;
                @Telekinesy.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnTelekinesy;
                @Select.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSelect;
                @MousePosition.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMousePosition;
                @Menu.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMenu;
                @MouseX.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMouseX;
                @MouseX.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMouseX;
                @MouseX.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMouseX;
                @MouseY.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMouseY;
                @MouseY.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMouseY;
                @MouseY.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMouseY;
            }
            m_Wrapper.m_PlayerMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Tempo.started += instance.OnTempo;
                @Tempo.performed += instance.OnTempo;
                @Tempo.canceled += instance.OnTempo;
                @Break.started += instance.OnBreak;
                @Break.performed += instance.OnBreak;
                @Break.canceled += instance.OnBreak;
                @Osmose.started += instance.OnOsmose;
                @Osmose.performed += instance.OnOsmose;
                @Osmose.canceled += instance.OnOsmose;
                @ClimbJump.started += instance.OnClimbJump;
                @ClimbJump.performed += instance.OnClimbJump;
                @ClimbJump.canceled += instance.OnClimbJump;
                @Telekinesy.started += instance.OnTelekinesy;
                @Telekinesy.performed += instance.OnTelekinesy;
                @Telekinesy.canceled += instance.OnTelekinesy;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @MouseX.started += instance.OnMouseX;
                @MouseX.performed += instance.OnMouseX;
                @MouseX.canceled += instance.OnMouseX;
                @MouseY.started += instance.OnMouseY;
                @MouseY.performed += instance.OnMouseY;
                @MouseY.canceled += instance.OnMouseY;
            }
        }
    }
    public PlayerMapActions @PlayerMap => new PlayerMapActions(this);
    public interface IPlayerMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnTempo(InputAction.CallbackContext context);
        void OnBreak(InputAction.CallbackContext context);
        void OnOsmose(InputAction.CallbackContext context);
        void OnClimbJump(InputAction.CallbackContext context);
        void OnTelekinesy(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
    }
}
