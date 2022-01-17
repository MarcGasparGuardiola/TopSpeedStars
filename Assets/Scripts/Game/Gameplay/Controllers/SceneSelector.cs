using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    // Start is called before the first frame update
   public void goToPlaneSelectionScene()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("PlaneSelection");
    }

    public static void goToResultList()
    {
        SceneManager.LoadScene("ResultList");
    }
}
