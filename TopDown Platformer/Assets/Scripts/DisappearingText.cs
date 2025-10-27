using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TMPro;

public class DisappearingText : MonoBehaviour
{
    public GameObject highlightBar;
    public GameObject[] Platforms;
    public GameObject textIsGone;
    public float deletingtImer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player landed");
            StartCoroutine(DeleteText());
        }
    }
    public IEnumerator DeleteText()
    {
        yield return new WaitForSeconds(1f);
        highlightBar.SetActive(true);
        yield return new WaitForSeconds(deletingtImer - 1f);
        highlightBar.SetActive(false);

        if(Platforms.Length != 0)
        {
            for (int i = 0; i < Platforms.Length; i++)
            {
                Platforms[i].SetActive(false);
            }
        }
        Instantiate(textIsGone, new Vector3(53.02f, this.gameObject.transform.position.y, 0f), Quaternion.identity);
        Destroy(gameObject);
    }

}
