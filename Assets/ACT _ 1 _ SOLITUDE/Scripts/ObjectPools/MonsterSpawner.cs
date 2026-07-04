using UnityEngine;
using System.Collections.Generic;


public class MonsterSpawner : MonoBehaviour
{
    [Header("Pool Settings")]
    public GameObject monsterPrefab;
    public int poolSize = 5;
    private List<GameObject> monsterPool;

    [Header("Spawning Settings")]
    //Spawn monster every 2 seconds
    public float spawnInterval = 2f;
    //How far ahead of the bike is the monster spawning
    public float spawnZPosition = 40f;
    public float spawnYPosition = 0;
    //How far left and right the monsters can spawn
    public float roadWidth = 6f;

    [Header("Monster Movement")]
    //how fast they move towards the bike
    public float monsterSpeed = 8f;
    //where they should deactivate behind the bike - if player doesn't hit them
    public float despawnZPosition = -15f;
    public float despawnYPosition = 0;

    private float spawnTimer;

    private void Start()
    {

        Debug.Log("MonsterSpawner started on " + gameObject.name);
        //initialize list
        monsterPool = new List<GameObject>();

        //5 monsters generate (but turn them off straight away
        for (int i = 0; i <poolSize; i++)
        {
            GameObject monster = Instantiate(monsterPrefab);
            monster.SetActive(false);
            monsterPool.Add(monster);
        }
    }

    //moving and spawning
    private void Update()
    {
        //timing
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnMonster();  //make this method later
            spawnTimer = 0f;
        }

        //what happens if it misses a monster and it just keeps on going and never goes back to the pool?
        MoveAndRecycleMonsters(); // make this one later too
    }

    void SpawnMonster()
    {
        //find a monster that is NOT active
        GameObject monster = GetPooledMonster(); // ------------- make this method after

        if(monster != null)
        {

            Debug.Log("About to activate ");

            //pick a random lane on thew road
            float randomX = Random.Range(-roadWidth / 2f, roadWidth / 2f);
            //monster.transform.position = new Vector3(randomX, 0.5f, spawnZPosition);
            monster.transform.position = new Vector3(randomX, spawnYPosition, spawnZPosition);

            //turn it on
            monster.SetActive(true);

            Debug.Log("Activated " + monster.name);
        }
    }

    GameObject GetPooledMonster()
    {
        //go through the pool and find one thats available
        for(int i = 0; i < monsterPool.Count; i++)
        {
            if (!monsterPool[i].activeInHierarchy)
            {
                return monsterPool[i];
            }
        }
        //but if all 5 are already on screen, reutnr nothing
        return null;
    }

    void MoveAndRecycleMonsters()
    {
        for (int i = 0; i < monsterPool.Count; i++)
        {
            //move the ones that are visible ONLY
            if (monsterPool[i].activeInHierarchy)
            {
                //move towards trhe bike
                monsterPool[i].transform.Translate(Vector3.back * monsterSpeed * Time.deltaTime, Space.World);

                //if they go behind the bike, and can't see them  anymore then turn them off
                if (monsterPool[i].transform.position.z <= despawnZPosition)
                {
                    monsterPool[i].SetActive(false);
                }
            }
        }
    }



}


