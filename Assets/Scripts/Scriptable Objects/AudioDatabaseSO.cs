using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioDatabase", menuName = "MyScriptableObjects/Audio Database")]
public class AudioDatabaseSO : ScriptableObject
{
    [SerializeField] private List<AudioMapping> mappings = new List<AudioMapping>(); // List of enemy that are linked to audio using mappings

    private Dictionary<EnemyTypes, AudioClip> _audioMap; // Dictionary is used for a quick lookup for enemies or audio in Unity

    private void OnEnable()   // OnEnable function is used when SO is activated and ensures the dictionary is not null and ready to be used in the game.
    {
        if (_audioMap == null)
            BuildMap();
    }

    public AudioClip GetClip(EnemyTypes enemyType)  // Function is used to get the clip from the dictionary and returns the audio clip associated to the enemy type if value is not null
    {
        _audioMap.TryGetValue(enemyType, out var clip);
        return clip;
    }

    private void BuildMap()  // BuildMap() function is used to convert serialized list of mappings into dictionary for efficient runtime lookup
    {
        _audioMap = new Dictionary<EnemyTypes, AudioClip>();
        foreach (var mapping in mappings) // This for each condition ensures the dictionary is populated with every mapping defined in the inspector
        {
            if (!_audioMap.ContainsKey(mapping.enemyType)) // Ensures to skip duplicate entries and overwriting exisiting ones.
                _audioMap[mapping.enemyType] = mapping.clip;
        }
    }
}
