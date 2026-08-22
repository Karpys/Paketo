namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;

    public class CharacterHandPickerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator m_Animator = null;
        [SerializeField] private CharacterController m_CharacterController = null;

        private void Update()
        {
            m_Animator.SetFloat("Speed",m_CharacterController.velocity.magnitude);
        }
    }
}