using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "GameConfiguration/Enemy")]
public class EnemyData : ScriptableObject
{
    public float chaseRange;
    public float health;
}
