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
    public int maxScore = 20;
    public Animator animator;
    public GameObject player;
    
    
    
    private void Start()
    {
        coinSound = GetComponent<AudioSource>();
        animator = player.GetComponentInChildren<Animator>();
        
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
            if (score>maxScore)
            {
              animator.SetBool("win",true);
                    
            }
            else 
            {
               animator.SetBool("lose",true);
            }
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
