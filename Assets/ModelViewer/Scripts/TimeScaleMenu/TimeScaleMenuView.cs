using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace ModelViewer
{
    public class TimeScaleMenuView : MonoBehaviour
    {
        [SerializeField] Slider _slider;
        [SerializeField] InputField _inputField;
        [SerializeField] Button _resetButton;

        void Start()
        {
            _inputField.onValidateInput += OnValidateInput;
            _inputField.onValueChanged.AddListener(OnInputFieldTextChanged);

            _slider.onValueChanged.AddListener(OnSliderValueChanged);
            _slider.minValue = 0;
            _slider.maxValue = 3f;
            _slider.value = 1f;

            _resetButton.onClick.AddListener(() =>
            {
                OnSliderValueChanged(1f);
            });
        }

        char OnValidateInput(string text, int charIndex, char addedChar)
        {
            return addedChar;
        }

        void OnInputFieldTextChanged(string str)
        {
            _slider.SetValueWithoutNotify(float.Parse(str, CultureInfo.InvariantCulture.NumberFormat));
        }

        void OnSliderValueChanged(float value)
        {
            value = Mathf.Floor(value * 100) / 100;
            _slider.SetValueWithoutNotify(value);
            _inputField.SetTextWithoutNotify(_slider.value.ToString("f2"));

            Time.timeScale = value;
        }
    }
}
