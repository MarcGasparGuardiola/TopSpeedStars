using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gameplay.actors;
using System;

namespace Gameplay.controllers
{
    public class RaceController : MonoBehaviour
    {
        public Goal goal;
        public List<CheckPoint> checkPoints;
        float time = 0f;
        public Text timeText;
        public Vector3 spawnPosition;

        private void Awake()
        {
            GetCheckpoints();
            timeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>();
            goal = FindObjectOfType<Goal>();
        }

        void Start()
        {
            // TODO start race and timer
            Initialize();
        }
        internal void Initialize()
        {
            GameObject instance = Resources.Load<GameObject>("Prefabs/Player");
            GetSpawnPoint();
            Spawn(instance, spawnPosition);
        }
        void Update()
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }

        internal void Spawn(GameObject g, Vector3 position)
        {
            GameObject i = Instantiate(g,position, new Quaternion(0,0,0,0));
            InitializePlayer(i.GetComponentInChildren<Player>());
        }

        void InitializePlayer(Player player)
        {
            player.raceController = this;
            player.SetCheckpoint(checkPoints[0]);
            Debug.Log("Initialize");
        }

        internal void SetPlayerCheckpoint(Player player, CheckPoint check)
        {
            if (ReferenceEquals(check.gameObject, goal.gameObject))
            {
                this.Finish(player);
            } else
            {
                int id = checkPoints.FindIndex(x => GameObject.ReferenceEquals(check.gameObject, x.gameObject));
                try
                {
                    player.SetCheckpoint(checkPoints[id + 1]);
                    Debug.Log(id);
                }
                catch { }
            }
        }

        private void Finish(Player player)
        {
            // TODO finish the race
            player.SetFinishTime(time);
            SceneSelector.goToResultList();
        }

        void DisplayTime(float time)
        {
            float min = Mathf.FloorToInt(time / 60);
            float sec = time % 60;
            timeText.text = String.Format("{0:00}:{1}", min, sec.ToString());
        }

        void GetCheckpoints()
        {
            checkPoints = new List<CheckPoint>();
            checkPoints.AddRange(FindObjectsOfType<CheckPoint>());
            checkPoints.Sort(delegate (CheckPoint x, CheckPoint y)
            {
                return x.id - y.id;
            });
        }
        private void GetSpawnPoint()
        {
            foreach (GameObject s in GameObject.FindGameObjectsWithTag("Spawn"))
            {
                if (s.GetComponent<SpawnPoint>().id == 0)
                {
                    spawnPosition = s.transform.position;
                    return;
                }
            }
        }

    }
}

