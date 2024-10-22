using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainelScript : MonoBehaviour
{
    [SerializeField] List<buttonValue> values = new List<buttonValue>();
    [SerializeField] private List<GameObject> buttonsPanel = new List<GameObject>();
    [SerializeField] private GameObject _content;
    [SerializeField] private GameObject _buttonContentPrefab;
    [SerializeField] private Toggle toggle;
    [SerializeField] private PlayerMovimentForCam _playerMoviment;
    private void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleChange);
    }
    public void sendClick(buttonValue value)
    {
        values.Add(value);
        GameObject b = Instantiate(_buttonContentPrefab, _content.transform);
        buttonsPanel.Add(b);
        b.GetComponent<ButtonPanelCommand>().setPos(value.ToString(), this, toggle.isOn);
    }

    public void Excluir(GameObject g)
    {
        buttonsPanel.Remove(g);
    }

    public void OnToggleChange(bool value)
    {
        Debug.Log(toggle.isOn);
        AtivarBotoes(value);
    }

    public void AtivarBotoes(bool value)
    {
        foreach (GameObject b in buttonsPanel)
        {
            b.GetComponent<Button>().interactable = value;
            buttonsPanel = new List<GameObject>();
        }
    }

    public void IniciarAndar()
    {
        toggle.isOn = false;
        toggle.interactable = false;
        _playerMoviment.Andar(values);
    }

    public void restartAll()
    {
        values = new List<buttonValue>();
        buttonsPanel = new List<GameObject>();
        foreach (Transform child in _content.transform)
        {
            Destroy(child.gameObject);
        }

    }
}

public enum buttonValue
{
    cima,
    baixo,
    esquerda,
    direita
}
