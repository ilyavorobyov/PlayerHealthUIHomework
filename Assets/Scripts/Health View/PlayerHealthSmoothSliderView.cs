using System.Collections;
using UnityEngine;

public class PlayerHealthSmoothSliderView : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider _smoothSlider;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _handleSpeed;

    private Coroutine _changeValue;

    private void Start()
    {
        _smoothSlider.maxValue = _playerHealth.MaxHealth;
        _smoothSlider.value = _playerHealth.Health;
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
        if(_changeValue != null)
            StopCoroutine( _changeValue );

        _changeValue = StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();
        bool isChangeSliderValue = true;

        while (isChangeSliderValue)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, _playerHealth.Health, 
                _handleSpeed * Time.deltaTime);

            if (_smoothSlider.value == _playerHealth.Health)
            {
                isChangeSliderValue = false;
                StopCoroutine(_changeValue);
            }

            yield return waitForFixedUpdate;
        }
    }
}