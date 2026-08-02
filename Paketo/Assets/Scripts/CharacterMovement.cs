namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController m_CharacterController = null;
        [SerializeField] private CharacterInput m_CharacterInput = null;
        [SerializeField] private float m_MoveSpeed = 1.0f;

        private void Start()
        {
        }

        private void Update()
        {
            m_CharacterController.SimpleMove(new Vector3(m_CharacterInput.Direction.x * m_MoveSpeed,0,m_CharacterInput.Direction.y * m_MoveSpeed));
        }
    }
}