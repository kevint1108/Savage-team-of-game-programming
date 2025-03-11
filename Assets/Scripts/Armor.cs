using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    //Makes Armor.
    private int armorAmount;
    // Start is called before the first frame update
    void Start()
    {
        //Makes armor amount 5.
        armorAmount = 5;
    }

    //Will trigger if the player touchs this object.
    void OnTriggerEnter(Collider other){
        //Calls the PlayerCharacter script
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();

        //Detects if player is touching the object.
        if (player != null){
            //Gives the player the armor.
            player.Armor(armorAmount);
            //Gets armor and gains the armor then it prints this message.
            Debug.Log("Gained armor!");
            //Destroys object/armor when picked up.
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
