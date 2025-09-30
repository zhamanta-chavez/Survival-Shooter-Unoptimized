using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Created Awake() in order to preserve data even after SetActive(false)
    private void Awake()
    {
        
    }


    void Update ()
    {
        Transform player = FindObjectOfType<PlayerMovement>().transform;

        if (GetComponent<EnemyHealth>().currentHealth > 0 && player.GetComponent<PlayerHealth>().currentHealth > 0)
        {
            GetComponent<NavMeshAgent>().SetDestination (player.position);
        }
        else
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}
