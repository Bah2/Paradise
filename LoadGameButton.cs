using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadGameButton : MonoBehaviour
{
    public void loadgame() 
    {
        SceneManager.LoadScene(1);
    }

}
