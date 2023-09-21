using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public List<DamageTick> damageTicks;

    //Start Is Called On First Frame So Should Be Used For Initializing
    public virtual void Start()
    {
        currentHealth = maxHealth;

        damageTicks = new List<DamageTick>();
    }

    //Update Is Called Every Frame
    public virtual void Update()
    {
        for (int i = 0; i < damageTicks.Count; i++)
        {
            damageTicks[i].timer -= Time.deltaTime;

            if (damageTicks[i].timer <= 0)
            {
                TakeDamage(Mathf.RoundToInt(damageTicks[i].damage));
                damageTicks[i].timer = damageTicks[i].tickLength;
            }
        }
    }

    //Other Scripts Can Call The Take Damage Method To Deal Damage To This Specific Entity
    //The Method Is Marked Virtual In Case Other Entities Have Custom Behaviour When Damaged
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0) { Die(); }
    }

    //Other Scripts Can Call The Die Method To Kill This Specific Entity
    //The Method Is Marked Virtual In Case Other Entities Have Custom Behaviour When Killed
    public virtual void Die()
    {
        InventoryManager.Instance.enemyKilledEvent(transform.position);
        PlayerStats.Instance.enemiesKilled++;
        Destroy(gameObject);
    }


    //OnTriggerEnter2D is called when the current object enters a trigger area
    //The Method Is Marked Virtual In Case Other Entities Have Custom Behaviour When Entering Triggers
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Damage"))
        {
            TakeDamage(collision.gameObject.GetComponent<Damage>().damage);
        }
    }
}

//Damage Tick Class Is Used To Deal Damage Over Time To An Entity
public class DamageTick
{
    public float damage;
    public float tickLength;
    public DamageType damageType;
    public float timer;

    public DamageTick(float damage, float tickLength, DamageType damageType, float timer)
    {
        this.damage = damage;
        this.tickLength = tickLength;
        this.damageType = damageType;
        this.timer = 0;
    }


}

//Used By The Damage Tick Class To Classify What Type Of Damage Is Being Dealt
public enum DamageType
{
    Poison,
    Fire,
    Acid
}
