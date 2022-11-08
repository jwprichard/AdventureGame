using UnityEngine;
using Assets.Scripts.Utilities;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    public void Update()
    {
        Vector2 pos = Player.transform.position;
        transform.position = new(pos.x, pos.y, -10);
    }
}
