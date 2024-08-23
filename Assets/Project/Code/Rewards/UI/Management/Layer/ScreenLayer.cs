using Rewards.UI.Panel;

namespace Rewards.UI.Management.Layer
{
    public class ScreenLayer : ILayer
    {
        private IPanel _current;

        public void Add(IPanel panel)
        {
            CloseCurrentPanelIfPossible();

            panel.Show();
            _current = panel;
        }

        public void Dispose()
        {
            CloseCurrentPanelIfPossible();
        }

        private void CloseCurrentPanelIfPossible()
        {
            if (_current == null)
            {
                return;
            }

            _current.Hide();
            _current.Dispose();
            _current = null;
        }
    }
}