using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] EnemyStats enemyStats; // Get veriables below from one source

    /*public int startingHealth = 100;*/
    public int currentHealth;
    /*public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;*/

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    // More References
    EnemyManager enemyManager;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    Rigidbody rb;

    int id_dead = Animator.StringToHash("Dead"); // Hashing for animations

    [SerializeField] UI_Events visualEvents; // Sets off visuals

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = enemyStats.startingHealth;

        enemyManager = FindObjectOfType<EnemyManager>(); // Get EnemyManager to be able to return enemies to respective pools

        // Get these components to be able to reset values when enemy dies
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() // Resets enemy state every time enemy is dequeued
    {
        currentHealth = enemyStats.startingHealth;
        isDead = false;
        isSinking = false;
        capsuleCollider.isTrigger = false;
        rb.isKinematic = false;
        navMeshAgent.enabled = true;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * enemyStats.sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    public void Death ()
    {
        isDead = true;
        capsuleCollider.isTrigger = true;
        anim.SetTrigger (id_dead); // Replaced string with int

        enemyAudio.clip = enemyStats.deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        /*GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;*/
        navMeshAgent.enabled = false;
        rb.isKinematic = true;

        isSinking = true;
        ScoreManager.score += enemyStats.scoreValue;
        visualEvents.OnEnemyDied?.Invoke(); // Set off visual
        //Destroy (gameObject, 2f);

        StartCoroutine(WaitToReturn(enemyStats.sinkSpeed)); // Return enemy to pool when they die
    }

    public void ReturnEnemy() // Return enemy to respective pool
    {
        enemyManager.ReturnToPool(enemyStats.enemyType, this.gameObject);
    }

    IEnumerator WaitToReturn( float waitTime) // Will give time for the enemy's dead animation to play out
    {
        yield return new WaitForSeconds(waitTime);
        ReturnEnemy();
    }
}


