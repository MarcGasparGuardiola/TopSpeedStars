using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Gameplay.actors;
public class PlaneSelection : MonoBehaviour
{
    public GameObject prefab;
    public Character[] characters;
    public PlaneStatistics planeStatistics;
    public int planeId;
    public Character devChar;
    public static string selected;

    List<PlaneStatistics> planesStatistics;
    
    // Start is called before the first frame update
    /*
    void Start()
    {
        planesStatistics = PlaneList.planesStatistics;

        Debug.Log("Hola");

        if (planesStatistics == null)
        {
            Debug.LogError("Alguna cosa no anat bé al carregar la llista de planes");
        }else
        {
            Debug.Log("Start listing planes");
            // Debug purposes
            foreach (PlaneStatistics plane in planesStatistics)
            {
                Debug.Log(plane.name);
            }
        }
    }
    */
    public void OnPlaneSelect(int id)
    {
        planeId = id;
        GameplayManager.Instance.character = characters[id];
    }

    public void OnConfirmSelection()
    {
        
        StartCoroutine(LoadAsync("SampleScene"));
        
    }

    IEnumerator LoadAsync(string scene)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        Debug.Log("Loading");
        // Wait until the asynchronous scene fully loads
        new WaitForSeconds(3);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    }
}
