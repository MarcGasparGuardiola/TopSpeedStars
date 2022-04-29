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
        static int spawnNum = 0;
        // Start is called before the first frame update
        private new void Awake()
        {
            base.Awake();
            Debug.Log("Online Race!!");
            classification = new List<(Player, float)>();
            Initialize();
        }
        void Start()
        {
            
        }
        internal new void Initialize()
        {
            GameObject instance = Resources.Load<GameObject>("Prefabs/Player");
            GetSpawnPoints();
            Spawn(instance, spawnPoints[spawnNum].transform.position);
            spawnNum++;

        }
        public new void Spawn(GameObject g, Vector3 position)
        {
            Debug.Log("Spawn ships online");
            GameObject i = PhotonNetwork.Instantiate("Prefabs/Player", position, Quaternion.identity);
            i.tag = "Player";

            //  GameplayManager.Instance.character;
            CharacterList cl = FindObjectOfType<CharacterList>();
            i.GetComponentInChildren<Player>().character = cl.characters[(int)PhotonNetwork.LocalPlayer.CustomProperties["characterId"]];
            /* (i.GetComponentInChildren<PhotonView>().IsMine)
            {
                GameObject t = i.GetComponentsInChildren<MFlight.MouseFlightController>(true)[0].gameObject;
                Debug.Log(t);
                t.SetActive(true);
            }*/
            
            InitializePlayer(i.GetComponentInChildren<Player>());
        }
        void InitializePlayer(Player player)
        {
            player.raceController = this;
            player.SetCheckpoint(checkPoints[0]);
        }
    }
}

