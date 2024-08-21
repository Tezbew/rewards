using Rewards.UI.Panel;

namespace Rewards.UI.Management.Opener
{
    public interface IPanelOpener
    {
        TPanel Open<TPanel>() where TPanel : IPanel;
    }
}