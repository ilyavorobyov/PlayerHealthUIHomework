using UnityEngine;

public class PlayerHealthSliderView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private UnityEngine.UI.Slider _slider;

    private float _maxSliderValue;
    private float _newValue;

    private void Start()
    {
        _slider.maxValue = _playerHealth.MaxHealth;
        _maxSliderValue = _playerHealth.Health;
        _slider.value = _maxSliderValue;
    }

    private void OnEnable()
    {
        _playerHealth.HealthChange += OnChangeSliderValue;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChange -= OnChangeSliderValue;
    }

    private void OnChangeSliderValue()
    {
        _newValue = _playerHealth.Health;
        _slider.value = _newValue;
    }
}