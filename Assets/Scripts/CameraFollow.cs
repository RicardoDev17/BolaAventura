using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Referencia al jugador
    public Vector3 offset;    // Desplazamiento de la cámara respecto al jugador

    void Start()
    {
        // Si no has definido un offset en el Inspector, puedes inicializarlo aquí
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        // Hacemos que la cámara siga al jugador con el mismo desplazamiento
        transform.position = player.position + offset;
    }
}
