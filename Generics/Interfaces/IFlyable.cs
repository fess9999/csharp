namespace Interfaces
{
    public interface IFlyable
    {
        void TakeOff();

        int MaxHeight { get; }

        void Land();
    }
}
