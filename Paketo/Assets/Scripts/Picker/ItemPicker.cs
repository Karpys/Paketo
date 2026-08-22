namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;

    public class ItemPicker : MonoBehaviour, IPicker
    {
        public void PickItem(IPickable pickable)
        {
            pickable.Pick(this);
        }

        public void ReleaseItem(IPickable pickable)
        {
            pickable.Release(this);
        }
    }
}