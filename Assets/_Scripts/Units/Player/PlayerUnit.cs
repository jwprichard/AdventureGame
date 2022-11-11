using Assets.Units;
using UnityEngine;
using Assets.Combat;

public class PlayerUnit : UnitBase
{
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private PlayerCombatController playerCombatController;
    public Room currentRoom;
}
