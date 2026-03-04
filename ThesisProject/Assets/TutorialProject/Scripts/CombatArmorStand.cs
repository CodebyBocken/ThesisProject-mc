using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public int Health {  get; set; }
    public int MaxHealth { get; set; }
    public HealthBar HealthBar { get; set; }
    public bool CanTakeDamage { get; set; }
    public IEnumerator DamageCoolDown(int damageDelay);
    public void TakeDamage(int damageAmount, int damageDelay);
    public void Death();
}
public class CombatArmorStand : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int Health { get; set; }
    public int MaxHealth { get; set; }
    public HealthBar HealthBar { get; set; }
    public bool CanTakeDamage { get; set; } = true;

    void Start()
    {
        HealthBar = GetComponentInChildren<HealthBar>();
        MaxHealth = Health;
    }
    public IEnumerator DamageCoolDown(int damageDelay)
    {
        yield return new WaitForSeconds(damageDelay);
        CanTakeDamage = true;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damageAmount, int damageDelay)
    {
        if (CanTakeDamage && Health > 0)
        {
            Debug.Log($"Damage taken: {damageAmount}");
            CanTakeDamage = false;
            Health -= damageAmount;
            HealthBar.UpdateHealthBar((float)Health / MaxHealth);
            StartCoroutine(DamageCoolDown(damageDelay));
        }
        if (Health <= 0)
        {
            Death();
        }
    }
    
}
