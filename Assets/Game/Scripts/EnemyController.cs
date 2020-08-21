using System;
using System.Collections;
using UnityEngine;

namespace FG
{
    public class EnemyController : MonoBehaviour
    {
        [Tooltip("The amount of time to wait before spawning a new enemy")]
        public float coolDown;
        [Tooltip("How many secs after spawning before the collider is enabled on the enemies")]
        public float timeToEnableCollider;
        [Tooltip("The prefab of the first enemy type")]
        public GameObject enemy1;
        [Tooltip("The GameObject that is the parent to all spawnpoints (12 empty GameObjects)")]
        public GameObject enemySpawnpoints;

        private float currentCoolDown; // Cooldown that is ticking down, at 0 or below an enemy will spawn
        private readonly Transform[] spawnPoints = new Transform[12]; // array to hold all spawn point objects
        private int randomPoint; // Variable to store a random value between 0-11 to pick the random spawnpoint
        private Vector3 randomDeviation; // Random Deviation to rotation of the enemy between -15 and 15 degrees
        private Quaternion enemyRotation; // The rotation the enemy will be spawned at

        private void Awake()
        {
            for (int i = 0; i < 12; i++)
            {
                spawnPoints[i] = enemySpawnpoints.transform.Find(Convert.ToString(i + 1));
            }
        }

        void Update()
        {
            currentCoolDown -= Time.deltaTime;

            if (currentCoolDown < 0)
            {
                randomPoint = UnityEngine.Random.Range(0, 11);
                randomDeviation = new Vector3(0, 0, UnityEngine.Random.Range(-15, 15));
                enemyRotation = Quaternion.Euler(spawnPoints[randomPoint].transform.rotation.eulerAngles + randomDeviation);

                // Spawns an enemy with the same pos/rot as the spawn point, parented to this.gameObject
                Instantiate(enemy1, spawnPoints[randomPoint].transform.position, enemyRotation, transform);

                currentCoolDown = coolDown;
            }
        }
    }
}