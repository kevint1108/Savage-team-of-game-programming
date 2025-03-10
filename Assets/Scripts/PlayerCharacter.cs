using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private int money;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        money = 0;
    }

    // Method to call to deal damage to the player
    public void Hurt(int damage)
    {
        health -= damage;
        Messenger.Broadcast(GameEvent.HEALTH);
        Debug.Log($"Health: {health}");

        //Exits game if health at zero.
        if (health <= 0)
        {
            Debug.Log("YOU LOSE!");
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    //Gains money. Print money amount to the console.
    public void AddMoney(int amount){
        money += amount;
    }
}
