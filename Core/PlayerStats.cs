using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public float maxHealth;
    public float damage;
    public float firerate;
    public float speed;
    public float bulletSpeed;
    public float bulletRange;
    public float bulletSize;
    public float sight;
    public float luck;
    public float accuracy;

    [Header("Extras")]
    public int itemChoices;

    [Header("Statistics")]
    public int enemiesKilled;

    private void Awake()
    {
        Instance = this;
    }
}
