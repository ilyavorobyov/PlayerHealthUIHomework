using System.Collections;
using UnityEngine;

public class PlayerHealthSmoothSliderView : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider _smoothSlider;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _handleSpeed;

    private float _maxSliderValue;
    private float _newValue;
    private bool _isChangeSliderValue = false;
    private Coroutine _changeValue;

    private void Start()
    {
        _smoothSlider.maxValue = _playerHealth.MaxHealth;
        _maxSliderValue = _playerHealth.Health;
        _smoothSlider.value = _maxSliderValue;
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
        _isChangeSliderValue = true;

        if(_changeValue != null)
            StopCoroutine( _changeValue );

        _changeValue = StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();
        _newValue = _playerHealth.Health;

        while (_isChangeSliderValue)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, _newValue, 
                _handleSpeed * Time.deltaTime);

            if (_smoothSlider.value == _newValue)
            {
                _isChangeSliderValue = false;
                StopCoroutine(_changeValue);
            }

            yield return waitForFixedUpdate;
        }
    }
}