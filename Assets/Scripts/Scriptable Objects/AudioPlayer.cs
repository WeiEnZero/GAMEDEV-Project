using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioDatabaseSO audioDatabaseSO; // Takes in the SO Audio Database that stores the audio clips.

    public AudioSource audioSource; // Takes in the audio source object to play the sound and adjust volume related settings.

    private void OnEnable() // The OnEnable functions links the OnEnemyTouch Invoke from the BasicEnemyAttack Script to play the sound on start of the event.
    {
        BasicEnemyAttack.OnEnemyTouch += PlaySound;
    }

    private void OnDisable()  // The OnDisable functions links the OnEnemyTouch Invoke from the BasicEnemyAttack Script to end the sound when its done playing to prevent memory leaks.
    {
        BasicEnemyAttack.OnEnemyTouch -= PlaySound;
    }

    public void PlaySound(EnemyTypes enemyType) // This function is used when the collision event takes place and play the sound without interrupting any currently playing audio.
    {
        audioSource.PlayOneShot(audioDatabaseSO.GetClip(enemyType));
    }
}