using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fallDie : MonoBehaviour
{
    Scene _scene;
 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            score.lives--;
            SceneManager.LoadScene("GameOver");;
        }
    }
}
