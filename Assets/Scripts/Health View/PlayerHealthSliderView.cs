using UnityEngine;

public class PlayerHealthSliderView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private UnityEngine.UI.Slider _slider;

    private void Start()
    {
        _slider.maxValue = _playerHealth.MaxHealth;
        _slider.value = _playerHealth.Health;
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
        _slider.value = _playerHealth.Health;
    }
}