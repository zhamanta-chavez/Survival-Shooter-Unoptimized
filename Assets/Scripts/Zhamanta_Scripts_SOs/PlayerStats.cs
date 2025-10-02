using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats/Player", order = 1)]
public class PlayerStats : ScriptableObject
{
    public int startingHealth = 100;
    public int currentHealth;
    public bool damaged;
}
