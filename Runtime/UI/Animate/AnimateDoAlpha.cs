using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

namespace Mzo.UI.Animate
{
    public class AnimateDoAlpha : AnimateUI
    {
        [SerializeField] private Image target;

        private float animateTimter = 0f;
        protected override IEnumerator AnimateCR(Action onComplete = null)
        {
            yield return new WaitForSeconds(delay);
            animateTimter = 0f;
            float defaultValue = target.color.a;
            Color color = target.color;
            while (gameObject.activeInHierarchy && animateTimter < duration)
            {
                float alphaValue = curve.Evaluate(animateTimter / duration);
                color.a = alphaValue;

                target.color = color;

                animateTimter += Time.deltaTime;
                yield return null;
            }

            color.a = defaultValue;
            target.color = color;
            onComplete?.Invoke();
        }
    }
}

