namespace KarpysDev.Scripts.Paketo
{
    public interface IPickable
    {
        public void Pick(IPicker picker);
        public void Release(IPicker picker);
    }
}