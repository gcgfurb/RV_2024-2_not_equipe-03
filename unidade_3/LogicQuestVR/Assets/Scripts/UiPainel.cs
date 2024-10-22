using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPainel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("Botão X do controle esquerdo foi clicado!");
            _panel.SetActive(!_panel.activeInHierarchy);
        }
    }
}
