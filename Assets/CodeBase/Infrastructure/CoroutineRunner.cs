using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine) => base.StartCoroutine(coroutine);

        public void StopCoroutine(Coroutine coroutine) => base.StopCoroutine(coroutine);

        public void StopAllCoroutines() => base.StopAllCoroutines();
    }
}