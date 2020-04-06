using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int state = 0; //0 = idle, 1 = Aggressive, 2 = Attack, 3 = Cooldown
    public float speed, idleSpeed = 1, chaseSpeed=3, idleTurn, turnSpeed=5;
    public float distance, x, y, z, targetX, targetY, targetZ, timer, timeLimit;
    public float detectRadius=7.5f, attackDist=2; //havainnointi- ja hyökkäysetäisyys
    private float attackTimer, attackTime = 2;
    private float cooldownSpeed=0.2f; //hitaampi vauhti hyökkäyksen jälkeen
    bool cooldown=false;
    bool attack = false;
       
    public Vector3 targetDir; //Kohdepiste Z,Y,Z
    public Quaternion facing; //Rintamasuunta

    //kentän koko ei oikein toimi interceptauksen kanssa
    /*public int intel; //Vitun tyhmä mirri<25    
    public Vector3 targetVelocity = new Vector3();
    public Vector3 deltaVel = new Vector3();
    public Vector3 deltaPos = new Vector3();
    public Vector3 velocity = new Vector3(), interceptTarget;
    public float closeTime;*/

    public GameObject target; //Pelaajan viittaukset
    PlayerHealth Player;
    
    KissanKavely anim; //viittaus omaan animaatioon

    void Start()
    {
        anim = this.GetComponent<KissanKavely>();

        target = GameObject.FindGameObjectWithTag("Player");
        Player=target.GetComponent<PlayerHealth>();
               
        timeLimit = Random.Range(1, 5); //arvotaan kulkuaika
        float startRot = Random.Range(0, 360) - 180;  //arvotaan joku kulkusuunta      
        transform.Rotate(Vector3.up * startRot); //käännetään se sinne
        
        
    }

    // Update is called once per frame,
    void Update()
    {
        
        distance = GetDistance(target); //haetaan etäisyys
        
        if (distance > detectRadius) //jos ei havaintosäteen sisällä
            Player.safe = true; //Pelaaja on turvassa ja voi regeneroida
        else
            Player.safe = false;

        if (!cooldown) //jos ei olla hyökätty
        {            
            if (distance < detectRadius) //tsekataan etäisyys
            {
                if (distance > attackDist) 
                    state = 1; //mikäli se on hyökkäysetäisyyttä isompi, jahdataan
                else
                    state = 2;
            }
            else
                state = 0; //idlaillaan
        }
        else //Jos on hyökätty
        {
            attackTimer += Time.deltaTime; //Kasvatetaan timeria, tehdään hyökkääminen mahdolliseksi tietyn ajan päästä
            if (attackTimer > attackTime)
                cooldown = false;
        }
            

        
        switch (state)
        {

            case 0: //idle, käyskentelee ympäriinsä
                anim.anim.speed = 1;
                timer += Time.deltaTime;
                if (timer > timeLimit) //jos timeri täynnä
                {
                    idleTurn = Random.Range(0, 45) - 22.5f; //arvotaan uus suunta
                    transform.Rotate(Vector3.up * idleTurn); //käännytään
                    timeLimit = Random.Range(1, 5); //arvotaan uus timelimit ja nollataan timeri
                    timer = 0;
                }
                speed = idleSpeed;
                break;
            case 1: //jahtaa
                anim.anim.speed = 5;
                targetDir = (target.transform.position - transform.position); //lasketaan uusi kohdepiste
                facing = Quaternion.LookRotation(targetDir); 
                transform.rotation = Quaternion.Slerp(transform.rotation, facing, turnSpeed*Time.deltaTime); //käännytään sitä kohti
                speed = chaseSpeed;                
                break;
            case 2: //hyökkää
                attack = true;
                speed = chaseSpeed * 1.5f;
                break;
            case 3: //keräilee itteään hyökkäyksen jälkeen
                speed = cooldownSpeed;
                anim.anim.speed = cooldownSpeed;
                break;
        }
        Move(speed);
    }

    public float GetDistance(GameObject target)
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        targetX = target.transform.position.x;
        targetY = target.transform.position.y;
        targetZ = target.transform.position.z;

        return Mathf.Sqrt(Mathf.Pow(targetX - x, 2) + Mathf.Pow(targetY - y, 2) + Mathf.Pow(targetZ - z, 2));
    }

    public void Move(float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall")) //Osuko seinään        
            transform.Rotate(Vector3.up * 180); //täyskäännös jos osu

        if (collision.gameObject.CompareTag("Player") && attack) //jos on hyökkäämässä ja osuu pelaajaan
        {            
            Player.TakeDamage(20); //tehdään damagea, poistutaan hyökkäyksestä ja jäähdytellään
            attack = false;
            cooldown = true;
            attackTimer = 0;
            state = 3;
        }

    }
}
