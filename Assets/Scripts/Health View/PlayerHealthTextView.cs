using UnityEngine;
using TMPro;

public class PlayerHealthTextView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private TMP_Text _healthText;

    private const string HealthTextSeparator = "\\";

    private void Start()
    {
        _healthText.text = $"{_playerHealth.Health.ToString()} {HealthTextSeparator}" +
         $" {_playerHealth.MaxHealth}";
    }

    private void OnEnable()
    {
        _playerHealth.HealthChange += OnChangeHealthText;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChange -= OnChangeHealthText;
    }

    private void OnChangeHealthText()
    {
        _healthText.text = $"{_playerHealth.Health.ToString()} {HealthTextSeparator}" +
            $" {_playerHealth.MaxHealth}";
    }
}