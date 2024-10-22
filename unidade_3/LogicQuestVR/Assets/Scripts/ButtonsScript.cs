using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] private PainelScript _painel;
    [SerializeField] private buttonValue value;

    private void Start()
    {
        if (_painel == null)
            FindAnyObjectByType<PainelScript>();
        GetComponent<Button>().onClick.AddListener(clicked);
    }

    private void clicked()
    {
        _painel.sendClick(value);
    }
}
