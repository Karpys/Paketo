namespace KarpysDev.Scripts.Paketo
{
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class CharacterInput : MonoBehaviour
    {
        [SerializeField] private InputActionReference m_MoveAction = null;
        [SerializeField] private InputActionReference m_LookInput = null;

        private Vector3 m_Direction = Vector3.zero;

        private Action A_OnLookInput = null;

        public Action OnLookInput
        {
            get => A_OnLookInput;
            set => A_OnLookInput = value;
        }

        public Vector3 Direction => m_Direction;
        private void Update()
        {
            Vector2 direction = m_MoveAction.action.ReadValue<Vector2>();
            
            m_Direction = direction.normalized;
            
            if(m_LookInput.action.WasPressedThisFrame())
                A_OnLookInput?.Invoke();
        }
    }
}