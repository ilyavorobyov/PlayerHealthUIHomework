using UnityEngine;
using TMPro;

public class HealthView : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider _smoothSlider;
    [SerializeField] private UnityEngine.UI.Slider _slider;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private float _handleSpeed;

    private const string HealthTextSeparator = "\\";

    private float _maxSliderValue;
    private float _newValue;
    private bool _isChangeSliderValue = false;

    private void Start()
    {
        _smoothSlider.maxValue = _playerHealth.MaxHealth;
        _slider.maxValue = _playerHealth.MaxHealth;
        _maxSliderValue = _playerHealth.Health;
        _smoothSlider.value = _maxSliderValue;
        _slider.value = _maxSliderValue;
        _healthText.text = $"{_playerHealth.Health.ToString()} {HealthTextSeparator}" +
            $" {_playerHealth.MaxHealth}";
    }

    private void OnEnable()
    {
        _playerHealth.Health—hange += OnChangeSliderValue;
    }

    private void OnDisable()
    {
        _playerHealth.Health—hange -= OnChangeSliderValue;
    }

    private void Update()
    {
        if (_isChangeSliderValue)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, _newValue, _handleSpeed * Time.deltaTime);

            if (_smoothSlider.value == _newValue)
            {
                _isChangeSliderValue = false;
            }
        }
    }

    private void OnChangeSliderValue()
    {
        _newValue = _playerHealth.Health;
        _slider.value = _newValue;
        _isChangeSliderValue = true;
        _healthText.text = $"{_playerHealth.Health.ToString()} {HealthTextSeparator}" +
            $" {_playerHealth.MaxHealth}";
    }
}