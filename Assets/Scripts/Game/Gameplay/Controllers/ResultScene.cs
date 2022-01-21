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
        private GameObject rowTemplate;

        void Start()
        {
            localFinishList = finishedPlayers;
            if (RaceController.finishList != null)
            {
                localFinishList = finishedPlayers;
            }
            else {
                localFinishList = new List<(string, float)>();
            }
            
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
            if (finishedPlayers.Count != localFinishList.Count)
            {
                createFinishList();
            }
        }

       private void createFinishList()
        {
            localFinishList = finishedPlayers;
            GameObject g;
            foreach ( (string name, float time) in localFinishList)
            {
                g = Instantiate(rowTemplate, transform);
                g.transform.GetChild(0).GetComponent<Text>().text = name;
                float min = Mathf.FloorToInt(time / 60);
                float sec = time % 60;
                string playerTime = string.Format("{0:00}:{1}", min, sec.ToString());
                g.transform.GetChild(1).GetComponent<Text>().text = playerTime;
            }
        }
    }
}