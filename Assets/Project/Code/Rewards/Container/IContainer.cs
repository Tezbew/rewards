namespace Rewards.Container
{
    public interface IContainer
    {
        void Register<TContract>(TContract instance);
        void Remove<TContract>();
        TContract Resolve<TContract>();
    }
}