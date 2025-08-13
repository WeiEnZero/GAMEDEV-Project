using System;
using UnityEngine;

[Serializable]
public class AudioMapping
{
    [SerializeField] public EnemyTypes enemyType; // List of Enemy Types.
    [SerializeField] public AudioClip clip; // The audio linked to the enemy type
}
