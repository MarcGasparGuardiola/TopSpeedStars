using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gameplay.actors;
using System;
using MFlight;
using Gameplay.controllers;
using Photon.Pun;



public class RaceController : MonoBehaviour
{
    private (Player, float) finalTime;
    public Goal goal;
    public List<CheckPoint> checkPoints;
    public float time = 0f;
    public Text timeText;

    public Text finishText;
    public Vector3 spawnPosition;
    private bool finished = false;
    public FinishPanel resultPanel;

    internal void Awake()
    {
        GetCheckpoints();
        timeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>();
        goal = FindObjectOfType<Goal>();
        finishText = GameObject.FindGameObjectWithTag("FinishText").GetComponent<Text>();
    }


    void Start()
    {
        // TODO start race and timer
        Initialize();
    }
        
    void Update()
    {
        time += Time.deltaTime;
        DisplayTime(time);
    }

    internal void Initialize()
    {
        Debug.Log("inint");
        GameObject instance = Resources.Load<GameObject>("Prefabs/Player");
        GetSpawnPoint();
        Spawn(instance, spawnPosition);
    }

    internal void Spawn(GameObject g, Vector3 position)
    {
        GameObject i = Instantiate(g,position, new Quaternion(0,0,0,0));
        i.tag = "Player";
        GameObject t = i.GetComponentsInChildren<MFlight.MouseFlightController>(true)[0].gameObject;
        Debug.Log(t);
        t.SetActive(true);

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
        if (ReferenceEquals(check.gameObject, goal.gameObject) && !player.finished)
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

    private void Finish(Player player)
    {
        // TODO finish the race

        player.finished = true;
        this.finished = true;
        SetFinishTime(time, player);
        if (player.transform.parent.CompareTag("Player")) ShowResultPanel();
        ResultScene.addTime(player.username, time);
    }

    public void ShowResultPanel()
    {
        try
        {
            resultPanel = GameObject.FindObjectOfType<FinishPanel>(true);
               
            resultPanel.gameObject.SetActive(true);
        }
        catch { }
    }

    private void SetFinishTime(float time, Player player)
    {
        float min = Mathf.FloorToInt(time / 60);
        float sec = time % 60;
        finishText.text = string.Format("{0:00}:{1}", min, sec.ToString());
    }

    void DisplayTime(float time)
    {
        if (!finished)
        {
            float min = Mathf.FloorToInt(time / 60);
            float sec = time % 60;
            timeText.text = String.Format("{0:00}:{1}", min, sec.ToString());
        }
    }

    public void toResult()
    {
        GameObject go = GameObject.Find("LevelChanger");
        LevelChanger other = (LevelChanger)go.GetComponent(typeof(LevelChanger));
        other.FadeToLevel("ResultsList");
    }

}


