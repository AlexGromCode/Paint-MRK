using System;

namespace CodeBase.Infrastructure
{
    public interface ILoadingCurtainService
    {
        public event EventHandler LoadingCurtainHideComplete;
        public void HideLoadingCurtain();
        public void ShowLoadingCurtain(string sceneName, Action onShowed = null);
    }
}