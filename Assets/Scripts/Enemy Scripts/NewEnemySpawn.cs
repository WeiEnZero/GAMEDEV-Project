using UnityEngine;
using System.Collections.Generic;

namespace Enemy
{
    public class NewEnemySpawn : MonoBehaviour
    {
        public Transform[] spawnPoints;
        [SerializeField] private List<GameObject> enemies;

        public Transform enemyParent;

        float timer = 0f;

        private void Start()
        {

        }

        private void SpawnEnemies()
        {
            // Randomly select a spawnpoint
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Transform sp = spawnPoints[spawnPointIndex];
            Vector3 pos = sp.position;

            // Randomly select an item prefab
            int enemyIndex = Random.Range(0, enemies.Count);
            GameObject enemyOne = enemies[enemyIndex];

            // Instantiate the enemies at the spawn point
            GameObject enemy = Instantiate(enemyOne, pos, Quaternion.identity);
            enemy.transform.SetParent(enemyParent);
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= 0.7f)
            {
                SpawnEnemies();
                timer = 0f;
            }
        }
    }
}
