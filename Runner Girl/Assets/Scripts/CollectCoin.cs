using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] private AudioSource coinSound;
    public int score;
    public TextMeshProUGUI coinText;
    
    
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
            
        }
    }
    public void Addcoin()
    {
        score++;
        coinText.text = "Score: "+score.ToString();
    }
}
