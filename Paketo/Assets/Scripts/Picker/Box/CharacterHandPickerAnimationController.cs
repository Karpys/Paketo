namespace KarpysDev.Scripts.Paketo
{
    using System;
    using UnityEngine;

    public class CharacterHandPickerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator m_SelectableAnimator = null;
        [SerializeField] private Animator m_HandAnimator = null;
        [SerializeField] private CharacterController m_CharacterController = null;
        [SerializeField] private ItemPickerSelector m_ItemPickerSelector = null;

        private string m_CurrentHandAnimation = "A_HandIdle";
        private string m_CurrentSelectableAnimation = "Idle";
        private bool m_PickState = false;
        private void Awake()
        {
            m_ItemPickerSelector.OnItemPick += ChangePickState;
        }

        private void ChangePickState(bool pick)
        {
            m_PickState = pick;
        }

        private void Update()
        {
            if (m_CharacterController.velocity.magnitude > 1.0f)
            {
                TryPlaySelectableAnimation(m_PickState ? "Move" : "Idle",0.25f);
                TryPlayHandAnimation(m_PickState ? "A_HandBoxHoldRun" : "A_HandMoveEmpty",0.25f);
            }
            else
            {
                TryPlaySelectableAnimation("Idle",0.25f);
                TryPlayHandAnimation(m_PickState ? "A_HandBoxHold" : "A_HandIdle",0.25f);
            }
        }

        private void TryPlayHandAnimation(string animationName, float crossFadeTime)
        {
            if (animationName != m_CurrentHandAnimation)
            {
                m_HandAnimator.CrossFade(animationName,crossFadeTime);
                m_CurrentHandAnimation = animationName;
            }
        }
        
        private void TryPlaySelectableAnimation(string animationName, float crossFadeTime)
        {
            if (animationName != m_CurrentSelectableAnimation)
            {
                m_SelectableAnimator.CrossFade(animationName,crossFadeTime);
                m_CurrentSelectableAnimation = animationName;
            }
        }
    }
}