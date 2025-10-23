using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    private void Start()
    {
    }
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10f);
    }
}
