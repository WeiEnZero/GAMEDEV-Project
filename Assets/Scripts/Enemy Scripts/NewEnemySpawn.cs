using UnityEngine;
using System.Collections.Generic;
using UnityEditor.EditorTools;

namespace Enemy
{
    public class NewEnemySpawn : MonoBehaviour
    {
        public Transform[] spawnPoints;
        [SerializeField] private List<GameObject> enemies;

        public Transform enemyParent;

        float timer = 0f;

        Timer gameTime;

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
            timer += Time.deltaTime;       // Timer is increased each second with Time.deltaTime and used to determine the spawning time for enemy objects each interval period.
            if (timer >= 1.45f)          // This if condition is used when the timer is 2 seconds or more, it will activate the SpawnEnemies function to spawn in a random enemy from the array and resets the timer to prepare for the next spawn in.
            {
                SpawnEnemies();
                timer = 0f;
            }
        }
    }
}
