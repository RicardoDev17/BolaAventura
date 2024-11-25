using System.Collections;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float moveSpeed = 10f;  // Velocidad de movimiento horizontal
    public float jumpForce = 10f;  // Fuerza del salto
    public bool isGrounded = true;  // Para saber si el personaje está en el suelo
    public float speedBoostMultiplier = 10f; // Factor de aumento de velocidad
    public float boostDuration = 2f; // Duración del aumento de velocidad en segundos

    private Rigidbody rb;
    private bool isBoosted = false; // Controla si el boost está activo

    void Start()
    {
        // Obtenemos el componente Rigidbody al iniciar el juego
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento horizontal (X) y hacia adelante/atrás (Z)
        float moveInputX = Input.GetAxis("Horizontal"); // A/D o flechas izquierda/derecha
        float moveInputZ = Input.GetAxis("Vertical");   // W/S o flechas arriba/abajo
        Vector3 move = new Vector3(moveInputX, 0, moveInputZ);

        // Aplica la velocidad de movimiento (incluye el boost si está activo)
        float currentSpeed = isBoosted ? moveSpeed * speedBoostMultiplier : moveSpeed;
        rb.velocity = new Vector3(move.x * currentSpeed, rb.velocity.y, move.z * currentSpeed);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;  // El personaje no está en el suelo hasta que aterrice
        }
    }

    // Detectamos si el personaje toca el suelo para permitir otro salto
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isGrounded = true;
        }

        // Detecta colisión con powerUp
        if (collision.gameObject.CompareTag("powerUp"))
        {
            StartCoroutine(ApplySpeedBoost());
            Destroy(collision.gameObject); // Elimina el objeto powerUp tras recogerlo
        }
    }

    private IEnumerator ApplySpeedBoost()
    {
        isBoosted = true; // Activa el estado de aumento de velocidad
        yield return new WaitForSeconds(boostDuration); // Espera el tiempo del boost
        isBoosted = false; // Desactiva el estado de aumento de velocidad
    }
}
