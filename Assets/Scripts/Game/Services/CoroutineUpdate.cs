using System;
using System.Collections;
using Infrastructure;
using UnityEngine;

namespace Game.Services
{
    public class CoroutineUpdate
    {
        public event Action Update;

        private readonly int _interval;
        private readonly ICoroutineRunner _coroutineRunner;
        private Coroutine _coroutine;

        public CoroutineUpdate(ICoroutineRunner coroutineRunner, int intervalSeconds)
        {
            _coroutineRunner = coroutineRunner;
            _interval = intervalSeconds;
        }

        public void StartTimer()
        {
            if (_coroutine == null)
                _coroutine = _coroutineRunner.StartCoroutine(CoroutineTimer());
        }

        public void StopTimer()
        {
            if (_coroutine != null)
            {
                _coroutineRunner.StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator CoroutineTimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(_interval);
                Update?.Invoke();
            }
        }
    }
}