using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Referencia al jugador
    public Vector3 offset;    // Desplazamiento de la c�mara respecto al jugador

    void Start()
    {
        // Si no has definido un offset en el Inspector, puedes inicializarlo aqu�
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        // Hacemos que la c�mara siga al jugador con el mismo desplazamiento
        transform.position = player.position + offset;
    }
}
