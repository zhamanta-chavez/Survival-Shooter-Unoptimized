using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    /*public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;*/

    [SerializeField] EnemyStats enemyStats; // Get timeBetweenAttacks and attackDamage from one source

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    int id_playerDead = Animator.StringToHash("PlayerDead"); // Hashing for animations

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= enemyStats.timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) 
        {
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger (id_playerDead); // Replaced string with int
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(enemyStats.attackDamage); 
        }
    }
}
