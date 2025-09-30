using UnityEngine;
using System.Collections.Generic; // Required for Queue
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    /*public GameObject enemy;*/
    [SerializeField] GameObject zombunny;
    [SerializeField] GameObject zombear;
    [SerializeField] GameObject hellephant;

    /*public float spawnTime = 3f;*/
    [SerializeField] float zombunnySpawnTime = 3f;
    [SerializeField] float zombearSpawnTime = 3f;
    [SerializeField] float hellephantSpawnTime = 10f;

    public Transform[] spawnPoints;

    // Created queues for enemies
    Queue<GameObject> zombunnyPool = new Queue<GameObject> ();
    Queue<GameObject> zombearPool = new Queue<GameObject>();
    Queue<GameObject> hellephantPool = new Queue<GameObject>();

    void Start ()
    {
        // Create zombunny pool
        for (int i = 0; i < 10; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            var e = Instantiate(zombunny, spawnPoints[0].position, spawnPoints[0].rotation);
            e.SetActive(false);
            zombunnyPool.Enqueue(e);
        }

        // Create zombear pool
        for (int i = 0; i < 10; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            var e = Instantiate(zombear, spawnPoints[1].position, spawnPoints[1].rotation);
            e.SetActive(false);
            zombearPool.Enqueue(e);
        }

        // Create hellephant pool
        for (int i = 0; i < 10; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            var e = Instantiate(hellephant, spawnPoints[2].position, spawnPoints[2].rotation);
            e.SetActive(false);
            hellephantPool.Enqueue(e);
        }

        StartCoroutine(SpawnZombunny());
        StartCoroutine(SpawnZombear());
        StartCoroutine(SpawnHellephant());

        //InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    // Removed empty Update()

    /*void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }*/

    private IEnumerator SpawnZombunny()
    {
        while (true)
        {
            var current = zombunnyPool.Dequeue();
            current.gameObject.SetActive(true);
            yield return new WaitForSeconds(zombunnySpawnTime);
        }
    }

    private IEnumerator SpawnZombear()
    {
        while (true)
        {
            var current = zombearPool.Dequeue();
            current.gameObject.SetActive(true);
            yield return new WaitForSeconds(zombearSpawnTime);
        }
    }

    private IEnumerator SpawnHellephant()
    {
        while (true)
        {
            var current = hellephantPool.Dequeue();
            current.gameObject.SetActive(true);
            yield return new WaitForSeconds(hellephantSpawnTime);
        }
    }

    public void ReturnZombunny(GameObject zombunnyPoolMember)
    {
        zombunnyPoolMember.transform.position = spawnPoints[0].transform.position;
        zombunnyPool.Enqueue(zombunnyPoolMember);
        zombunnyPoolMember.SetActive(false);
    }

    public void ReturnZombear(GameObject zombearPoolMember)
    {
        zombearPoolMember.transform.position = spawnPoints[1].transform.position;
        zombearPool.Enqueue(zombearPoolMember);
        zombearPoolMember.SetActive(false);
    }

    public void ReturnHellephant(GameObject hellephantPoolMember)
    {
        hellephantPoolMember.transform.position = spawnPoints[2].transform.position;
        hellephantPool.Enqueue(hellephantPoolMember);
        hellephantPoolMember.SetActive(false);
    }
}
