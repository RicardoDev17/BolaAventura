using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public AudioSource audioSource;

    public TMP_Text collectiblesNumberText;

    private int collectiblesNumber;

    public TMP_Text totalCollectiblesNumberText;

    private int totalCollectiblesNumber;

    void Start()
    {
        totalCollectiblesNumber = transform.childCount;
        totalCollectiblesNumberText.text = totalCollectiblesNumber.ToString();
    }

    void Update()
    {
        if (transform.childCount <= 0)
        {
            Debug.Log("Ganaste");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void AddCollectible()
    {
        collectiblesNumber++;

        collectiblesNumberText.text = collectiblesNumber.ToString();
        
        audioSource.Play();
    }
}
