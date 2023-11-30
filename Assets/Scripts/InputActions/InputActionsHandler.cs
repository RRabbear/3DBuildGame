using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.BaseUtils;
using System;

namespace Assets.Scripts.InputActions
{
    public class InputActionsHandler : Singleton<InputActionsHandler>, IDisposable
    {
        public Vector2 MousePos2D;
        public bool IsMouseLeftDown;

        public void Initialize()
        {
            GameControls.Instance.Enable();
            SubInputActions();
        }

        public void Dispose()
        {
            UnSubInputActions();
        }

        public void SubInputActions()
        {
            GameControls.Instance.Game.MousePos.performed += MousePosPerformed;
            GameControls.Instance.Game.MouseAction.performed += MouseActionPerformed;
            GameControls.Instance.Game.MouseAction.canceled += MouseActionCanceled;
        }

        public void UnSubInputActions()
        {
            GameControls.Instance.Game.MousePos.performed -= MousePosPerformed;
            GameControls.Instance.Game.MouseAction.performed -= MouseActionPerformed;
            GameControls.Instance.Game.MouseAction.canceled -= MouseActionCanceled;
        }

        private void MousePosPerformed(InputAction.CallbackContext obj)
        {
            MousePos2D = obj.ReadValue<Vector2>();
        }

        private void MouseActionPerformed(InputAction.CallbackContext obj)
        {
            IsMouseLeftDown = true;
        }

        private void MouseActionCanceled(InputAction.CallbackContext obj)
        {
            IsMouseLeftDown = false;
        }
    }
}