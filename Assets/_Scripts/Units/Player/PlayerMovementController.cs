using UnityEngine;
using Assets.Scripts.Utilities;

public class PlayerMovementController : MonoBehaviour
{
    private float Horizontal, Vertical;
#pragma warning disable CS0108 
    private Rigidbody2D rigidbody;
#pragma warning restore CS0108
    private float Speed = 5f;

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform _backpack;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Rotate();
        //gameObject.transform.rotation = UtilsClass.LookAt(UtilsClass.GetMouseWorldPosition(), transform.position);
    }

    private void Move()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        rigidbody.velocity = new Vector3(Horizontal * Speed, Vertical * Speed, 0);
    }

    private void Rotate()
    {

        Quaternion rotation = UtilsClass.LookAt(UtilsClass.GetMouseWorldPosition(), _backpack.position);
        float eulerAngle = rotation.eulerAngles.z;
        Debug.Log(eulerAngle);
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
