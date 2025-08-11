using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioDatabaseSO audioDatabaseSO;

    public AudioSource audioSource;

    private void OnEnable()
    {
        BasicEnemyAttack.OnEnemyTouch += PlaySound;
    }

    private void OnDisable()
    {
        BasicEnemyAttack.OnEnemyTouch -= PlaySound;
    }

    public void PlaySound(EnemyTypes enemyType)
    {
        audioSource.PlayOneShot(audioDatabaseSO.GetClip(enemyType));
    }
}