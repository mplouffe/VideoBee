//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Inputs/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Level"",
            ""id"": ""40037e2d-683a-44a6-a540-99896bd25c37"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""016dde40-036a-4997-8776-97c117a20ba1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""f806d52f-c16c-4c13-909d-10c35ed610a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""cf1ddfc9-d9b7-4301-bb8b-25fab4add8e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b386ed4d-ea0c-42cb-a31f-cb932264a35e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""94d01c4a-1c4b-4b01-83c9-1db022d9b1c2"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2204a17f-20c7-447e-a571-51794faa1543"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6ce7963f-6732-4593-978b-962e2db0a9fa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4ea52240-3d8d-4a49-95e6-eab226e52c83"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d3a3c7fa-37ff-42f8-8152-dd08244ed50b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e8a05f51-e16c-422c-a07d-9d3ef4cd799b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""084595af-d6aa-44c8-9791-14233d4711cd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2dde7e20-dcbd-4ce5-8072-b8a5ef89334a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48d3a935-8de4-464b-b7a7-66a769413b0d"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b9f57f1-e8b8-42a5-9199-6bcbc4e514f6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97a267b8-f940-4729-adf1-d4738f350ef4"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbf2b535-4053-4170-980c-a9c5c21333bb"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SettingsScreen"",
            ""id"": ""7b8a8511-5d8c-4a62-bab5-7ba79788af96"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""ccfabf68-ead1-4daf-aa3f-61f82f81197b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a25727fd-d2fc-49ff-9fe8-97801e27c5ae"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bc9853e-378a-4fb2-a65f-317cb6e1a322"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""55392eb1-dcc9-4885-a01f-aede2b44e1a5"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""1c454285-5522-46ad-bdf7-b9c5e2b8d2f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""50f5d361-4a1f-4de8-a22d-a84601d5af23"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""fe1889bb-22ac-4490-b591-4beb1cddb842"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""98c71e11-4bd1-461a-9689-cb606daa4d89"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dc9ff2b-0674-4294-8eb7-bc9d3117cf8d"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa52ce6b-d91a-4582-8dea-e99f80fd81de"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e775e46d-8afd-4c07-996c-756456e758b7"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""187703ee-8a0d-4e51-9373-fd89ceb0b4a5"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""75d0dba6-a372-4d24-8efa-c158d781ea5f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1f2adfea-0dd4-4c67-bfe1-67b81d6b3cad"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9040094b-d726-436d-bf2d-d69cab3b4c29"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f5b6eaf8-f829-4fc7-93fa-bfc489384c35"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7d55707d-7609-4d4b-b3e5-c382daf65c90"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""EscapeMenu"",
            ""id"": ""77844f76-d94c-4b84-bdf9-9507dc5e71c5"",
            ""actions"": [
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""8a0f7919-4a09-4dcd-b7df-80d24fd2c4ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""5aba53ab-e0e1-4dae-bd8e-561f0dd9e9b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""820b2f0c-9963-42e5-9742-864d0308d158"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0d57229-621a-4845-9891-c94808495c13"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""247a3497-e026-4e9b-8ae0-87b9b09c80df"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""237b0dfa-5b99-4bca-ba1d-48cd32f824a5"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseMenu"",
            ""id"": ""922c8ec9-b389-40da-a3dd-6fd77f7a8a63"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""78327327-c4bb-426f-85bc-ac1256da192a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b86994bc-5a94-42bc-8566-017fb8dd39e0"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ab5067d-bfb5-47df-8e86-16bb77975708"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Instructions"",
            ""id"": ""4d79712a-a10c-4dc6-8497-014eeb40629c"",
            ""actions"": [
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""82fc723b-764c-4388-8da0-006f88a6ad04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""27a50346-b582-4be0-9bcf-a45870a749b7"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58e90508-43a8-4fcd-a26c-53e1a828ca62"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1631d2c5-15c1-4798-b304-c5d6b61d23d0"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""722b33af-9271-4f87-8a2c-8a477586928a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Level
        m_Level = asset.FindActionMap("Level", throwIfNotFound: true);
        m_Level_Move = m_Level.FindAction("Move", throwIfNotFound: true);
        m_Level_Boost = m_Level.FindAction("Boost", throwIfNotFound: true);
        m_Level_Escape = m_Level.FindAction("Escape", throwIfNotFound: true);
        m_Level_Pause = m_Level.FindAction("Pause", throwIfNotFound: true);
        // SettingsScreen
        m_SettingsScreen = asset.FindActionMap("SettingsScreen", throwIfNotFound: true);
        m_SettingsScreen_Back = m_SettingsScreen.FindAction("Back", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_Select = m_MainMenu.FindAction("Select", throwIfNotFound: true);
        m_MainMenu_Escape = m_MainMenu.FindAction("Escape", throwIfNotFound: true);
        m_MainMenu_Move = m_MainMenu.FindAction("Move", throwIfNotFound: true);
        // EscapeMenu
        m_EscapeMenu = asset.FindActionMap("EscapeMenu", throwIfNotFound: true);
        m_EscapeMenu_Confirm = m_EscapeMenu.FindAction("Confirm", throwIfNotFound: true);
        m_EscapeMenu_Cancel = m_EscapeMenu.FindAction("Cancel", throwIfNotFound: true);
        // PauseMenu
        m_PauseMenu = asset.FindActionMap("PauseMenu", throwIfNotFound: true);
        m_PauseMenu_Pause = m_PauseMenu.FindAction("Pause", throwIfNotFound: true);
        // Instructions
        m_Instructions = asset.FindActionMap("Instructions", throwIfNotFound: true);
        m_Instructions_Confirm = m_Instructions.FindAction("Confirm", throwIfNotFound: true);
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

    // Level
    private readonly InputActionMap m_Level;
    private ILevelActions m_LevelActionsCallbackInterface;
    private readonly InputAction m_Level_Move;
    private readonly InputAction m_Level_Boost;
    private readonly InputAction m_Level_Escape;
    private readonly InputAction m_Level_Pause;
    public struct LevelActions
    {
        private @Controls m_Wrapper;
        public LevelActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Level_Move;
        public InputAction @Boost => m_Wrapper.m_Level_Boost;
        public InputAction @Escape => m_Wrapper.m_Level_Escape;
        public InputAction @Pause => m_Wrapper.m_Level_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Level; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LevelActions set) { return set.Get(); }
        public void SetCallbacks(ILevelActions instance)
        {
            if (m_Wrapper.m_LevelActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnMove;
                @Boost.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnBoost;
                @Boost.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnBoost;
                @Boost.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnBoost;
                @Escape.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnEscape;
                @Pause.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_LevelActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Boost.started += instance.OnBoost;
                @Boost.performed += instance.OnBoost;
                @Boost.canceled += instance.OnBoost;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public LevelActions @Level => new LevelActions(this);

    // SettingsScreen
    private readonly InputActionMap m_SettingsScreen;
    private ISettingsScreenActions m_SettingsScreenActionsCallbackInterface;
    private readonly InputAction m_SettingsScreen_Back;
    public struct SettingsScreenActions
    {
        private @Controls m_Wrapper;
        public SettingsScreenActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_SettingsScreen_Back;
        public InputActionMap Get() { return m_Wrapper.m_SettingsScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SettingsScreenActions set) { return set.Get(); }
        public void SetCallbacks(ISettingsScreenActions instance)
        {
            if (m_Wrapper.m_SettingsScreenActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_SettingsScreenActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_SettingsScreenActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_SettingsScreenActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_SettingsScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public SettingsScreenActions @SettingsScreen => new SettingsScreenActions(this);

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_Select;
    private readonly InputAction m_MainMenu_Escape;
    private readonly InputAction m_MainMenu_Move;
    public struct MainMenuActions
    {
        private @Controls m_Wrapper;
        public MainMenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_MainMenu_Select;
        public InputAction @Escape => m_Wrapper.m_MainMenu_Escape;
        public InputAction @Move => m_Wrapper.m_MainMenu_Move;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSelect;
                @Escape.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnEscape;
                @Move.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);

    // EscapeMenu
    private readonly InputActionMap m_EscapeMenu;
    private IEscapeMenuActions m_EscapeMenuActionsCallbackInterface;
    private readonly InputAction m_EscapeMenu_Confirm;
    private readonly InputAction m_EscapeMenu_Cancel;
    public struct EscapeMenuActions
    {
        private @Controls m_Wrapper;
        public EscapeMenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Confirm => m_Wrapper.m_EscapeMenu_Confirm;
        public InputAction @Cancel => m_Wrapper.m_EscapeMenu_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_EscapeMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EscapeMenuActions set) { return set.Get(); }
        public void SetCallbacks(IEscapeMenuActions instance)
        {
            if (m_Wrapper.m_EscapeMenuActionsCallbackInterface != null)
            {
                @Confirm.started -= m_Wrapper.m_EscapeMenuActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_EscapeMenuActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_EscapeMenuActionsCallbackInterface.OnConfirm;
                @Cancel.started -= m_Wrapper.m_EscapeMenuActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_EscapeMenuActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_EscapeMenuActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_EscapeMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public EscapeMenuActions @EscapeMenu => new EscapeMenuActions(this);

    // PauseMenu
    private readonly InputActionMap m_PauseMenu;
    private IPauseMenuActions m_PauseMenuActionsCallbackInterface;
    private readonly InputAction m_PauseMenu_Pause;
    public struct PauseMenuActions
    {
        private @Controls m_Wrapper;
        public PauseMenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_PauseMenu_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PauseMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseMenuActions set) { return set.Get(); }
        public void SetCallbacks(IPauseMenuActions instance)
        {
            if (m_Wrapper.m_PauseMenuActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PauseMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PauseMenuActions @PauseMenu => new PauseMenuActions(this);

    // Instructions
    private readonly InputActionMap m_Instructions;
    private IInstructionsActions m_InstructionsActionsCallbackInterface;
    private readonly InputAction m_Instructions_Confirm;
    public struct InstructionsActions
    {
        private @Controls m_Wrapper;
        public InstructionsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Confirm => m_Wrapper.m_Instructions_Confirm;
        public InputActionMap Get() { return m_Wrapper.m_Instructions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InstructionsActions set) { return set.Get(); }
        public void SetCallbacks(IInstructionsActions instance)
        {
            if (m_Wrapper.m_InstructionsActionsCallbackInterface != null)
            {
                @Confirm.started -= m_Wrapper.m_InstructionsActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_InstructionsActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_InstructionsActionsCallbackInterface.OnConfirm;
            }
            m_Wrapper.m_InstructionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
            }
        }
    }
    public InstructionsActions @Instructions => new InstructionsActions(this);
    public interface ILevelActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface ISettingsScreenActions
    {
        void OnBack(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IEscapeMenuActions
    {
        void OnConfirm(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
    public interface IPauseMenuActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IInstructionsActions
    {
        void OnConfirm(InputAction.CallbackContext context);
    }
}
