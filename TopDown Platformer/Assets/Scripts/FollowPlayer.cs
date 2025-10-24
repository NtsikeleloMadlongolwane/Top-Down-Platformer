using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = new Vector3(24.7f, player.position.y, -10f);
    }
}
