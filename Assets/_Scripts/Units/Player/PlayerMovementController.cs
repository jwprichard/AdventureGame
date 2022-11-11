using UnityEngine;
using Assets.Scripts.Utilities;

public class PlayerMovementController : BaseMovementController
{
    private float Horizontal, Vertical;

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform _backpack;

    override public void Move()
    {
        if (Time.time < LockedTill) return;

        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        base.Rigidbody.velocity = new Vector3(Horizontal * Unit.Stats.Speed, Vertical * Unit.Stats.Speed, 0);
    }

    override public void Rotate()
    {

        Quaternion rotation = UtilsClass.LookAt(UtilsClass.GetMouseWorldPosition(), _backpack.position);
        float eulerAngle = rotation.eulerAngles.z;
        _backpack.transform.rotation = rotation;

        //North
        if (eulerAngle < 90 - 45 || eulerAngle > 360 - 45)
        {
            spriteRenderer.sprite = sprites[1];
            return;
        }
        //East
        if (eulerAngle < 180-45)
        {
            spriteRenderer.sprite = sprites[0];
            return;
        }
        //South
        if (eulerAngle < 270-45)
        {
            spriteRenderer.sprite = sprites[2];
            return;
        }
        //West
        if (eulerAngle > 270-45)
        {
            spriteRenderer.sprite = sprites[3];
            return;
        }
    }
}
