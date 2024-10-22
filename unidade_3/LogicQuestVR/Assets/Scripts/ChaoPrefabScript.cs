using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoPrefabScript : MonoBehaviour
{
    public Material grass;
    public Material grassPressed;

    public MeshRenderer _renderer;

    // Start is called before the first frame update
    void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void SetGrass(bool press)
    {
        Debug.Log("Entrei: " + press);
        if (press) { changeGrass(); }
        else { _renderer.materials[0] = grass; }
    }

    private void changeGrass()
    {
        Material[] mat = _renderer.materials;
        mat[0] = grassPressed;

    }
}
