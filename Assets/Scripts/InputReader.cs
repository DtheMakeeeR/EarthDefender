using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

namespace EarthDefender
{
    public interface IInputReader
    {
        Vector2 Direction { get; }
        void EnablePlayerActions();
    }
    [CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader")]
    public class InputReader : ScriptableObject, IInputReader, IPlayerActions
    {
        public UnityAction<Vector2> Move = delegate { };
        public UnityAction<bool> Jump = delegate { };
        public UnityAction<float> Attack = delegate { };

        InputSystem_Actions inputActions;
        public Vector2 Direction => inputActions.Player.Move.ReadValue<Vector2>();

        public void EnablePlayerActions()
        {
            if (inputActions == null)
            {
                inputActions = new InputSystem_Actions();
                inputActions.Player.SetCallbacks(this);
            }
            inputActions.Enable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Move?.Invoke(context.ReadValue<Vector2>());
            Debug.Log("MOVING");
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            //noop
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            //noop
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            //noop
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            //noop
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            //noop
        }

        public void OnNext(InputAction.CallbackContext context)
        {
            //noop
        }

        public void OnPrevious(InputAction.CallbackContext context)
        {
            //noop
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            //noop
        }
    }
}