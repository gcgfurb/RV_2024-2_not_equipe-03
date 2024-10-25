using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoPrefabScript : MonoBehaviour
{
    public List<Sprite> setas = new List<Sprite>();

    public SpriteRenderer seta;
    public Direcao dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = Direcao.None;
        OnStateChange();
    }

    public void setDirection(Direcao d)
    {
        dir = d;
        OnStateChange();
    }

    void OnStateChange()
    {
        switch (dir)
        {
            case Direcao.None:
                seta.gameObject.SetActive(false);
                break;
            case Direcao.norte:
                seta.sprite = setas[0];
                break;
            case Direcao.sul:
                seta.sprite = setas[1];
                break;
            case Direcao.leste:
                seta.sprite = setas[3];
                break;
            case Direcao.oeste:
                seta.sprite = setas[4];
                break;
        }
        if (dir != Direcao.None) { seta.gameObject.SetActive(true); }
    }

}
