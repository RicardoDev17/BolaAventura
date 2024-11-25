using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class Enemigo : MonoBehaviour

{

    private NavMeshAgent navMeshAgent;
    private Transform playerTransform;
    public AudioSource audioSource;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        playerTransform = FindAnyObjectByType<Jugador>().transform;
    }


    void Update()
    {
        
        navMeshAgent.destination = playerTransform.position;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            audioSource.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            

        }
    }
}
