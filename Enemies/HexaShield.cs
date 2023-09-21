using System.Collections;
using UnityEngine;

public class HexaShield : Entity
{
    public Transform[] shieldSpawnPositions = new Transform[6];
    public GameObject shield_Static;
    public GameObject shield_Dynamic;
    public float timeBetweenAction = 2f;

    float timer;
    bool inAction = false;

    public override void Start()
    {
        base.Start();
        timer = timeBetweenAction;
    }

    public override void Update()
    {
        base.Update();
        if(!inAction)
        {
            timer -= Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, Vector2.zero, Time.deltaTime * 3f);
        }
        
        if(timer <= 0 && !inAction)
        {
            StartCoroutine(Action());
        }
    }
    IEnumerator Action()
    {
        inAction = true;
        yield return null;
        for (int i = 0; i < shieldSpawnPositions.Length; i++)
        {
            Instantiate(shield_Static, shieldSpawnPositions[i]);
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < shieldSpawnPositions.Length; i++)
        {
            shieldSpawnPositions[i].GetChild(0).gameObject.GetComponent<Collider2D>().enabled = false;
            GameObject cur = Instantiate(shield_Dynamic, shieldSpawnPositions[i].position, shieldSpawnPositions[i].rotation, Level.Instance.bulletTransform);
            cur.GetComponent<Rigidbody2D>().velocity = cur.transform.up * 5f;
        }

        GetComponent<Rigidbody2D>().velocity = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized * 10f;

        for (int i = 0; i < shieldSpawnPositions.Length; i++)
        {
            Destroy(shieldSpawnPositions[i].GetChild(0).gameObject);
        }

        inAction = false; 
        timer = timeBetweenAction;
    }

}
