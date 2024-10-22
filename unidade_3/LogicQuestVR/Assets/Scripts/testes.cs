using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testes : MonoBehaviour
{
    private Coroutine coroutine;
    // Start is called before the first frame update
    void OnEnable()
    {
        coroutine =StartCoroutine(enumerator());
    }

    IEnumerator enumerator()
    {
        while(true)
        {
            //andar
            yield return new WaitForSeconds(0.5f);
            yield return null;
        }
    }

    private void OnDisable()
    {
        StopCoroutine(coroutine);
    }
}
