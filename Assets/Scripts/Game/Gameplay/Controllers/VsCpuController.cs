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
        [SerializeField]public List<(Player, float)> classification; // final classification
        public Text positionText;
        public SpawnPoint[] spawnPoints;

        private void Start()
        {
            classification = new List<(Player, float)>();
            Initialize();
        }
        internal new void Initialize()
        {
            GameObject instance = Resources.Load<GameObject>("Prefabs/Player");
            GetSpawnPoints();
            Spawn(instance, spawnPoints[0].transform.position);
            SpawnShips();
        }
        public void GetSpawnPoints()
        {
            spawnPoints = FindObjectsOfType<SpawnPoint>();
            Array.Sort(spawnPoints, delegate (SpawnPoint x, SpawnPoint y)
                {
                    return x.id - y.id;
                }
            );
        }
        public void SpawnShips()
        {
            GameObject ship = Resources.Load<GameObject>("Prefabs/NPC");
            for(int i = 1; i < spawnPoints.Length; ++i)
            {
                GameObject instance = Instantiate(ship, spawnPoints[i].transform.position, Quaternion.identity);
                instance.GetComponent<NPC>().numberId = i;
                Debug.Log("new ship");
                
                instance.GetComponent<NPC>().raceController = this;
                // TODO set random ship
            }
        }

        internal void CheckGoal(Player player, Collider other)
        {
            if (ReferenceEquals(other.gameObject, goal.gameObject) && !player.finished)
            {
                Debug.Log("Goal!!!!!!!!!");
                this.Finish(player);
            }
        }
        private void Finish(Player player)
        {
            // TODO finish the race
            
            SetFinishTime(player, time);
            if (player.transform.parent.CompareTag("Player")) ShowResultPanel();
            //SceneSelector.goToResultList();
        }

        private void SetFinishTime(Player player,float time)
        {
            Debug.Log("SetFinishTIme");
            if (!player.finished)
            {
                Debug.Log(time);
                player.finished = true;
                classification.Add((player, time));
                Debug.Log(player.username + " : " + time);
            }
        }
    }
}

