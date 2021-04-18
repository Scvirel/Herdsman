using System.Collections;

using CodeBase.Infrastructure.Services;

using UnityEngine;

namespace CodeBase.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);

        void StopCoroutine(Coroutine coroutine);

        void StopAllCoroutines();
    }
}