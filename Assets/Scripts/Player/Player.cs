using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    public PlayerStats Stats => playerStats;
}
