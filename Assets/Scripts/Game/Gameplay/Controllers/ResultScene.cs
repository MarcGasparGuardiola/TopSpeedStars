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
        [SerializeField] private GameObject rowTemplate;
        private GameObject list;
        private int localCount;
        

        void Start()
        {
            localCount = finishedPlayers.Count;

            list = GameObject.FindGameObjectsWithTag("List")[0];

            Debug.Log("-----TEST-----");
            Debug.Log(finishedPlayers.Count); 
            Debug.Log("----------");
            createFinishList();
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(finishedPlayers.Count);

            if (localCount != finishedPlayers.Count)
            {
                Debug.Log("Lists count different re-creating list");
                createFinishList();
                localCount = finishedPlayers.Count;
            }
        }

       static public void addTime(string name, float time)
        {
            finishedPlayers.Add((name, time));
        }

       private void createFinishList()
        {
            destroyList();

            Debug.Log("List Created");
            
            GameObject g;
            int pos = 1;
            foreach ( (string name, float time) in finishedPlayers)
            {
                g = Instantiate(rowTemplate, list.transform);

                g.transform.GetChild(0).GetComponent<Text>().text = "#" + pos.ToString();
                ++pos;

                g.transform.GetChild(1).GetComponent<Text>().text = name;

                float min = Mathf.FloorToInt(time / 60);
                float sec = time % 60;
                string playerTime = string.Format("{0:00}:{1}", min, sec.ToString());
                g.transform.GetChild(2).GetComponent<Text>().text = playerTime;
               
                g.SetActive(true);
            }
            // Destroy(rowTemplate);
        }
        private void destroyList()
        {
            for (int i = 1; i < list.transform.childCount; i++)
            {
                GameObject.Destroy(list.transform.GetChild(i).gameObject);
            }
        }
    }
}