using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/Enemy", order = 0)]
public class EnemyStats : ScriptableObject
{
    // Enemy identifier
    public int enemyType;

    // Stats
    public int startingHealth = 300;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 30;
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 30;
    public AudioClip deathClip;
}
