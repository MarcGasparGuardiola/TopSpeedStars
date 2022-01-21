using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gameplay.actors;

namespace Gameplay.controllers
{
    public class ResultScene : MonoBehaviour
    {
        static public List<(string, float)> finishedPlayers = new List<(string, float)>();
        // Start is called before the first frame update
        private List<(string, float)> localFinishList;
        static private GameObject rowTemplate;
        private GameObject list;

        void Start()
        {
            localFinishList = finishedPlayers;

            list = GameObject.FindGameObjectsWithTag("List")[0];
            rowTemplate = GameObject.FindGameObjectsWithTag("Row")[0];
            

            Debug.Log("-----TEST-----");
            Debug.Log(localFinishList);
            Debug.Log(localFinishList.Count);
            Debug.Log(finishedPlayers.Count); 
            Debug.Log("----------");
            createFinishList();
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(finishedPlayers.Count);
            Debug.Log(localFinishList.Count);

            if (finishedPlayers.Count != localFinishList.Count)
            {
                Debug.Log("Lists count different re-creating list");
                createFinishList();
            }
        }

       static public void addTime(string name, float time)
        {
            finishedPlayers.Add((name, time));
        }

       private void createFinishList()
        {
            Debug.Log("List Created");
            GameObject g;
            foreach ( (string name, float time) in finishedPlayers)
            {
                g = Instantiate(rowTemplate, list.transform);
                g.transform.GetChild(0).GetComponent<Text>().text = name;
                float min = Mathf.FloorToInt(time / 60);
                float sec = time % 60;
                string playerTime = string.Format("{0:00}:{1}", min, sec.ToString());
                g.transform.GetChild(1).GetComponent<Text>().text = playerTime;
                Destroy(g);
            }
        }
    }
}