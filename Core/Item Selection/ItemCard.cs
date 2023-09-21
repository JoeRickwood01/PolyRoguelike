using UnityEngine;
using UnityEngine.UI;

public class ItemCard : MonoBehaviour
{
    private Item item;

    [SerializeField] private Image cover;
    [SerializeField] private Text nameText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Image iconImage;

    public void SetListener()
    {
        GetComponent<Button>().onClick.AddListener(() => InventoryManager.Instance.AddItemToInventory(item));
        GetComponent<Button>().onClick.AddListener(() => Level.Instance.CloseItemSelectionPanel());
    }

    public void SetItem(Item add)
    {
        item = add;

        nameText.text = item.name;
        descriptionText.text = item.description;
        iconImage.sprite = item.icon;
        cover.color = InventoryManager.Instance.rarityColors[(int)item.rarity];
    }
}
