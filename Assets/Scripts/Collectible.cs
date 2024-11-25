using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioSource audioSource;
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.transform.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().AddCollectible();

            Destroy(gameObject);

            audioSource.Play();
        }
    }
}
