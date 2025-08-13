using System.Collections.Generic;
using UnityEngine;

public class HeroAudioPlayer : MonoBehaviour
{
    public HeroAudioDatabaseSO audioDatabaseSO; // Takes in the SO Audio Database that stores the audio clips.

    public AudioSource audioSource; // Takes in the audio source object to play the sound and adjust volume related settings.

    private void OnEnable() // The OnEnable functions links the OnPlayerTouch Invoke from the PlayerAttackRange Script to play the sound on start of the event.
    {
        PlayerAttackRange.OnPlayerTouch += PlayHeroSound;
    }

    private void OnDisable()  // The OnDisable functions links the OnPlayerTouch Invoke from the PlayerAttackRange Script to end the sound when its done playing to prevent memory leaks.
    {
        PlayerAttackRange.OnPlayerTouch -= PlayHeroSound;
    }

    public void PlayHeroSound(PlayerList playerType) // This function is used when the collision event takes place and play the sound without interrupting any currently playing audio.
    {
        audioSource.PlayOneShot(audioDatabaseSO.GetHeroClip(playerType));
    }
}
