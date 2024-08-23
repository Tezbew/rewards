using System;
using Rewards.UI.Panel;
using UnityEngine;

namespace Rewards.Unity.UI.Panel
{
    public abstract class PanelBase : MonoBehaviour, IPanel
    {
        public bool IsActive
        {
            get => gameObject.activeSelf;
            private set => gameObject.SetActive(value);
        }

        public event Action<IPanel> Disposing;

        public void Show()
        {
            OnShow();
            IsActive = true;
        }

        public void Hide()
        {
            OnHide();
            IsActive = false;
        }

        public void Dispose()
        {
            Disposing?.Invoke(this);
            OnDispose();
        }

        public void SetParent(Transform parent)
        {
            transform.parent = parent;
        }

        protected abstract void OnShow();

        protected abstract void OnHide();

        protected abstract void OnDispose();
    }
}