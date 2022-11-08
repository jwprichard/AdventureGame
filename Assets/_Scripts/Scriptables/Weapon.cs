using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;
    public int damage;

    public Sprite[] sprites;
    public string animContName;
}
