using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Gameplay.controllers;
public class RaceManager : MonoBehaviour
{

    void Start()
    {
        if (GameplayManager.Instance != null)
        {
            switch (GameplayManager.Instance.playType)
            {
                case 0:
                    transform.gameObject.AddComponent<RaceController>();
                    break;
                case 1:
                    transform.gameObject.AddComponent<VsCpuController>();
                    break;
                case 2:
                    transform.gameObject.AddComponent<OnlineController>();
                    break;
                default:
                    SceneManager.LoadScene("PlaneSelectionScene");
                    break;
            }
        }
    }
}
