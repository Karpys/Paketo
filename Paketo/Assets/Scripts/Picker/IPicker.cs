namespace KarpysDev.Scripts.Paketo
{
    public interface IPicker
    {
        public void PickItem(IPickable pickable);
        public void ReleaseItem(IPickable pickable);
    }
}