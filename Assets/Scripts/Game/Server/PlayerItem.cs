using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    public Text playerName;
    public Text planeName;
    public Image background;
    public Color highlight;
    public GameObject check;

    Player player;

    private void Start()
    {
        // background = GetComponent<Image>();
    }

    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(player);
    }

    public void HighlightLocalPlayer()
    {
        background.color = highlight;
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (targetPlayer == player)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    void UpdatePlayerItem(Player player)
    {
        if (player.CustomProperties.ContainsKey("characterName"))
        {
            planeName.text = ( player.CustomProperties["characterName"].ToString());
        }
        if (player.CustomProperties.ContainsKey("isReady"))
        {
            // TODO set checkmark
            if ((bool)player.CustomProperties["isReady"])
            {
                check.SetActive(true);
            }
            
        }

    }
}
