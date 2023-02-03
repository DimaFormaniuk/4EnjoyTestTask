using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public interface ICoroutineRunner : ICoroutineStop
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }

    public interface ICoroutineStop
    {
        void StopCoroutine(Coroutine coroutine);
    }
}