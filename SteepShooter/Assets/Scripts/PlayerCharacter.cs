using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;
    private int maxHealth;
    // Use this for initialization
    void Start()
    {
        _health = 50;//инициализация переменной
        maxHealth = 100; //инициализация максимального сдоровья
    }
    public void Hurt(int damage)
    {
        _health -= damage;//уменьшение здоровья игрока
        Debug.Log("Health: " + _health);
    }
    public void ChangeHealth(int value)
    { // Дргие сценарии не могут напрямую задавать переменную health,но могут вызвать эту функцию
        _health += value;
        if (_health > maxHealth)
        {
            _health = maxHealth;//не даем жизни подняться выше максимума
        }
        else if (_health < 0)
        {
            _health = 0;//не даем уменьшать жизнь в минус
        }
        Debug.Log("health: " + _health + "/" + maxHealth);
    }

}
