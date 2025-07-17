using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemies;

    [SerializeField]
    private float _minSpawnTime;

    [SerializeField]
    private float _maxSpawnTime;


    private float _timeUntilSpawn;


    private void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            Instantiate(_enemies, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}
