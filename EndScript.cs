using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    
    void Start()
    {
        transform.Find("perse").GetComponent<CanvasFade>().fadeIn(2f);
    }

    public void PlayAgain() 
    {
        SceneManager.LoadScene("start_menu");
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
