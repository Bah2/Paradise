using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject[] enemy;
    public EHealth[] enemyHealth;
    public bool attack = false, cooldown = false;
    public float timer, time = 0.5f;

    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("kisu");
        enemyHealth = new EHealth[enemy.Length];
        for (int i = 0; i < enemy.Length; i++)
        {
            enemyHealth[i] = enemy[i].GetComponent<EHealth>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown)
        {
            timer += Time.deltaTime;
            if (timer > time)
            {
                cooldown = false;
            }
        }

        if (Input.GetKey(KeyCode.Space) && !cooldown)
        {

            //play da anim
            attack = true;
        }



        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("kisu")) //jos törmättiin kissaan
        {
            for (int i = 0; i < enemy.Length; i++) //luupataan taulukko läpi
            {
                if (collision.gameObject == enemy[i] && attack) //ja suoritetaan operaatiot oikeelle vihulle
                {
                    enemyHealth[i].takeDamage(50);
                    attack = false;
                    cooldown = true;
                    timer = 0;
                }
            }
        }
    }
}
