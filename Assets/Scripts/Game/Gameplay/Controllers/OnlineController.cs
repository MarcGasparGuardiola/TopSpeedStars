using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.actors;
using Photon.Pun;
using Photon.Pun.UtilityScripts;

namespace Gameplay.controllers
{
    public class OnlineController : VsCpuController
    {
        // Start is called before the first frame update
        private new void Awake()
        {
            base.Awake();
            Debug.Log("Online Race!!");
            classification = new List<(Player, float)>();
            
        }
        void Start()
        {
            Initialize();
        }
        internal new void Initialize()
        {
            GameObject instance = Resources.Load<GameObject>("Prefabs/Player");
            GetSpawnPoints();
           
            Spawn(instance, spawnPoints[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerId"]].transform.position);
        }
        public new void Spawn(GameObject g, Vector3 position)
        {
            Debug.Log("Spawn ships online");
            GameObject i = PhotonNetwork.Instantiate("Prefabs/Player", position, Quaternion.identity);
            i.tag = "Player";

            if (i.GetComponentInChildren<PhotonView>().IsMine)
            {   
                CharacterList cl = FindObjectOfType<CharacterList>();
                i.GetComponentInChildren<Player>().character = cl.characters[(int) PhotonNetwork.LocalPlayer.CustomProperties["characterId"]];
                InitializePlayer(i.GetComponentInChildren<Player>());
            }
                      
        }
        void InitializePlayer(Player player)
        {
            player.raceController = this;
            player.SetCheckpoint(checkPoints[0]);
        }
        
    }
}

