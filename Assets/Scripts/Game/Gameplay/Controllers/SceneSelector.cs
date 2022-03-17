using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    // Start is called before the first frame update
   public void goToScene(string scene)
    {
        Debug.Log("Clicked");
        StartCoroutine(LoadAsync(scene));
        
        // SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    IEnumerator LoadAsync(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        Debug.Log("Loading");
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public static void goToResultList()
    {
        SceneManager.LoadScene("ResultsList");
    }
}
