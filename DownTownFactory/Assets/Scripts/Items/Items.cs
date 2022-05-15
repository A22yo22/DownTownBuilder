using UnityEngine;

[CreateAssetMenu(fileName = "data", menuName = "Items/Items")]
public class Items : ScriptableObject
{
    public int[] placeItem;
    public int[] itemsNeeded;
    public int spawnItemNumber;
    public int timeToWait;
}
