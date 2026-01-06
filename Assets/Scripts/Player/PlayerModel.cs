using UnityEngine;

public class PlayerModel 
{
    public int maxHealth { get; }
    public int _currentHealth { get; private set; }

    public int maxMana { get; }
    private int _currentMana = 100;

    public PlayerModel(int maxHealth, int maxMana)
    {
        this.maxHealth = maxHealth;
        this.maxMana = maxMana;
        _currentHealth = maxHealth;
        _currentMana = maxMana;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth = Mathf.Max(_currentHealth - amount, 0);
    }
    public void SpendMana(int amount)
    {
        _currentMana = Mathf.Max(_currentMana - amount, 0);
    }

    public void RegenMana(int amount)
    {
        _currentMana = Mathf.Min(_currentMana + amount, maxMana);
        Debug.Log($"Current Mana = {_currentMana}");
    }

    public bool CanCast(int cost)
    {
        return _currentMana >= cost; //Hacer cooldown después
    }

    public bool IsDead() => _currentHealth <= 0;
}
