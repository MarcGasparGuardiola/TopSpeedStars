using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerItem : MonoBehaviour
{
    public Text playerName;
    public Image background;
    public Color highlight;

    private void Start()
    {
        // background = GetComponent<Image>();
    }

    public void SetPlayerInfo(Player _player)
    {
        Debug.Log(_player.NickName);
        playerName.text = _player.NickName;
    }

    public void HighlightLocalPlayer()
    {
        background.color = highlight;
    }
}
