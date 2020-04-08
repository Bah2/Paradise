using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaftBuild : MonoBehaviour
{
    public CanvasFade cgblack;
    public InventoryObject Job;
    public GameObject logs;
    public GameObject mastot;
    public GameObject sail;
    public GameObject vines;

    void Start()
    {
        logs.SetActive(false);
        mastot.SetActive(false);
        sail.SetActive(false);
        vines.SetActive(false);
    }

    
    void OnTriggerEnter()
    {
        if (Job.nuffAxe)
        {
            if (Job.nuffLog)
            {
                logs.SetActive(true);
            }

            if (Job.nuffRisu)
            {
                mastot.SetActive(true);
            }

            if (Job.nuffSkin)
            {
                sail.SetActive(true);
            }

            if (Job.nuffLiaani)
            {
                vines.SetActive(true);
            }

            if (Job.nuffLiaani && Job.nuffLog && Job.nuffSkin && Job.nuffRisu) 
            {
                cgblack.fadeIn(2f);
                StartCoroutine(Wait(3f));
            }

        }
    }

    IEnumerator Wait(float sec) //venaillaan parametrin määräämän ajan ennen menua
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("end_scene", LoadSceneMode.Single);
    }

}


