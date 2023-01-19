using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public string playerName;
    void Start()
    {

    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }
}
