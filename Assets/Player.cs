using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using TMPro;

public class Player : NetworkBehaviour
{
    public TMP_Text playerNameText;
    public string playerName;
    public MeshRenderer playerModel;

    void Start()
    {
        
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
        playerNameText.text = name;
        playerModel.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
