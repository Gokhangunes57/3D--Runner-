using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] private AudioSource coinSound;
    public int score;
    public TextMeshProUGUI coinText;
    public PlayerController playerController;
    
    
    private void Start()
    {
        coinSound = GetComponent<AudioSource>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Addcoin();
            coinSound.Play();
            Destroy(other.gameObject);
            
        }else if (other.CompareTag("end"))
        {
            Debug.Log("tebriks");
            playerController.runningSpeed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("collision"))
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Addcoin()
    {
        score++;
        coinText.text = "Score: "+score.ToString();
    }
}
