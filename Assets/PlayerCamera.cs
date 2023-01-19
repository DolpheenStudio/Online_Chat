using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerCamera : NetworkBehaviour
{
    void Start()
    {
        if (!IsOwner)
        {
            gameObject.SetActive(false);
        }
    }
}
