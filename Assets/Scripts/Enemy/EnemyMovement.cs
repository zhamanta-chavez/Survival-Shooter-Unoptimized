using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Created PlayerHealth player/EnemyHealth enemy here so that they are global
    PlayerHealth playerHealth;
    Transform playerPosition;
    EnemyHealth enemy;
    NavMeshAgent navMesh;

    [SerializeField] PlayerStats playerStats; // Gets player's current health

    private void Awake() // Preserves data even after SetActive(false)
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerPosition = FindObjectOfType<PlayerMovement>().transform;
        enemy = GetComponent<EnemyHealth>();
        navMesh = GetComponent<NavMeshAgent>();
    }


    void Update ()
    {
        /*Transform player = FindObjectOfType<PlayerMovement>().transform;*/

        /*if (GetComponent<EnemyHealth>().currentHealth > 0 && player.GetComponent<PlayerHealth>().currentHealth > 0)
        {
            GetComponent<NavMeshAgent>().SetDestination (player.position);
        }
        else
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }*/


        // Accomplishes the same as the above, but GetComponent is done in Awake() once
        if (enemy.currentHealth > 0 && playerStats.currentHealth > 0)
        {
            navMesh.SetDestination(playerPosition.position);
        }
        else
        {
            navMesh.enabled = false;
        }
    }
}
