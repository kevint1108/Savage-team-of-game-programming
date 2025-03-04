using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Slider armorBar;
    public Text moneyText;
    public Text ammoText;

    private int money = 1000;
    private int ammo = 30;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateHealth(float health)
    {
        healthBar.value = health;
    }

    public void UpdateArmor(float armor)
    {
        armorBar.value = armor;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        moneyText.text = "$" + money.ToString();
    }

    public void UpdateAmmo(int currentAmmo)
    {
        ammo = currentAmmo;
        ammoText.text = ammo.ToString();
    }

    void UpdateUI()
    {
        moneyText.text = "$" + money;
        ammoText.text = ammo.ToString();
    }
}
