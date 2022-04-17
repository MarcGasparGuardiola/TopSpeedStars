using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.actors;
using Photon.Pun;

namespace Gameplay.controllers
{
    public class OnlineController : VsCpuController
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Online Race!!");
            classification = new List<(Player, float)>();
            Initialize();
        }
        internal new void Initialize()
        {
            GameObject instance = Resources.Load<GameObject>("Prefabs/Player");
            GetSpawnPoints();
            Spawn(instance, spawnPoints[0].transform.position);
        }
        public new void Spawn(GameObject g, Vector3 position)
        {
            Debug.Log("Spawn ships online");
            GameObject i = PhotonNetwork.Instantiate("Prefabs/Player", Vector3.zero, Quaternion.identity);
            i.tag = "Player";
            InitializePlayer(i.GetComponentInChildren<Player>());
        }
        void InitializePlayer(Player player)
        {
            player.raceController = this;
            player.SetCheckpoint(checkPoints[0]);
        }
    }
}

