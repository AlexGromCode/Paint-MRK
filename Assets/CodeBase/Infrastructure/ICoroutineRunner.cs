using UnityEngine;
using System.Collections;

namespace CodeBase.Infrastructure
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
        
        public void StopCoroutine(Coroutine coroutine);
        
        public void StopAllCoroutines();
    }
}