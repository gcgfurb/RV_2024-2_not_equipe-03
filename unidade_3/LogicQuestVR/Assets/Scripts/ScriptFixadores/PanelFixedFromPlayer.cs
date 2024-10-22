using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFixedFromPlayer : MonoBehaviour
{
    public Transform playerCamera; // Referência à câmera do jogador

    void LateUpdate()
    {
        // Mantém a posição do canvas na frente da câmera
        transform.position = playerCamera.position + playerCamera.forward * 0.05f;

        // Trava a rotação do canvas para que ele sempre fique "reto"
        transform.rotation = Quaternion.Euler(0, playerCamera.eulerAngles.y, 0);
    }
}

