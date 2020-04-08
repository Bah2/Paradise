using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    int PalmuNum;
    public GameObject Palmu1;
    public GameObject Palmu2;
    public GameObject Palmu3;
    public GameObject Palmu4;

    // Start is called before the first frame update
    void Start()
    {
        PalmuNum = Random.Range(1, 5);
        
        if (PalmuNum == 1) 
        {
            Destroy(Palmu2);
            Destroy(Palmu3);
            Destroy(Palmu4);
        }

        if (PalmuNum == 2)
        {
            Destroy(Palmu1);
            Destroy(Palmu3);
            Destroy(Palmu4);
        }

        if (PalmuNum == 3)
        {
            Destroy(Palmu2);
            Destroy(Palmu1);
            Destroy(Palmu4);
        }

        if (PalmuNum == 4)
        {
            Destroy(Palmu2);
            Destroy(Palmu3);
            Destroy(Palmu1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
