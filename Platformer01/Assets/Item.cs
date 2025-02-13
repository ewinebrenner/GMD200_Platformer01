using UnityEngine;

[CreateAssetMenu(menuName = "Platformer/Item")]
public class Item : ScriptableObject
{
    public string name;
    public enum Rarity
    {
        Common,
        Rare,
        SuperRare,
        Legendary
    }
    public Rarity rarity;
    public int value;

    [SerializeField] private int damage;
    public int Damage => damage;
    [SerializeField] private int heal;
    public int Heal => heal;

}