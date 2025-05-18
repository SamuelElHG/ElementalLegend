using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int playerXP = 0;
    [SerializeField] public int playerLevel = 1;
    [SerializeField] private int xpToNextLevel = 100;

    [SerializeField] private PlayerStats playerStats;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Para que no se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddExperience(int amount)
    {
        playerXP += amount;
        Debug.Log("Ganaste " + amount + " XP. Total: " + playerXP);

        if (playerXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        playerLevel++;
        playerXP = 0;
        xpToNextLevel += 50; // O ajusta según tu curva de dificultad
        Debug.Log("¡Subiste a nivel " + playerLevel + "!");

        playerStats.health = playerStats.health * 2;
        playerStats.AttackDamage = playerStats.AttackDamage * 2;
        playerStats.Defense = playerStats.Defense * 2;
    }
}
