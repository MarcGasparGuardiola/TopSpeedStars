using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectManager : MonoBehaviour
{
    public PlaneSelection planeSelection;
    public Transform planeDisplay;
    public Text nameDisplay;
    public int id = 0;
    public float scale = 5f;

   

    public void ShowPlane() 
    {
        HidePlane();
        
        GameObject prefab = Resources.Load(planeSelection.characters[id].route) as GameObject;
        GameObject instance = Instantiate(prefab, planeDisplay);
        instance.transform.localScale = Vector3.one * scale; 
        planeSelection.OnPlaneSelect(id); 
        nameDisplay.text = planeSelection.characters[id].characterName;
    }

    public void HidePlane() 
    {
        try
        {
            Destroy(planeDisplay.GetChild(0).gameObject);
        }
        catch{ }
        
    }

    public void OnLeftClicked() 
    {
        id--;
        if (id < 0)
        {
            id = planeSelection.characters.Length - 1;
        }
        ShowPlane();
    }
    public void OnRightClicked() 
    {
        id++;
        if (id > planeSelection.characters.Length - 1)
        {
            id = 0;
        }
        ShowPlane();
    }
    public void OnBackClicked()
    {
        HidePlane();
        id = 0;
        planeSelection.planeId = id;
    }
}
