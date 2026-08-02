namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class CharacterInput : MonoBehaviour
    {
        [SerializeField] private InputActionReference m_MoveAction = null;

        private Vector3 m_Direction = Vector3.zero;

        public Vector3 Direction => m_Direction;
        private void Update()
        {
            Vector2 direction = m_MoveAction.action.ReadValue<Vector2>();
            
            m_Direction = direction.normalized;
        }
    }
}