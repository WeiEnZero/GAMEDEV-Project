using System;
using UnityEngine;

[Serializable]
public class HeroAudioMapping
{
    [SerializeField] public PlayerList playerType; // List of Player Types.
    [SerializeField] public AudioClip heroClip; // The audio linked to the player type
}
