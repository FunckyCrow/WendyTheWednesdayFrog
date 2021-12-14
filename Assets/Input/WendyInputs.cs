//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Input/WendyInputs.inputactions
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

public partial class @WendyInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @WendyInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""WendyInputs"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""3302ff7e-eca5-4f9b-bf86-2c7145d600bb"",
            ""actions"": [
                {
                    ""name"": ""JumpPress"",
                    ""type"": ""Button"",
                    ""id"": ""942e05f4-ef68-43f8-8752-33bb6ff40fdf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TonguePress"",
                    ""type"": ""Button"",
                    ""id"": ""24645515-2994-47ca-9ca9-6b2279e63fcf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Direction"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dcc3db60-7ea6-42d9-8244-09a6dda8856e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""JumpRelease"",
                    ""type"": ""Button"",
                    ""id"": ""54a8374b-72e4-4b0b-a19b-087fb60ad1d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TongueRelease"",
                    ""type"": ""Button"",
                    ""id"": ""c931215e-0575-4016-9ad1-3bcb347965f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9596b7b4-177f-4017-9f78-82873e5a5828"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""66356fd4-837d-4c9c-992a-f838bc09fe89"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""JumpPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd2c276e-0bd7-490e-8a97-9016f18f0952"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""JumpPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa1e8681-2694-428e-8998-05dae9f2b5c1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""JumpPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa1381dd-55f0-46e4-8e13-41528b0b2a44"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""JumpPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16a17b52-0d3b-4839-a47b-d248d2a82bdf"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""WendyKeyboard"",
                    ""action"": ""JumpPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7282cac1-b637-4467-a523-ca1c064f5615"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""WendyMobile"",
                    ""action"": ""JumpPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""519472ac-4256-44d5-a802-2e4abab1edaf"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""TonguePress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72fa15f5-0cee-4599-843a-81389a0b113f"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""TonguePress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffd33bd3-1474-4c4e-bb45-f69b178f6ada"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""TonguePress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d948d7f2-25b6-4941-b80f-8796550010cc"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""TonguePress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left Stick"",
                    ""id"": ""e02b3d0f-80c0-49f7-ae95-08849c41d60b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""78cbc1b8-7f04-4a3a-9f05-ae8025fa4fe4"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""94ee08ef-7932-42b3-a590-f06278909633"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3d5bf126-86eb-4d96-a63e-674d849b5574"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""136c992a-7153-4799-ba94-ab16539ceb42"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1eb9b482-42de-4f1b-8f61-afe38d93c7ba"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2441b82b-1da2-4534-9340-4127c6e784d4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""JumpRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e905edb-230e-4360-a53d-7db616c5a65b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""JumpRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc85749d-df4c-4c72-b093-aebf8f9e7f5a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""JumpRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33b614e3-0e09-4635-a7ac-46b30cd1bf78"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""JumpRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e508966-7e14-4a71-8e09-fe7805ae51a7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""TongueRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90a18bb0-3072-4709-aa8e-4f6611374965"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""TongueRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9355417-7495-45ca-a091-23c1fb86e852"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""TongueRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e34f9faf-c6e7-40f1-b346-11ba1ee0b058"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""WendyController"",
                    ""action"": ""TongueRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8172ff37-39e6-49f2-8096-f06ed2190c17"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WendyKeyboard"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""155e90fc-c2d0-4198-a854-b18a6d4873f4"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WendyMobile"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab20d97f-6978-4669-aef2-379716c12041"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""WendyKeyboard"",
                    ""action"": ""TonguePress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20c6a4ca-51b8-4cb1-b24d-1e9f24ab9d64"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""WendyKeyboard"",
                    ""action"": ""JumpRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""241b43b1-6912-40e0-888d-a2ec2e8acc17"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""WendyKeyboard"",
                    ""action"": ""TongueRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2521070-1808-4777-9029-a867d1f7a0dd"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""WendyMobile"",
                    ""action"": ""TonguePress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eaa58d34-3c18-45c0-acf5-f40ddc81cdef"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""WendyMobile"",
                    ""action"": ""JumpRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac2229d6-bb0a-47f8-b2c0-f8723e3c2e12"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""WendyMobile"",
                    ""action"": ""TongueRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""WendyKeyboard"",
            ""bindingGroup"": ""WendyKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""WendyController"",
            ""bindingGroup"": ""WendyController"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""WendyMobile"",
            ""bindingGroup"": ""WendyMobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_JumpPress = m_CharacterControls.FindAction("JumpPress", throwIfNotFound: true);
        m_CharacterControls_TonguePress = m_CharacterControls.FindAction("TonguePress", throwIfNotFound: true);
        m_CharacterControls_Direction = m_CharacterControls.FindAction("Direction", throwIfNotFound: true);
        m_CharacterControls_JumpRelease = m_CharacterControls.FindAction("JumpRelease", throwIfNotFound: true);
        m_CharacterControls_TongueRelease = m_CharacterControls.FindAction("TongueRelease", throwIfNotFound: true);
        m_CharacterControls_Position = m_CharacterControls.FindAction("Position", throwIfNotFound: true);
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

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_JumpPress;
    private readonly InputAction m_CharacterControls_TonguePress;
    private readonly InputAction m_CharacterControls_Direction;
    private readonly InputAction m_CharacterControls_JumpRelease;
    private readonly InputAction m_CharacterControls_TongueRelease;
    private readonly InputAction m_CharacterControls_Position;
    public struct CharacterControlsActions
    {
        private @WendyInputs m_Wrapper;
        public CharacterControlsActions(@WendyInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @JumpPress => m_Wrapper.m_CharacterControls_JumpPress;
        public InputAction @TonguePress => m_Wrapper.m_CharacterControls_TonguePress;
        public InputAction @Direction => m_Wrapper.m_CharacterControls_Direction;
        public InputAction @JumpRelease => m_Wrapper.m_CharacterControls_JumpRelease;
        public InputAction @TongueRelease => m_Wrapper.m_CharacterControls_TongueRelease;
        public InputAction @Position => m_Wrapper.m_CharacterControls_Position;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @JumpPress.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJumpPress;
                @JumpPress.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJumpPress;
                @JumpPress.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJumpPress;
                @TonguePress.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnTonguePress;
                @TonguePress.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnTonguePress;
                @TonguePress.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnTonguePress;
                @Direction.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnDirection;
                @Direction.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnDirection;
                @Direction.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnDirection;
                @JumpRelease.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJumpRelease;
                @TongueRelease.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnTongueRelease;
                @TongueRelease.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnTongueRelease;
                @TongueRelease.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnTongueRelease;
                @Position.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPosition;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JumpPress.started += instance.OnJumpPress;
                @JumpPress.performed += instance.OnJumpPress;
                @JumpPress.canceled += instance.OnJumpPress;
                @TonguePress.started += instance.OnTonguePress;
                @TonguePress.performed += instance.OnTonguePress;
                @TonguePress.canceled += instance.OnTonguePress;
                @Direction.started += instance.OnDirection;
                @Direction.performed += instance.OnDirection;
                @Direction.canceled += instance.OnDirection;
                @JumpRelease.started += instance.OnJumpRelease;
                @JumpRelease.performed += instance.OnJumpRelease;
                @JumpRelease.canceled += instance.OnJumpRelease;
                @TongueRelease.started += instance.OnTongueRelease;
                @TongueRelease.performed += instance.OnTongueRelease;
                @TongueRelease.canceled += instance.OnTongueRelease;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);
    private int m_WendyKeyboardSchemeIndex = -1;
    public InputControlScheme WendyKeyboardScheme
    {
        get
        {
            if (m_WendyKeyboardSchemeIndex == -1) m_WendyKeyboardSchemeIndex = asset.FindControlSchemeIndex("WendyKeyboard");
            return asset.controlSchemes[m_WendyKeyboardSchemeIndex];
        }
    }
    private int m_WendyControllerSchemeIndex = -1;
    public InputControlScheme WendyControllerScheme
    {
        get
        {
            if (m_WendyControllerSchemeIndex == -1) m_WendyControllerSchemeIndex = asset.FindControlSchemeIndex("WendyController");
            return asset.controlSchemes[m_WendyControllerSchemeIndex];
        }
    }
    private int m_WendyMobileSchemeIndex = -1;
    public InputControlScheme WendyMobileScheme
    {
        get
        {
            if (m_WendyMobileSchemeIndex == -1) m_WendyMobileSchemeIndex = asset.FindControlSchemeIndex("WendyMobile");
            return asset.controlSchemes[m_WendyMobileSchemeIndex];
        }
    }
    public interface ICharacterControlsActions
    {
        void OnJumpPress(InputAction.CallbackContext context);
        void OnTonguePress(InputAction.CallbackContext context);
        void OnDirection(InputAction.CallbackContext context);
        void OnJumpRelease(InputAction.CallbackContext context);
        void OnTongueRelease(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
    }
}
