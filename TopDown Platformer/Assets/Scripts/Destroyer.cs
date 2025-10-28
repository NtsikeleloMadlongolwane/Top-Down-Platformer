using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float timer = 2.0f;
    private void Start()
    {
        Destroy(this.gameObject, timer);
    }
}
