using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioDatabase", menuName = "MyScriptableObjects/Audio Database")]
public class AudioDatabaseSO : ScriptableObject
{
    [SerializeField] private List<AudioMapping> mappings = new List<AudioMapping>();

    private Dictionary<EnemyTypes, AudioClip> _audioMap;

    private void OnEnable()
    {
        if (_audioMap == null)
            BuildMap();
    }

    public AudioClip GetClip(EnemyTypes enemyType)
    {
        _audioMap.TryGetValue(enemyType, out var clip);
        return clip;
    }

    private void BuildMap()
    {
        _audioMap = new Dictionary<EnemyTypes, AudioClip>();
        foreach (var mapping in mappings)
        {
            if (!_audioMap.ContainsKey(mapping.enemyType))
                _audioMap[mapping.enemyType] = mapping.clip;
        }
    }
}
