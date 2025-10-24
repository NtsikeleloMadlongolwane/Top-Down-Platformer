using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float explotionCountDown = 1f;
    public bool buttonPressed = false;
    public GameObject[] explodingObjects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        buttonPressed = true;
    }
    private void Update()
    {
        if (buttonPressed)
        {
            explotionCountDown -= Time.deltaTime;
        }
        if (explotionCountDown < 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        if(explodingObjects != null)
        {
            for (int i = 0; i < explodingObjects.Length; i++)
            {
                Destroy(explodingObjects[i]);
            }
            Debug.Log("Everything has been exploded");
            Destroy(this.gameObject);
        }
    }
}
