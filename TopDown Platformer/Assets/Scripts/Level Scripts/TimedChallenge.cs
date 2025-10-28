using UnityEngine;
using System.Collections;

public class TimedChallenge : MonoBehaviour
{

    /*public Transform[] checkpoints; // Set these in the Inspector
    public float moveSpeed = 5f;
    public float countdownTime = 3f;

    private int currentCheckpointIndex = 0;
    private bool isMoving = false;
    public void OnEnable()
    {
        //transform.position = checkpoints[0].position;
        //StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(countdownTime);
        isMoving = true;
    }

    void Update()
    {
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
        }
    }

    public void ResetToCheckpoint(int index)
    {
        if (index >= 0 && index < checkpoints.Length)
        {
            currentCheckpointIndex = index;
            transform.position = checkpoints[index].position;
            isMoving = false;
            StartCoroutine(StartCountdown());
        }
    }
    */
}
