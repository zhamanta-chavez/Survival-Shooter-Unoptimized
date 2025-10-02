using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "UI_Events", menuName = "Events/UI", order = 2)]
public class UI_Events : ScriptableObject
{
    public UnityAction OnEnemyDied;
    public UnityAction OnPlayerAttacked;

    public void AddListener(UnityAction action, UnityAction action2)
    {
        OnEnemyDied += action;
        OnPlayerAttacked += action2;
    }
}
