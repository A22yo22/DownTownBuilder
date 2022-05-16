using UnityEngine;

[CreateAssetMenu(fileName = "data", menuName = "Items/Items")]
public class Items : ScriptableObject
{
    //the itemplces in the spawner it needs
    //to craft something
    public int[] placeItem;

    //the items the object needs
    public int[] itemsNeeded;

    //nummber of the object to spawn it
    public int spawnItemNumber;

    //time craft the item
    public int timeToWait;
}
