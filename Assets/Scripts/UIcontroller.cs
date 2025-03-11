using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] TMP_Text moneyLabel;
    [SerializeField] TMP_Text healthLabel;
    [SerializeField] TMP_Text armorLabel;
    [SerializeField] SettingsPopup settingsPopup;

    private int _score;
    private int money;
    private int health;
    private int armor;

    private void OnEnable()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.AddListener(GameEvent.MONEY_PICKUP, MoneyPickup);
        Messenger.AddListener(GameEvent.LOSEHEALTH, LoseHealth);
        Messenger.AddListener(GameEvent.GAINHEALTH, GainHealth);
        Messenger.AddListener(GameEvent.GAINARMOR, GainArmor);
        Messenger.AddListener(GameEvent.LOSEARMOR, LoseArmor);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.RemoveListener(GameEvent.MONEY_PICKUP, MoneyPickup);
        Messenger.RemoveListener(GameEvent.LOSEHEALTH, LoseHealth);
        Messenger.RemoveListener(GameEvent.GAINHEALTH, GainHealth);
        Messenger.RemoveListener(GameEvent.GAINARMOR, GainArmor);
        Messenger.RemoveListener(GameEvent.LOSEARMOR, LoseArmor);
    }

    private void OnEnemyHit()
    {
        _score -= 1;
        scoreLabel.text = "Enemies left: " + _score.ToString();
    }

    private void MoneyPickup()
    {
        money += 10000;
        moneyLabel.text = "$" + money.ToString();
    }

    private void LoseHealth()
    {
        if (armor == 0){
        health -= 1;
        healthLabel.text = "HP: " + health.ToString();
        }
    }

    private void GainHealth()
    {
        if (health < 5){
            health += 1;
            healthLabel.text = "HP: " + health.ToString();
        }
    }
    private void GainArmor()
    {
        armor += 5;
        armorLabel.text = "Armor: " + armor.ToString();
    }
    private void LoseArmor()
    {
        if (armor > 0){
            armor -= 1;
            armorLabel.text = "Armor: " + armor.ToString();
        }
    }

    private void Start()
    {
        _score = 10;
        scoreLabel.text = "Enemies left: " +  _score.ToString();

        money = 0;
        moneyLabel.text = "$" + money.ToString();

        health = 5;
        healthLabel.text = "HP: " + health.ToString();

        armor = 0;
        armorLabel.text = "Armor: " + armor.ToString();

        settingsPopup.Close();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreLabel.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings()
    {
        // Debug.Log("Opening settings...");
        settingsPopup.Open();
    }
}
