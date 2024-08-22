using System;
using Rewards.UI.Panel;

namespace Rewards.UI.Management.Opener
{
    public interface IPanelOpener : IDisposable
    {
        TPanel Open<TPanel>() where TPanel : class, IPanel;
    }
}