using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameUIManager uiManager = FindObjectOfType<GameUIManager>();
            uiManager.AddItemToInventory(itemName);
            Destroy(gameObject);
        }
    }
}
