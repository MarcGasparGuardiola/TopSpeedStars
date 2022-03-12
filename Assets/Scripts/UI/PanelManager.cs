using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{

    public GameObject gameModePanel;
    public GameObject raceSelectPanel;
    public GameObject planeSelectPanel;

    void DisableAll()
    {
        gameModePanel.SetActive(false);
        raceSelectPanel.SetActive(false);
        planeSelectPanel.SetActive(false);
    }

    public void ToModeSelect()
    {
        DisableAll();
        gameModePanel.SetActive(true);

    }

    public void ToRaceSelect()
    {
        DisableAll();
        raceSelectPanel.SetActive(true);
    }

    public void ToPlaneSelect()
    {
        DisableAll();
        planeSelectPanel.SetActive(true);
    }
}
