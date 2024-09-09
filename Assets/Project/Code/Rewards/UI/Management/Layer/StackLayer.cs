using System.Collections.Generic;
using Rewards.UI.Panel;

namespace Rewards.UI.Management.Layer
{
    public class StackLayer : ILayer
    {
        private readonly Stack<IPanel> _stack = new();
        private readonly Stack<IPanel> _buffer = new();

        public void Add(IPanel panel)
        {
            if (_stack.Count > 0)
            {
                var currentPanel = _stack.Peek();
                currentPanel.Hide();
            }

            _stack.Push(panel);
            panel.Disposing += PanelDisposingEventHandler;
            panel.Show();
        }

        public void Dispose()
        {
            while (_stack.Count > 0)
            {
                var panel = _stack.Pop();
                panel.Disposing -= PanelDisposingEventHandler;
                panel.Dispose();
            }
        }

        private void PanelDisposingEventHandler(IPanel panel)
        {
            panel.Disposing -= PanelDisposingEventHandler;
            while (_stack.Count > 0)
            {
                var current = _stack.Pop();
                if (current == panel)
                {
                    break;
                }

                _buffer.Push(current);
            }

            while (_buffer.Count > 0)
            {
                _stack.Push(_buffer.Pop());
            }

            if (_stack.TryPeek(out var lastPanel) && lastPanel.IsActive == false)
            {
                lastPanel.Show();
            }
        }
    }
}