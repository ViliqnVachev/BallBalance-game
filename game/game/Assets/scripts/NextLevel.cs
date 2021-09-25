using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            Debug.Log("detected");
            SceneManager.LoadScene("Nextlevel");
            
        }
    }
}
