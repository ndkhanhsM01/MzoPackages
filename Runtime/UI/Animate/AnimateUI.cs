using System;
using System.Collections;
using UnityEngine;

namespace Mzo.UI.Animate
{
    public abstract class AnimateUI: MonoBehaviour
    {
        [SerializeField] protected float delay = 0f;
        [SerializeField] protected float duration = 0.5f;
        [SerializeField] protected AnimationCurve curve;

        protected Coroutine animationCR;

        public void Play(Action onComplete = null)
        {
            Stop();
            animationCR = StartCoroutine(AnimateCR(onComplete));
        }

        public void Stop()
        {
            if (animationCR != null)
            {
                StopCoroutine(animationCR);
            }
        }
        protected abstract IEnumerator AnimateCR(Action onComplete);
    }
}
