using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPanelCommand : MonoBehaviour
{
    private string nome;
    [SerializeField] private PainelScript script;
    [SerializeField] private TextMeshProUGUI _name;

    public void setPos(string n, PainelScript s, bool toggle)
    {
        nome = n;
        _name.text = nome;
        script = s;
        this.GetComponent<Button>().interactable = toggle;
    }

    public void ExcluirBotao()
    {
        script.Excluir(this.gameObject);
    }
}
