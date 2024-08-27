using System;
using System.Runtime.CompilerServices;
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
            LogInfo();
            OnShow();
            IsActive = true;
        }

        public void Hide()
        {
            LogInfo();
            OnHide();
            IsActive = false;
        }

        public void Dispose()
        {
            LogInfo();
            Disposing?.Invoke(this);
            OnDispose();
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent, false);
        }

        protected abstract void OnShow();

        protected abstract void OnHide();

        protected abstract void OnDispose();
        
        protected void LogInfo([CallerMemberName] string message = null)
        {
            Debug.Log($"[{GetType().Name}] {message}");
        }
    }
}