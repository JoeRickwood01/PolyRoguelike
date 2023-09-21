using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level : MonoBehaviour
{
    public static Level Instance { get; private set; }

    [Header("Item Selection")]
    public GameObject itemSelectionPrefab;
    public Transform cardSelectionTransform;

    [Header("Enemies")]
    public GameObject enemySpawnerPrefab;
    public GameObject[] enemyPrefabs;
    public int[] enemyRoundThreshold;
    public Transform enemyTransform;
    public Transform bulletTransform;
    public int enemiesRemaining = 0;

    [Header("End Game Panel")]
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private Text roundCountText;
    [SerializeField] private Text enemiesKilledText;

    bool inMenu = false;
    Entity Player;

    public int round;
    bool gameOver = false;

    private void Start()
    {
        Instance = this;

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>();
    }

    private void Update()
    {
        enemiesRemaining = enemyTransform.childCount;

        if(enemiesRemaining <= 0 && inMenu == false)
        {
            FinishLevel();
            inMenu = true;
            round++;
        }
    }

    public virtual void OpenItemSelectionPanel()
    {
        Item[] items = new Item[PlayerStats.Instance.itemChoices];
        for (int i = 0; i < PlayerStats.Instance.itemChoices; i++)
        {
            Item item = InventoryManager.Instance.GetRandomItem();

            bool found = false;
            while (found == false)
            {
                found = true;
                for (int j = 0; j < items.Length; j++)
                {
                    if (items[j] != null)
                    {
                        if (item.id == items[j].id)
                        {
                            item = InventoryManager.Instance.GetRandomItem();
                            found = false;
                        }
                    }
                }
            }

            items[i] = item;
            GameObject cur = Instantiate(itemSelectionPrefab, cardSelectionTransform);
            cur.GetComponent<ItemCard>().SetItem(item);
            cur.GetComponent <ItemCard>().SetListener();
        }
    }

    public virtual void CloseItemSelectionPanel()
    {
        for (int i = 0; i < cardSelectionTransform.childCount; i++)
        {
            Destroy(cardSelectionTransform.GetChild(i).gameObject);
        }

        inMenu = false;

        HandleEnemySpawning();
    }

    public virtual void HandleEnemySpawning()
    {
        List<GameObject> currentEnemyObjects = new List<GameObject>();
        for (int i = 0; i < enemyRoundThreshold.Length; i++) {
            if(round >= enemyRoundThreshold[i])
            {
                currentEnemyObjects.Add(enemyPrefabs[i]);
            }
        }

        for (int i = 0; i < Mathf.RoundToInt(Mathf.Pow(round / 2, 1.6f)) + 20; i++)
        {
            //Calculate Position
            float minDistance = 10f;
            float maxDistance = (Mathf.RoundToInt(Mathf.Pow(round, 1.2f)) + 100) / 5f;
            float distance = Random.Range(minDistance, maxDistance);
            float angle = Random.Range(-Mathf.PI, Mathf.PI);

            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

            Vector3 spawnPosition = playerTransform.position;
            spawnPosition += new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;
            SpawnEnemyAtPoint(Random.Range(0, currentEnemyObjects.Count), spawnPosition);
        }
    }

    public virtual void SpawnEnemyAtPoint(int ID, Vector3 position)
    {
        GameObject cur = Instantiate(enemySpawnerPrefab, position, Quaternion.identity, enemyTransform);
        cur.GetComponent<EnemySpawner>().SetId(ID);
    }

    public virtual void FinishLevel()
    {
        if(gameOver == true) { return; }
        OpenItemSelectionPanel();
        int heal = Mathf.RoundToInt(Mathf.Clamp(Player.currentHealth + (Player.maxHealth * 0.33f), 0, Player.maxHealth));
        Player.currentHealth = heal;

        for (int i = 0; i < enemyTransform.childCount; i++)
        {
            Destroy(enemyTransform.GetChild(i).gameObject);
        }

        for (int i = 0; i < bulletTransform.childCount; i++)
        {
            Destroy(bulletTransform.GetChild(i).gameObject);
        }
    }

    public virtual void EndGame()
    {
        Debug.Log("Game Ended");
        endGamePanel.SetActive(true);
        roundCountText.text = $"Round : {round}";
        enemiesKilledText.text = $"{PlayerStats.Instance.enemiesKilled} Enemies";
        gameOver = true;

        for (int i = 0; i < enemyTransform.childCount; i++)
        {
            Destroy(enemyTransform.GetChild(i).gameObject);
        }

        for (int i = 0; i < bulletTransform.childCount; i++)
        {
            Destroy(bulletTransform.GetChild(i).gameObject);
        }
;   }

    public void StartNewGame()
    {
        SceneManager.LoadScene("Game");
    }
}
