using UnityEngine;
using UnityEngine.UI;

namespace Mzo.UI
{
    public class ToggleButton : MonoBehaviour
    {
        [SerializeField] private Image imgIcon;
        [SerializeField] private Button btnToggle;
        public Sprite spriteOn;
        public Sprite spriteOff;

        private bool _isOn;
        public bool isOn
        {
            get => _isOn;
            set
            {
                _isOn = value;
                if (_isOn) imgIcon.sprite = spriteOn;
                else imgIcon.sprite = spriteOff;
            }
        }

        public delegate void OnToggle(bool value);
        public OnToggle onValueChanged;

        private void Start()
        {
            btnToggle.AddListener(Toggle);
        }

        private void Toggle()
        {
            isOn = !isOn;

            onValueChanged?.Invoke(isOn);
        }
    }
}