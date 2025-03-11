using System.Collections;
using UnityEngine;
using System;

namespace CodeBase.Infrastructure
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        #region SerializeFields
        
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeInPeriodicity;
        [SerializeField] private float _fadeInSpeed;
        
        #endregion
        
        public void Show(Action onShowed = null)
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
            onShowed?.Invoke();
        }
        
        public void Hide(Action onHide = null)
        {
            gameObject.SetActive(true);
            StartCoroutine(FadeIn(onHide));
        }

        private void Awake() => DontDestroyOnLoad(this);

        private IEnumerator FadeIn(Action onHide = null)
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= _fadeInSpeed;
                yield return new WaitForSeconds(_fadeInPeriodicity);
            }

            onHide?.Invoke();
            gameObject.SetActive(false);
        }
    }
}