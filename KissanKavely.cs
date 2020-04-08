using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KissanKavely : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        anim.speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("TigerAnim");
    }
}