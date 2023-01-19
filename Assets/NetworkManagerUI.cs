using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private RelayManager relayManager;
    [SerializeField] private TMP_InputField joinCodeInput;
    [SerializeField] private TMP_Text joinCodeText;

    public string joinCode = "";

    private void Awake()
    {
        joinCodeText.gameObject.SetActive(false);
        hostBtn.onClick.AddListener(() =>
        {
            relayManager.CreateRelay();
            joinCodeText.gameObject.SetActive(true);
            StartCoroutine(SetJoinCode());
        });
        clientBtn.onClick.AddListener(() =>
        {
            relayManager.JoinRelay(joinCodeInput.text);
        });
    }

    IEnumerator SetJoinCode()
    {
        yield return new WaitForSeconds(.5f);
        while(joinCode == "")
        {
            yield return new WaitForSeconds(.1f);
        }
        joinCodeText.text += " " + joinCode;
    }
}
