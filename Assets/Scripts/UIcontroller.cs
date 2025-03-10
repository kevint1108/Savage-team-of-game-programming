using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] TMP_Text moneyLabel;
    [SerializeField] TMP_Text healthLabel;
    [SerializeField] SettingsPopup settingsPopup;

    private int _score;
    private int money;
    private int health;

    private void OnEnable()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.AddListener(GameEvent.MONEY_PICKUP, MoneyPickup);
        Messenger.AddListener(GameEvent.HEALTH, Health);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.RemoveListener(GameEvent.MONEY_PICKUP, MoneyPickup);
        Messenger.AddListener(GameEvent.HEALTH, Health);
    }

    private void OnEnemyHit()
    {
        _score -= 1;
        scoreLabel.text = "Enemies left: " + _score.ToString();
    }

    private void MoneyPickup()
    {
        money += 50000;
        moneyLabel.text = "$" + money.ToString();
    }

    private void Health()
    {
        health -= 1;
        healthLabel.text = "HP: " + health.ToString();
    }

    private void Start()
    {
        _score = 7;
        scoreLabel.text = "Enemies left: " +  _score.ToString();

        money = 0;
        moneyLabel.text = "$" + money.ToString();

        health = 5;
        healthLabel.text = "HP: " + health.ToString();

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
