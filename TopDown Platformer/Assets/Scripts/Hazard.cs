using UnityEngine;

public class Hazard : MonoBehaviour
{
    private PlayerMovemenr playerScript;
    private LevelManager level;

    private void Start()
    {
        level = FindAnyObjectByType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();

        playerScript.HazardRespawn();
    }
}
