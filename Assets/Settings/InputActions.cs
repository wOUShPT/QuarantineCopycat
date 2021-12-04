// GENERATED AUTOMATICALLY FROM 'Assets/Settings/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ddae5a22-4231-4b46-8858-bc380ccde10b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""9c9aa810-a4f4-44b1-afad-7f21ceddbf89"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""e56ab5a6-ac44-480f-bfd3-0c101972dc99"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Value"",
                    ""id"": ""b3aef61f-014a-411c-9091-6e1125d09707"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""8b65fd9c-287b-4ca5-b773-a83bcf5e3673"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UsePhone"",
                    ""type"": ""Button"",
                    ""id"": ""a2190494-9513-4f3a-9518-b08b24895146"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ExitInteraction"",
                    ""type"": ""Button"",
                    ""id"": ""3c044b9c-2667-4474-814f-d1aadad8e5f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootIn"",
                    ""type"": ""Button"",
                    ""id"": ""5bc081ab-44c9-4128-8913-7f2085d0c4cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1),Hold""
                },
                {
                    ""name"": ""ShootOut"",
                    ""type"": ""Button"",
                    ""id"": ""c40ec3ed-cd47-4a2a-803e-1eb175d2d800"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1,behavior=1)""
                },
                {
                    ""name"": ""SwitchChannels"",
                    ""type"": ""Button"",
                    ""id"": ""1e7afc56-15de-4323-8583-9acf49d0e18c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchChannelVolume"",
                    ""type"": ""Button"",
                    ""id"": ""9a1124c3-78ab-4fae-b16a-0411191b483d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TapNote"",
                    ""type"": ""Value"",
                    ""id"": ""cd0344bd-45b6-407b-b7b0-e80d4b3a3370"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""HoldNote"",
                    ""type"": ""Button"",
                    ""id"": ""bad3b4a0-a76e-4821-986c-03e3ec3a53bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inspection"",
                    ""type"": ""Button"",
                    ""id"": ""89b1b522-f276-4cc9-81d6-03f439949927"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""09827f39-c184-43bb-87a0-747e860d700a"",
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
                    ""id"": ""446ab36b-4e91-424d-9f36-22fd60654665"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5483031b-4825-419d-adb0-1aef7fac8943"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6ac0a780-2b47-4bb9-8ce2-8990f21ac8f2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ae13c9ef-10be-453f-89c3-aa411a6927a4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""99e25d95-fbd0-491a-8751-e680bc927f04"",
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
                    ""id"": ""f79192f8-ae0f-497f-b74f-c8177818506e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fa6b8b59-e5f9-4bcc-9b15-91fa7cbba58c"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""405bd287-24d8-4bdd-9bff-a6e08fb4216c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""735f0338-c14f-444d-996d-55b2f2dc84e4"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""RightStick"",
                    ""id"": ""dd7f2e14-17ad-4393-982c-eb0518f3a301"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e09eb277-1fe9-4813-a237-77c6dfd90c00"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""56932c93-c319-4117-b2cd-b6ca20e709f4"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""88f6bb3b-f50e-448c-b984-742a3963171a"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""664da476-8c43-456b-904a-c28416d75a84"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""25511b5f-f38b-4325-a792-82465a60e3ac"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbefb3a5-e345-4673-a886-61e094b58199"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30029d33-d799-4c10-b7eb-3a318ba39b75"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""376cef4f-f28f-40dc-bed8-f1476eadf92a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5400197-9bec-4684-b579-23d76e6d54f2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e03bc935-f580-400e-a9a5-10dd69b6e20e"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""UsePhone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""258518b0-9e29-4654-b37e-b5c27425c370"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""UsePhone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb36db3f-40a1-48e2-9c1f-aea7f9c00b3a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""ExitInteraction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02190c6f-37c9-487e-b43f-efd3d5aad1ad"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""ExitInteraction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c9ab9d7-9861-4129-8041-8dfdbab38a86"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""ShootIn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b423c4f4-e3c8-4847-be6c-530519ee2ded"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""ShootIn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Axis"",
                    ""id"": ""8e645f8d-849b-4c74-889b-21f490e57e18"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchChannels"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""db5686e7-de24-4a37-b8dc-2201b9331e27"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""SwitchChannels"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4232de1a-a4be-45ab-9d75-f32b2792324f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""SwitchChannels"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Axis"",
                    ""id"": ""70a7c50d-7ed6-4766-8cfc-d560b0cb6604"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchChannels"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e317a802-10ca-45da-81e9-dcafcabd8684"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""SwitchChannels"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""849d59da-529f-40d0-a893-f897fa42b0b8"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""SwitchChannels"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Axis"",
                    ""id"": ""ba5e8af2-0bfa-4a5f-bf41-e692ae918dd0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchChannelVolume"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3f16df53-0035-4ac7-90f2-5448ea6ae5c7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""SwitchChannelVolume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a2230f5d-06ed-408c-8889-2f1199f9eba5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""SwitchChannelVolume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Axis"",
                    ""id"": ""56214b78-03c8-4a2f-94d0-b63184eacdb8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchChannelVolume"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""663e948c-e753-4e44-b8b5-b02a4e0411e9"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""SwitchChannelVolume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0998b213-873d-492f-b38a-f8953bd26fb2"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""SwitchChannelVolume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a1fe13a4-490f-40ab-958b-b5a5ff097850"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""TapNote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6225a83-7f46-4a69-97a6-01314ce07385"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Tap(duration=3,pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""HoldNote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15d2a95d-a923-4ad9-9124-167b2a25f4e3"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Inspection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc614747-3b5c-450c-98bf-8b324ec686f6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""ShootOut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af0685d0-547a-4759-a7e5-1247fc059e04"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""ShootOut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Phone"",
            ""id"": ""66c4e581-9b11-45a8-92b8-14b40173473b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""0138aeab-a494-46c9-a420-af294d990225"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Value"",
                    ""id"": ""5281de8c-3b0c-4d0f-8dea-80c4d915826b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Return"",
                    ""type"": ""Button"",
                    ""id"": ""7493cbdc-4f0a-4289-be50-70854b860978"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RecieveMessageDebug"",
                    ""type"": ""Button"",
                    ""id"": ""d9a2a558-ee70-44fd-abe3-7e8d21266c4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Send"",
                    ""type"": ""Button"",
                    ""id"": ""3baef10e-5ab6-450e-ac90-71dc3a8cd62c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""97fb26da-8066-40b2-9df0-ba181de8b75d"",
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
                    ""id"": ""831345b5-9984-4269-b149-2e78e8be4663"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2b4f88af-81d5-48b4-8fb9-e528e63048fe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ba9cf8ca-1fd6-429b-8f6f-82e31ff185d7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""98365e40-9554-4895-83d5-bb3b87064a0f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4667d3d8-75c8-411d-aefb-97f98009ff9f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""379d5f29-9c9f-4528-8536-ffaebe8dd8c0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34bf3001-f88c-4516-b981-f10be95e9636"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2480cdb-d3a2-40a0-91d1-5be19b736160"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""RecieveMessageDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""143822a5-f7e4-4d0f-8e94-8ddff5f7d4c6"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Send"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menus"",
            ""id"": ""954b7337-968f-4daa-a17d-f87d721ca5cd"",
            ""actions"": [
                {
                    ""name"": ""Navigation"",
                    ""type"": ""Value"",
                    ""id"": ""d843aaa3-f9a8-4b64-bc50-dfbc89508cb8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Value"",
                    ""id"": ""a8dc74b0-bde2-4d67-b50e-939cec185d6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""9027245e-60e9-4812-ab07-f2e869f0db5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""D-Pad"",
                    ""id"": ""cdff0d49-d4f2-4eeb-931c-88abd62d808f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""66d14f57-3a4b-47d6-b0f6-5ef34d8435b5"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c59bd096-f717-4964-bcb5-c8569ea28731"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9458c645-e301-45ad-b215-3e381b4967f2"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f3e070ee-9ca5-4604-8336-a4c41dfc6ef9"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""d2239a55-297f-4844-a52b-20d243158c6a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a1e94056-a657-47e8-b315-e1ee3f80cb46"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e8176abb-4f21-41e7-877f-70d4c9e6ca0b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""15860730-e5f1-457d-89fb-37423ae40c2c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dd7a3861-b9c3-44e2-985d-f9d97d8aa4b6"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""96b422f5-2927-47cb-856f-77c24984b5de"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""abd1fe59-f14e-437a-80dd-a3a7598f8ca2"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f3f5a9a7-7e7c-4816-baec-399368ac0735"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f1655d59-91db-488d-829a-d8b2a7cc708c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e99d7a43-1ef4-432e-8b84-d8d2c2d0e0e1"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""485b9cfd-df8a-4b12-bc6f-179f4d60e904"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0a93a78d-6cf1-447e-aaab-3479d82118ef"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9c21499a-22b3-43ee-a241-26e794f38bb9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bbb54111-12c1-4e05-bb2a-963c4efecc5c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8cbf1fc7-0937-423e-b2b5-504e425dbf6f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3abd2954-8aee-47e5-b500-335bcbe8a511"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fa9aa87-86ce-49ec-a7c8-9deb8773f704"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d005aeb-038d-4542-b943-2f9b9efe8294"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29de5788-8079-46a5-9c33-13a0d9901da0"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DEBUG"",
            ""id"": ""e6fb9caa-6181-4ceb-8ec7-357ab01ab40e"",
            ""actions"": [],
            ""bindings"": []
        },
        {
            ""name"": ""Inspection"",
            ""id"": ""a9d18b30-5e3e-432d-be04-0e7999cc2d5b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""edcf8fb7-32cf-403d-b921-d386b8094b29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CancelInspection"",
                    ""type"": ""Button"",
                    ""id"": ""3de9ba19-c0c9-43c5-84e9-75a19c615501"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD"",
                    ""id"": ""47551477-4298-42df-9b2b-149d912c5719"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""68b9fa68-88eb-448f-9a41-33aa92c7fcdc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8894f8e0-9d78-4fef-8fba-28373d400b6e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""96054607-882d-4b18-9fde-273e06bc60ec"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""CancelInspection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mouse&Keyboard"",
            ""bindingGroup"": ""Mouse&Keyboard"",
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
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_UsePhone = m_Player.FindAction("UsePhone", throwIfNotFound: true);
        m_Player_ExitInteraction = m_Player.FindAction("ExitInteraction", throwIfNotFound: true);
        m_Player_ShootIn = m_Player.FindAction("ShootIn", throwIfNotFound: true);
        m_Player_ShootOut = m_Player.FindAction("ShootOut", throwIfNotFound: true);
        m_Player_SwitchChannels = m_Player.FindAction("SwitchChannels", throwIfNotFound: true);
        m_Player_SwitchChannelVolume = m_Player.FindAction("SwitchChannelVolume", throwIfNotFound: true);
        m_Player_TapNote = m_Player.FindAction("TapNote", throwIfNotFound: true);
        m_Player_HoldNote = m_Player.FindAction("HoldNote", throwIfNotFound: true);
        m_Player_Inspection = m_Player.FindAction("Inspection", throwIfNotFound: true);
        // Phone
        m_Phone = asset.FindActionMap("Phone", throwIfNotFound: true);
        m_Phone_Movement = m_Phone.FindAction("Movement", throwIfNotFound: true);
        m_Phone_Select = m_Phone.FindAction("Select", throwIfNotFound: true);
        m_Phone_Return = m_Phone.FindAction("Return", throwIfNotFound: true);
        m_Phone_RecieveMessageDebug = m_Phone.FindAction("RecieveMessageDebug", throwIfNotFound: true);
        m_Phone_Send = m_Phone.FindAction("Send", throwIfNotFound: true);
        // Menus
        m_Menus = asset.FindActionMap("Menus", throwIfNotFound: true);
        m_Menus_Navigation = m_Menus.FindAction("Navigation", throwIfNotFound: true);
        m_Menus_Confirm = m_Menus.FindAction("Confirm", throwIfNotFound: true);
        m_Menus_Back = m_Menus.FindAction("Back", throwIfNotFound: true);
        // DEBUG
        m_DEBUG = asset.FindActionMap("DEBUG", throwIfNotFound: true);
        // Inspection
        m_Inspection = asset.FindActionMap("Inspection", throwIfNotFound: true);
        m_Inspection_Movement = m_Inspection.FindAction("Movement", throwIfNotFound: true);
        m_Inspection_CancelInspection = m_Inspection.FindAction("CancelInspection", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_UsePhone;
    private readonly InputAction m_Player_ExitInteraction;
    private readonly InputAction m_Player_ShootIn;
    private readonly InputAction m_Player_ShootOut;
    private readonly InputAction m_Player_SwitchChannels;
    private readonly InputAction m_Player_SwitchChannelVolume;
    private readonly InputAction m_Player_TapNote;
    private readonly InputAction m_Player_HoldNote;
    private readonly InputAction m_Player_Inspection;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @UsePhone => m_Wrapper.m_Player_UsePhone;
        public InputAction @ExitInteraction => m_Wrapper.m_Player_ExitInteraction;
        public InputAction @ShootIn => m_Wrapper.m_Player_ShootIn;
        public InputAction @ShootOut => m_Wrapper.m_Player_ShootOut;
        public InputAction @SwitchChannels => m_Wrapper.m_Player_SwitchChannels;
        public InputAction @SwitchChannelVolume => m_Wrapper.m_Player_SwitchChannelVolume;
        public InputAction @TapNote => m_Wrapper.m_Player_TapNote;
        public InputAction @HoldNote => m_Wrapper.m_Player_HoldNote;
        public InputAction @Inspection => m_Wrapper.m_Player_Inspection;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @UsePhone.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUsePhone;
                @UsePhone.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUsePhone;
                @UsePhone.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUsePhone;
                @ExitInteraction.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExitInteraction;
                @ExitInteraction.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExitInteraction;
                @ExitInteraction.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExitInteraction;
                @ShootIn.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootIn;
                @ShootIn.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootIn;
                @ShootIn.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootIn;
                @ShootOut.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootOut;
                @ShootOut.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootOut;
                @ShootOut.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootOut;
                @SwitchChannels.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchChannels;
                @SwitchChannels.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchChannels;
                @SwitchChannels.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchChannels;
                @SwitchChannelVolume.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchChannelVolume;
                @SwitchChannelVolume.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchChannelVolume;
                @SwitchChannelVolume.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchChannelVolume;
                @TapNote.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTapNote;
                @TapNote.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTapNote;
                @TapNote.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTapNote;
                @HoldNote.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHoldNote;
                @HoldNote.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHoldNote;
                @HoldNote.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHoldNote;
                @Inspection.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInspection;
                @Inspection.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInspection;
                @Inspection.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInspection;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @UsePhone.started += instance.OnUsePhone;
                @UsePhone.performed += instance.OnUsePhone;
                @UsePhone.canceled += instance.OnUsePhone;
                @ExitInteraction.started += instance.OnExitInteraction;
                @ExitInteraction.performed += instance.OnExitInteraction;
                @ExitInteraction.canceled += instance.OnExitInteraction;
                @ShootIn.started += instance.OnShootIn;
                @ShootIn.performed += instance.OnShootIn;
                @ShootIn.canceled += instance.OnShootIn;
                @ShootOut.started += instance.OnShootOut;
                @ShootOut.performed += instance.OnShootOut;
                @ShootOut.canceled += instance.OnShootOut;
                @SwitchChannels.started += instance.OnSwitchChannels;
                @SwitchChannels.performed += instance.OnSwitchChannels;
                @SwitchChannels.canceled += instance.OnSwitchChannels;
                @SwitchChannelVolume.started += instance.OnSwitchChannelVolume;
                @SwitchChannelVolume.performed += instance.OnSwitchChannelVolume;
                @SwitchChannelVolume.canceled += instance.OnSwitchChannelVolume;
                @TapNote.started += instance.OnTapNote;
                @TapNote.performed += instance.OnTapNote;
                @TapNote.canceled += instance.OnTapNote;
                @HoldNote.started += instance.OnHoldNote;
                @HoldNote.performed += instance.OnHoldNote;
                @HoldNote.canceled += instance.OnHoldNote;
                @Inspection.started += instance.OnInspection;
                @Inspection.performed += instance.OnInspection;
                @Inspection.canceled += instance.OnInspection;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Phone
    private readonly InputActionMap m_Phone;
    private IPhoneActions m_PhoneActionsCallbackInterface;
    private readonly InputAction m_Phone_Movement;
    private readonly InputAction m_Phone_Select;
    private readonly InputAction m_Phone_Return;
    private readonly InputAction m_Phone_RecieveMessageDebug;
    private readonly InputAction m_Phone_Send;
    public struct PhoneActions
    {
        private @InputActions m_Wrapper;
        public PhoneActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Phone_Movement;
        public InputAction @Select => m_Wrapper.m_Phone_Select;
        public InputAction @Return => m_Wrapper.m_Phone_Return;
        public InputAction @RecieveMessageDebug => m_Wrapper.m_Phone_RecieveMessageDebug;
        public InputAction @Send => m_Wrapper.m_Phone_Send;
        public InputActionMap Get() { return m_Wrapper.m_Phone; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PhoneActions set) { return set.Get(); }
        public void SetCallbacks(IPhoneActions instance)
        {
            if (m_Wrapper.m_PhoneActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PhoneActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PhoneActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PhoneActionsCallbackInterface.OnMovement;
                @Select.started -= m_Wrapper.m_PhoneActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PhoneActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PhoneActionsCallbackInterface.OnSelect;
                @Return.started -= m_Wrapper.m_PhoneActionsCallbackInterface.OnReturn;
                @Return.performed -= m_Wrapper.m_PhoneActionsCallbackInterface.OnReturn;
                @Return.canceled -= m_Wrapper.m_PhoneActionsCallbackInterface.OnReturn;
                @RecieveMessageDebug.started -= m_Wrapper.m_PhoneActionsCallbackInterface.OnRecieveMessageDebug;
                @RecieveMessageDebug.performed -= m_Wrapper.m_PhoneActionsCallbackInterface.OnRecieveMessageDebug;
                @RecieveMessageDebug.canceled -= m_Wrapper.m_PhoneActionsCallbackInterface.OnRecieveMessageDebug;
                @Send.started -= m_Wrapper.m_PhoneActionsCallbackInterface.OnSend;
                @Send.performed -= m_Wrapper.m_PhoneActionsCallbackInterface.OnSend;
                @Send.canceled -= m_Wrapper.m_PhoneActionsCallbackInterface.OnSend;
            }
            m_Wrapper.m_PhoneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Return.started += instance.OnReturn;
                @Return.performed += instance.OnReturn;
                @Return.canceled += instance.OnReturn;
                @RecieveMessageDebug.started += instance.OnRecieveMessageDebug;
                @RecieveMessageDebug.performed += instance.OnRecieveMessageDebug;
                @RecieveMessageDebug.canceled += instance.OnRecieveMessageDebug;
                @Send.started += instance.OnSend;
                @Send.performed += instance.OnSend;
                @Send.canceled += instance.OnSend;
            }
        }
    }
    public PhoneActions @Phone => new PhoneActions(this);

    // Menus
    private readonly InputActionMap m_Menus;
    private IMenusActions m_MenusActionsCallbackInterface;
    private readonly InputAction m_Menus_Navigation;
    private readonly InputAction m_Menus_Confirm;
    private readonly InputAction m_Menus_Back;
    public struct MenusActions
    {
        private @InputActions m_Wrapper;
        public MenusActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigation => m_Wrapper.m_Menus_Navigation;
        public InputAction @Confirm => m_Wrapper.m_Menus_Confirm;
        public InputAction @Back => m_Wrapper.m_Menus_Back;
        public InputActionMap Get() { return m_Wrapper.m_Menus; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenusActions set) { return set.Get(); }
        public void SetCallbacks(IMenusActions instance)
        {
            if (m_Wrapper.m_MenusActionsCallbackInterface != null)
            {
                @Navigation.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnNavigation;
                @Navigation.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnNavigation;
                @Navigation.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnNavigation;
                @Confirm.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnConfirm;
                @Back.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MenusActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigation.started += instance.OnNavigation;
                @Navigation.performed += instance.OnNavigation;
                @Navigation.canceled += instance.OnNavigation;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public MenusActions @Menus => new MenusActions(this);

    // DEBUG
    private readonly InputActionMap m_DEBUG;
    private IDEBUGActions m_DEBUGActionsCallbackInterface;
    public struct DEBUGActions
    {
        private @InputActions m_Wrapper;
        public DEBUGActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_DEBUG; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DEBUGActions set) { return set.Get(); }
        public void SetCallbacks(IDEBUGActions instance)
        {
            if (m_Wrapper.m_DEBUGActionsCallbackInterface != null)
            {
            }
            m_Wrapper.m_DEBUGActionsCallbackInterface = instance;
            if (instance != null)
            {
            }
        }
    }
    public DEBUGActions @DEBUG => new DEBUGActions(this);

    // Inspection
    private readonly InputActionMap m_Inspection;
    private IInspectionActions m_InspectionActionsCallbackInterface;
    private readonly InputAction m_Inspection_Movement;
    private readonly InputAction m_Inspection_CancelInspection;
    public struct InspectionActions
    {
        private @InputActions m_Wrapper;
        public InspectionActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Inspection_Movement;
        public InputAction @CancelInspection => m_Wrapper.m_Inspection_CancelInspection;
        public InputActionMap Get() { return m_Wrapper.m_Inspection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InspectionActions set) { return set.Get(); }
        public void SetCallbacks(IInspectionActions instance)
        {
            if (m_Wrapper.m_InspectionActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_InspectionActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_InspectionActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_InspectionActionsCallbackInterface.OnMovement;
                @CancelInspection.started -= m_Wrapper.m_InspectionActionsCallbackInterface.OnCancelInspection;
                @CancelInspection.performed -= m_Wrapper.m_InspectionActionsCallbackInterface.OnCancelInspection;
                @CancelInspection.canceled -= m_Wrapper.m_InspectionActionsCallbackInterface.OnCancelInspection;
            }
            m_Wrapper.m_InspectionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @CancelInspection.started += instance.OnCancelInspection;
                @CancelInspection.performed += instance.OnCancelInspection;
                @CancelInspection.canceled += instance.OnCancelInspection;
            }
        }
    }
    public InspectionActions @Inspection => new InspectionActions(this);
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse&Keyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnUsePhone(InputAction.CallbackContext context);
        void OnExitInteraction(InputAction.CallbackContext context);
        void OnShootIn(InputAction.CallbackContext context);
        void OnShootOut(InputAction.CallbackContext context);
        void OnSwitchChannels(InputAction.CallbackContext context);
        void OnSwitchChannelVolume(InputAction.CallbackContext context);
        void OnTapNote(InputAction.CallbackContext context);
        void OnHoldNote(InputAction.CallbackContext context);
        void OnInspection(InputAction.CallbackContext context);
    }
    public interface IPhoneActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnReturn(InputAction.CallbackContext context);
        void OnRecieveMessageDebug(InputAction.CallbackContext context);
        void OnSend(InputAction.CallbackContext context);
    }
    public interface IMenusActions
    {
        void OnNavigation(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
    public interface IDEBUGActions
    {
    }
    public interface IInspectionActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCancelInspection(InputAction.CallbackContext context);
    }
}
