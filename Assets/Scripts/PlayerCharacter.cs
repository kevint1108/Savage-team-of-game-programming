using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private int armor;
    private int money;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        armor = 0;
        money = 0;
    }

    // Method to call to deal damage to the player
    public void Hurt(int damage)
    {
        if (armor > 0){
            armor -= damage;
            Messenger.Broadcast(GameEvent.LOSEARMOR);
            Debug.Log($"Armor: {armor}");
        }
        else{
            health -= damage;
            Messenger.Broadcast(GameEvent.LOSEHEALTH);
            Debug.Log($"Health: {health}");
        }

        //Exits game if health at zero.
        if (health <= 0)
        {
            Debug.Log("YOU LOSE!");
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    
     public bool Heal(int amount){
        if (health < 5){
            health += amount;
            Messenger.Broadcast(GameEvent.GAINHEALTH);
            Debug.Log($"Health: {health}");
            return true;
        }
        else{
            return false;
        }
     }
    //Gains money. Print money amount to the console.
    public void AddMoney(int amount){
        money += amount;
        Debug.Log($"Money: {money}");
    }

     public void Armor(int amount){
        armor += amount;
        Messenger.Broadcast(GameEvent.GAINARMOR);
        Debug.Log($"Armor: {armor}");
    }
}
