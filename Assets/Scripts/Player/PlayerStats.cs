using UnityEngine;


[CreateAssetMenu(fileName = "PlayerStats", 
menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Config")]
    [SerializeField] public int Playerlevel = 1;

    [Header("Health")]
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int currentHealth = 100;
}
