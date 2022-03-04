using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.controllers;
public class RaceManager : MonoBehaviour
{

    void Start()
    {
        if (GameplayManager.Instance != null)
        {
            switch (GameplayManager.Instance.playType)
            {
                case 1:
                    transform.gameObject.AddComponent<RaceController>();
                    break;
                case 2:
                    // TODO vs cpu
                    break;
                case 3:
                    // TODO multiplayer online
                    break;
                default:
                    // TODO failsafe back to menu
                    break;
            }
        }
    }
}
