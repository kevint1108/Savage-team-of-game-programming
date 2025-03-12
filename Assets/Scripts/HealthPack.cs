using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip healthPackSound;

    //Makes health pack.
    private int healAmount;
    // Start is called before the first frame update
    void Start()
    {
        //Makes health pack amount 1.
        healAmount = 1;
    }

    //Will trigger if the player touchs this object.
    void OnTriggerEnter(Collider other){
        //Calls the PlayerCharacter script
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();

        //Detects if player is touching the object.
        if (player != null){
            //Heals the player for the heal amount.
            if (player.Heal(healAmount) != false){
                //Gets health pack and gains health then it prints this message.
                Debug.Log("Gained 1 health!");
                //Destroys object/health pack when picked up.
                Destroy(gameObject);
                soundSource.PlayOneShot(healthPackSound);
            }
            else{
                Debug.Log("Max Health");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}