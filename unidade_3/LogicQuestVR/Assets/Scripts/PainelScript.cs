using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainelScript : MonoBehaviour
{
    [SerializeField] private PlayerMovimentForCam _playerMoviment;
    private Dictionary<ChaoPrefabScript, buttonValue> _buttonValues = new Dictionary<ChaoPrefabScript, buttonValue>();

    public void sendClick(ChaoPrefabScript ob, buttonValue value)
    {
        _buttonValues.Add(ob, value);
        
    }
     
}

public enum buttonValue
{
    cima,
    baixo,
    esquerda,
    direita
}
