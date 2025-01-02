using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gecit : MonoBehaviour
{
    [SerializeField] private int sonrakiBolumIndex; // Hangi sahneye ge�ilece�ini belirtmek i�in sahne indexi

    private void OnTriggerEnter(Collider other)
    {
        // E�er "car" tag'ine sahip bir obje collider'a girerse
        if (other.CompareTag("car"))
        {
            // Bir sonraki sahneye ge�i� yap
            SceneManager.LoadScene(sonrakiBolumIndex);
        }
    }
}
