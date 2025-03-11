using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : MonoBehaviour
{
    //Makes money bag amount 10000.
    private int moneyAmount = 10000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Will trigger if the player touchs this object.
    public void OnTriggerEnter(Collider other){
        //Calls the PlayerCharacter script
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();

        //Detects if player is touching the object.
        if (player != null){
            //Player earns the amount of money in the bag.
            player.AddMoney(moneyAmount);
            //Destroys object/money bag when picked up.
            Destroy(gameObject);
            Messenger.Broadcast(GameEvent.MONEY_PICKUP);
            //Gets money it prints this message.
            Debug.Log("Gained 10000$!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
