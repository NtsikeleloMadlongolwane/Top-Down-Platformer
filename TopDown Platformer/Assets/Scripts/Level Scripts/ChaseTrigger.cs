using UnityEngine;

public class ChaseTrigger : MonoBehaviour
{
    public LevelManager level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            level.Timed();
        }
    }
}
