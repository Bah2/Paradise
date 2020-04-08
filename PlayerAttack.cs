using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject[] enemy; //taulukko vihuista
    public EHealth[] enemyHealth; //taulukko vihujen hp:sta
    public bool attack = false, cooldown = false; //hyökkäys ja cooldown flagit
    public float timer, time = 0.5f; //timeri ja hyökkäysten väli

    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("kisu"); //haetaan taulukkoon kaikki tagilla "kisu" varustetut
        enemyHealth = new EHealth[enemy.Length]; //Vihujen hp-taulukon kooksi sama kuin vihutaulukolla
        for (int i = 0; i < enemy.Length; i++)
        {
            enemyHealth[i] = enemy[i].GetComponent<EHealth>(); //haetaan jokaiselta taulukon vihulta EHealthin componentit vastaavaan kohtaan hp-taulukkoa
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown) //jos venaillaan
        {
            timer += Time.deltaTime; //kasvatetaan laskuria kunnes tulee täyteen, ja palautetaan hyökkäysmahdollisuus
            if (timer > time)
            {
                cooldown = false;
            }
        }

        if (Input.GetMouseButtonDown(0) && !cooldown) //jos LMB ja ei olla tauolla
        {

            //play da anim
            attack = true;
        }




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("kisu")) //jos törmättiin kissaan
        {
            Debug.Log("osukisu");
            for (int i = 0; i < enemy.Length; i++) //luupataan taulukko läpi
            {
                if (collision.gameObject == enemy[i] && attack) //ja suoritetaan operaatiot oikeelle vihulle
                {
                    Debug.Log("osu");
                    enemyHealth[i].takeDamage(50);
                    attack = false;
                    cooldown = true;
                    timer = 0;
                }
            }
        }
    }
}
