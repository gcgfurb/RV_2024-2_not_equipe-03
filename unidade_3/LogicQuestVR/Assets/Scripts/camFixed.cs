using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camFixed : MonoBehaviour
{
    public Transform cameraAnchor;

    void LateUpdate()
    {
        transform.position = cameraAnchor.position;
    }
}
