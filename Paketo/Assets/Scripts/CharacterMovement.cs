namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;

    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController m_CharacterController = null;
        [SerializeField] private CharacterInput m_CharacterInput = null;
        [SerializeField] private float m_MoveSpeed = 1.0f;

        private void Update()
        {
            Vector3 moveDirection = (transform.right * m_CharacterInput.Direction.x) +
                                    (transform.forward * m_CharacterInput.Direction.y);
            m_CharacterController.SimpleMove(moveDirection * m_MoveSpeed);
        }
    }
}