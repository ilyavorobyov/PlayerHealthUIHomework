using UnityEngine;
using TMPro;

public class PlayerHealthTextView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private TMP_Text _healthText;

    private const string HealthTextSeparator = "\\";

    private void Start()
    {
        ShowHealthInfo();
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
        ShowHealthInfo();
    }

    private void ShowHealthInfo()
    {
        _healthText.text = $"{_playerHealth.Health.ToString()} {HealthTextSeparator}" +
            $" {_playerHealth.MaxHealth}";
    }
}