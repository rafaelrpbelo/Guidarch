using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();
        StoreItem();
    }

    public void StoreItem() {
        if (item == null)
            return;

        Debug.Log("Picking up item " + item.name);
        Destroy(gameObject);
    }
}
