using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public Item[] itemDatabase;

    public List<Item> playerInventory;

    public List<int> itemTable;

    public Color[] rarityColors;


    //Delegates To Handle Events To Send To Items, This Is The BACKBONE Of Most Custom Item Behaviour
    public delegate void AddItemDelegate(int itemID);
    public event AddItemDelegate addItemEvent;

    public delegate void EnemyKilledDelegate(Vector3 pos);
    public EnemyKilledDelegate enemyKilledEvent;

    public delegate void BulletSpawnDelegate(GameObject obj);
    public BulletSpawnDelegate bulletSpawnEvent;

    public delegate void BulletImpactDelegate(Vector3 pos, GameObject obj);
    public BulletImpactDelegate bulletImpactEvent;

    //Awake Is Called Before First Frame 
    private void Awake()
    {
        Instance = this;
    }

    //Initialize Inventory Components During Start Method
    private void Start()
    {
        playerInventory = new List<Item>();
        itemTable = new List<int>();

        /*  
            Initialize Item Database to be called from other scripts to clone the items inside
            It contains one of every item so the items inside shouldnt be changed in any way 
            otherwide other future items picked up wont work as expected 
        */

        itemDatabase = new Item[]
        {
            new FasterFeet(), new AdaptiveChambering(), new ReccuringDream(),
            new ClumsyAkimbo(), new StrongHeart(), new Minigun(),
            new SniperRounds(), new HeavyRounds(), new GoliathAmmo(),
            new Shrapnel(), new PhychicBullets(), new Tanky(),
            new PoisonBullets(), new PoisonBullets(), new PyroclasticDemon(),
            new Binoculars(), new TheCountdown(), new Bloodlust(),
            new Steroids(), new Carrot(), new Choices(),
            new PrimalSoup(), new Hivemind(), new VitalityEngine(),
            new ShrinkingShots(), new Demise()
        };

        /*  
            Create ItemTable to figure out item rarity and item chance once a round has ended
            the equation to figure out how many times an items shows up in the item table is:
            (7 - itemRarity) to the power of 3 rounded to the nearest integer
        */

        for (int i = 0; i < itemDatabase.Length; i++)
        {
            itemDatabase[i].Init();

            for (int b = 0; b < Mathf.Pow(7 - (int)itemDatabase[i].rarity, 3f); b++)
            {
                itemTable.Add(itemDatabase[i].id);
            }
        }
    }

    //Gets Random Item From The Item Data Weighted From The ItemTable
    public Item GetRandomItem()
    {
        System.Random random = new System.Random();
        int rand = random.Next(0, itemTable.Count);

        return (Item)itemDatabase[itemTable[rand]].Clone();
    } 

    //Gets Specific Item Within The Item Database With Input ID
    public Item GetItemWithID(int ID)
    {
        return (Item)itemDatabase[ID].Clone();
    }

    //Adds Item To The Current Player Inventory 
    public void AddItemToInventory(Item item)
    {
        playerInventory.Add(item);
        item.Activate();

        bulletSpawnEvent += item.OnBulletSpawn;
        bulletImpactEvent += item.OnBulletImpact;
        enemyKilledEvent += item.OnEnemyKilled;

        if(addItemEvent != null)
        {
            addItemEvent(item.id);
        }
    }
}

//Item Class, Contains Variable And Virtual Methods In Order To Customize Item
public class Item
{
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    public Rarity rarity;

    public virtual void Init()
    {
        id = 0;
        name = "Test Item";
        description = "Test Item Description";
        icon = Resources.Load<Sprite>(name);
    }

    public virtual object Clone()
    {
        return this.MemberwiseClone();
    }

    public virtual void Activate()
    {

    }

    public virtual void OnItemAdded(int itemID)
    {

    }

    public virtual void OnBulletImpact(Vector3 pos, GameObject obj)
    {

    }

    public virtual void OnBulletSpawn(GameObject bullet)
    {

    }

    public virtual void OnEnemyKilled(Vector3 pos)
    {

    }
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Evil
}
