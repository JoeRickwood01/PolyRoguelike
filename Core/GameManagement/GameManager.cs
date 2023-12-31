using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject[] prefabDatabase;


    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetSpawnablePrefabWithID(int id)
    {
        if (prefabDatabase[id] == null)
        {
            return null;
        }
        return prefabDatabase[id];
    } 

}
