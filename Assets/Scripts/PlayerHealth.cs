using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private UnityEvent _health—hange = new UnityEvent();

    private float _damage = 10;
    private float _healing = 10;
    private float _minHealth = 0;

    public float MaxHealth { get; private set; } = 110;
    public float Health { get; private set; } = 80;

    public event UnityAction Health—hange
    {
        add => _health—hange.AddListener(value);
        remove => _health—hange.RemoveListener(value);
    }

    public void TakeDamage()
    {
        if (Health - _damage >= _minHealth)
        {
            Health -= _damage;
            _health—hange.Invoke();
        }
    }

    public void AddHealth()
    {
        if (Health + _healing <= MaxHealth)
        {
            Health += _healing;
            _health—hange.Invoke();
        }
    }
}