using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject parent;

    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            gameObject.SetActive(false);
            
            AudioSource sound = parent.GetComponent<AudioSource>();
            if (sound != null) sound.Play();

            PlayerBehaviour playerBehaviour = player.GetComponent<PlayerBehaviour>();
            if (playerBehaviour != null)
            {
                playerBehaviour.CollectDocument();

                
                EventManager.TriggerMissionAdvanced();
                Debug.Log("Mission updated via EventManager.");
            }
            else
            {
                Debug.LogError("PlayerBehaviour is not found!");
            }
        }
    }
}