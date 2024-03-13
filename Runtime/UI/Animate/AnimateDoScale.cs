using UnityEngine;
using System;
using System.Collections;

namespace Mzo.UI.Animate
{
    public class AnimateDoScaleItem : AnimateUI
    {
        [SerializeField] private Transform target;
        [SerializeField] private float multiplier = 1f;

        private float animateTimter = 0f;
     
        protected override IEnumerator AnimateCR(Action onComplete = null)
        {
            yield return new WaitForSeconds(delay);
            animateTimter = 0f;
            Vector3 defaultScale = target.localScale;
            while (gameObject.activeInHierarchy && animateTimter < duration)
            {
                float newValue = curve.Evaluate(animateTimter / duration) * multiplier;

                target.localScale = Vector3.one * newValue;

                animateTimter += Time.deltaTime;
                yield return null;
            }

            target.localScale = defaultScale;
            onComplete?.Invoke();
        }
    }
}

