using UnityEngine;
using UnityEngine.UI;

namespace Mzo.UI
{
    public class UIPanel: MonoBehaviour
    {
        [SerializeField] private Button btnClose;

        public bool IsShowing => gameObject.activeInHierarchy;
        protected virtual void Start()
        {
            if (btnClose != null)
            {
                btnClose.AddListener(Hide);
            }
        }
        public virtual void Show()
        {
            gameObject.Show();
        }
        public virtual void Hide()
        {
            gameObject.Hide();
        }

    }
}
