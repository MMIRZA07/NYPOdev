using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gecit : MonoBehaviour
{
    [SerializeField] private int sonrakiBolumIndex; // Hangi sahneye geçileceðini belirtmek için sahne indexi

    private void OnTriggerEnter(Collider other)
    {
        // Eðer "car" tag'ine sahip bir obje collider'a girerse
        if (other.CompareTag("car"))
        {
            // Bir sonraki sahneye geçiþ yap
            SceneManager.LoadScene(sonrakiBolumIndex);
        }
    }
}
