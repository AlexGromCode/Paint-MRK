using System;

namespace CodeBase.Infrastructure
{
    public interface ILoadingCurtain
    {
        public void Show(Action onShowed = null);
        public void Hide(Action onHide = null);
    }
}