using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kittyGo,parentGo; //kissan ja parentin gameobjectit
    public Transform parent, kitty; //kissan ja parentin transformit
    public MeshRenderer skinRender; //skinin renderer
    public BoxCollider skinCollider; //skinin collider

    void Start()
    {
        //haetaan skinin renderer ja collider
        skinRender = this.GetComponent<MeshRenderer>(); 
        skinCollider = this.GetComponent<BoxCollider>(); 

        //Haetaan parentin transform, ja sitä kautta parentin gameobject
        parent = this.transform.parent;
        parentGo = parent.gameObject; 

        //Haetaan kissan transform parentin childeista (kissa on indeksissä ekana), ja transformin kautta kissan gameobject
        kitty = parent.GetChild(0); //
        kittyGo = kitty.gameObject;

        //Sidotaan skinin positio kissan positioon
        transform.position = kitty.position;

        //poistetaan renderöinti ja collideri
        skinRender.enabled = false;
        skinCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(kittyGo)
         transform.position = kitty.position; //Jos kissan gameobject on olemassa, kuljetetaan skiniä sen mukana
        else //mikäli sitä ei ole (l. kisu kuoli ja gameobject tuhottiin
        {
            //laitetaan renderöinti ja collideri päälle
            skinRender.enabled = true; 
            skinCollider.enabled = true;
        }
    }
}
