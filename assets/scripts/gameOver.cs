using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public int index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("engel"))
        {
            SceneManager.LoadScene(index);
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(index);
    }
}
