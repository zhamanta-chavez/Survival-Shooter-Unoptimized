using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    /*public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;*/


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    Enemy_SO enemy; // Reference to enemy scriptable object


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

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack ()
    {
        timer = 0f;

        /*if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }*/
        if (this.name.Contains("Zombunny"))
        {
            if (playerHealth.currentHealth > 0)
            {
                playerHealth.TakeDamage(enemy.zombunnyAttackDamage);
            }
        }
        else if (this.name.Contains("ZomBear"))
        {
            if (playerHealth.currentHealth > 0)
            {
                playerHealth.TakeDamage(enemy.zombearAttackDamage);
            }
        }
        else if (this.name.Contains("Hellephant"))
        {
            if (playerHealth.currentHealth > 0)
            {
                playerHealth.TakeDamage(enemy.hellephantAttackDamage);
            }
        }
    }
}
