using Assets.Units;
using UnityEngine;

public class Player : UnitBase
{
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private PlayerCombatController playerCombatController;

}
