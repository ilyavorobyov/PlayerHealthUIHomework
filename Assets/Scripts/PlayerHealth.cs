using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private UnityEvent _healthChange = new UnityEvent();

    private float _damage = 10;
    private float _healing = 10;
    private float _minHealth = 0;

    public event UnityAction HealthChange
    {
        add => _healthChange.AddListener(value);
        remove => _healthChange.RemoveListener(value);
    }

    public float MaxHealth { get; private set; } = 110;
    public float Health { get; private set; } = 80;

    public void TakeDamage()
    {
        if (Health - _damage >= _minHealth)
        {
            Health -= _damage;
            _healthChange.Invoke();
        }
    }

    public void AddHealth()
    {
        if (Health + _healing <= MaxHealth)
        {
            Health += _healing;
            _healthChange.Invoke();
        }
    }
}