using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLog : MonoBehaviour
{

    int RanLog;
    public GameObject LogGroup1;
    public GameObject LogGroup2;
    public GameObject LogGroup3;
    public GameObject LogGroup4;
    public GameObject LogGroup5;
    public GameObject LogGroup6;
    public GameObject LogGroup7;
    public GameObject LogGroup8;

    // Start is called before the first frame update
    void Start()
    {
        RanLog = Random.Range(1, 9);

        if (RanLog == 1)
        {
            Destroy(LogGroup2);
            Destroy(LogGroup3);
            Destroy(LogGroup4);
            Destroy(LogGroup5);
            Destroy(LogGroup6);
            Destroy(LogGroup7);
            Destroy(LogGroup8);

        }

        if (RanLog == 2)
        {
            Destroy(LogGroup1);
            Destroy(LogGroup3);
            Destroy(LogGroup4);
            Destroy(LogGroup5);
            Destroy(LogGroup6);
            Destroy(LogGroup7);
            Destroy(LogGroup8);

        }

        if (RanLog == 3)
        {
            Destroy(LogGroup2);
            Destroy(LogGroup1);
            Destroy(LogGroup4);
            Destroy(LogGroup5);
            Destroy(LogGroup6);
            Destroy(LogGroup7);
            Destroy(LogGroup8);

        }

        if (RanLog == 4)
        {
            Destroy(LogGroup2);
            Destroy(LogGroup3);
            Destroy(LogGroup1);
            Destroy(LogGroup5);
            Destroy(LogGroup6);
            Destroy(LogGroup7);
            Destroy(LogGroup8);

        }

        if (RanLog == 5)
        {
            Destroy(LogGroup2);
            Destroy(LogGroup3);
            Destroy(LogGroup4);
            Destroy(LogGroup1);
            Destroy(LogGroup6);
            Destroy(LogGroup7);
            Destroy(LogGroup8);

        }

        if (RanLog == 6)
        {
            Destroy(LogGroup2);
            Destroy(LogGroup3);
            Destroy(LogGroup4);
            Destroy(LogGroup5);
            Destroy(LogGroup1);
            Destroy(LogGroup7);
            Destroy(LogGroup8);

        }

        if (RanLog == 7)
        {
            Destroy(LogGroup2);
            Destroy(LogGroup3);
            Destroy(LogGroup4);
            Destroy(LogGroup5);
            Destroy(LogGroup6);
            Destroy(LogGroup1);
            Destroy(LogGroup8);

        }

        if (RanLog == 8)
        {
            Destroy(LogGroup2);
            Destroy(LogGroup3);
            Destroy(LogGroup4);
            Destroy(LogGroup5);
            Destroy(LogGroup6);
            Destroy(LogGroup7);
            Destroy(LogGroup1);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
