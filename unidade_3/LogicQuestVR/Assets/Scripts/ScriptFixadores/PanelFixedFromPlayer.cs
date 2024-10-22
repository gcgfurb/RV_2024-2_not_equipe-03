using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFixedFromPlayer : MonoBehaviour
{
    public Transform playerCamera; // Refer�ncia � c�mera do jogador

    void LateUpdate()
    {
        // Mant�m a posi��o do canvas na frente da c�mera
        transform.position = playerCamera.position + playerCamera.forward * 0.05f;

        // Trava a rota��o do canvas para que ele sempre fique "reto"
        transform.rotation = Quaternion.Euler(0, playerCamera.eulerAngles.y, 0);
    }
}

