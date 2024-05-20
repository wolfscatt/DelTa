using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDie : MonoBehaviour
{
    Scene _scene;
 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Score.lives--;
            if(Score.lives == 0)
                SceneManager.LoadScene("GameOver");
            else
            {
                _scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(_scene.name);
            }
        }
    }
}
