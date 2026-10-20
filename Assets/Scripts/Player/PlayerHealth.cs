using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerStats playerStats;
    private PlayerAnimation playerAnimation;
    // A interface IDamageable funciona como um "contrato": qualquer classe que a implemente
    // é obrigada a ter o método TakeDamage(float amount).
    // Como PlayerHealth implementa IDamageable (através de ", IDamageable"),
    // o método TakeDamage torna-se acessível e deve ser implementado nesta classe.
    public void TakeDamage(float amount)
    {
        playerStats.currentHealth -= (int)amount;
        if (playerStats.currentHealth <= 0)
        {
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        playerStats.currentHealth = 0;
        playerAnimation.SetDeadAnimation();
    }

    void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1f);
            Debug.Log($"Player Health: {playerStats.currentHealth}");
        }
    }
}
