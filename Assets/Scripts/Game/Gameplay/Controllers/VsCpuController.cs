using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gameplay.actors;

namespace Gameplay.controllers
{
    public class VsCpuController : RaceController
    {
        private (Player, float) classification; // final classification
        public Text positionText;
        public SpawnPoint[] spawnPoints;

        private void Start()
        {
            Initialize();
        }
        internal new void Initialize()
        {
            GameObject instance = Resources.Load<GameObject>("Prefabs/Player");
            GetSpawnPoints();
            Spawn(instance, spawnPoints[0].transform.position);
            SpawnShips();
        }
        void GetSpawnPoints()
        {
            spawnPoints = FindObjectsOfType<SpawnPoint>();
            Array.Sort(spawnPoints, delegate (SpawnPoint x, SpawnPoint y)
                {
                    return x.id - y.id;
                }
            );
        }
        void SpawnShips()
        {
            GameObject ship = Resources.Load<GameObject>("Prefabs/NPC");
            for(int i = 1; i < spawnPoints.Length; ++i)
            {
                Instantiate(ship, spawnPoints[i].transform.position, Quaternion.identity);

            }
        }
        private void Finish(Player player)
        {

        }
    }
}

