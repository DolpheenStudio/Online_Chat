using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NickInput : NetworkBehaviour
{
    [SerializeField] private Button nickBtn;
    public Player player;
    public TMP_InputField nickInput;
    public ConnectedPlayers connectedPlayers;

    void Start()
    {
        connectedPlayers = FindObjectOfType<ConnectedPlayers>();

        nickInput = GetComponent<TMP_InputField>();
        nickBtn.interactable = false;
        nickBtn.onClick.AddListener(() =>
        {
            player.SetPlayerName(nickInput.text);
            connectedPlayers.AddPlayerServerRpc(nickInput.text);
            gameObject.SetActive(false);
        });
    } 

    public void ValidateNameLenght()
    {
        if(nickInput.text.Length <= 3)
        {
            nickBtn.interactable = false;
        }
        else
        {
            nickBtn.interactable = true;
        }
    }
}
