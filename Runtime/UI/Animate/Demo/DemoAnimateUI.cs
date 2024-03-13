using UnityEngine;
using UnityEngine.UI;

namespace Mzo.UI.Animate.Demo
{
    public class DemoAnimateUI: MonoBehaviour
    {
        [SerializeField] Button btnPlay, btnStop;
        [SerializeField] AnimateUI animateUI;

        private void Start()
        {
            btnPlay.AddListener(() => animateUI.Play());
            btnStop.AddListener(() => animateUI.Stop());
        }
    }
}
