namespace KarpysDev.Scripts.Paketo
{
    using UnityEngine;

    public interface  IPicker
    {
        public Transform Root { get; }
        public IPickable CurrentPickable { get; }
        public void PickItem(IPickable pickable);
        public void ReleaseItem();
        public void ClearItem();
    }
}