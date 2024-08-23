using System;

namespace Rewards.UI.Panel
{
    public interface IPanel : IDisposable
    {
        void Show();
        void Hide();
        event Action<IPanel> Disposing;
        bool IsActive { get; }
    }
}