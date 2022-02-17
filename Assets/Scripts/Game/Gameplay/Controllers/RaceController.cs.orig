using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gameplay.actors;
using System;
using Gameplay.controllers;

namespace Gameplay.controllers
{
    public class RaceController : MonoBehaviour
    {
        public static List<Player> raceFinishOrder;
        public Goal goal;
        public List<CheckPoint> checkPoints;
        float time = 0f;
        public Text timeText;

        void Start()
        {
            raceFinishOrder = new List<Player>();
            // TODO start race and timer
        }

        void Update()
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }

        internal void InitializePlayer(Player player)
        {
            player.SetCheckpoint(checkPoints[0]);
            Debug.Log("Initialize");
        }

        internal void SetPlayerCheckpoint(Player player, CheckPoint check)
        {
            if (GameObject.ReferenceEquals(check.gameObject, goal.gameObject))
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
<<<<<<< HEAD
            ResultScene.addTime(player.name, player.time);
            // SceneSelector.goToFinishRaceScene();

            GameObject go = GameObject.Find("LevelChanger");
            LevelChanger other = (LevelChanger)go.GetComponent(typeof(LevelChanger));
            other.FadeToLevel("ResultsList");
=======
            raceFinishOrder.Add(player);
            SceneSelector.goToResultList();
>>>>>>> origin
        }

        void DisplayTime(float time)
        {
            float min = Mathf.FloorToInt(time / 60);
            float sec = time % 60;
            timeText.text = String.Format("{0:00}:{1}", min, sec.ToString());
        }
    }
}

