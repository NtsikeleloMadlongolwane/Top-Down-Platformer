using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public bool isFollowing = true;

    public bool IsTimed = false;
    private int counetr = 0;
    public Transform[] checkpoints; // Assign in Inspector
    public float moveSpeed = 5f;
    public float countdownTime = 3f;

    private int currentCheckpointIndex = 0;
    private bool isMoving = false;
    private bool hasRestarted = false;



    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(countdownTime);
        isMoving = true;
    }

    void Update()
    {
        if (isFollowing)
        {
            transform.position = new Vector3(53.02f, player.position.y, -10f);
        }

        if (!hasRestarted)
        {
            RestartFromFirstCheckpoint();
            hasRestarted = true;
        }

        if (isMoving && currentCheckpointIndex < checkpoints.Length)
        {
            MoveToCheckpoint();
        }

    }

    void MoveToCheckpoint()
    {
        Transform target = checkpoints[currentCheckpointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentCheckpointIndex++;

            if (currentCheckpointIndex >= checkpoints.Length)
            {
                isMoving = false; // Stop at last checkpoint
            }
        }
    }

    // Call this method to reset to the last checkpoint and restart movement
    public void ResetToLastCheckpoint()
    {
        if (currentCheckpointIndex > 0)
        {
            currentCheckpointIndex--; // Go back one step
        }

        transform.position = checkpoints[currentCheckpointIndex].position;
        isMoving = false;
        StartCoroutine(StartCountdown());
    }
    public void RestartFromFirstCheckpoint()
    {
        currentCheckpointIndex = 0;
        transform.position = checkpoints[0].position;
        isMoving = false;
        StartCoroutine(StartCountdown());
    }
}
