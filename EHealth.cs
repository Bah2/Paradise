using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHp = 100, hp;
    AudioSource mirriAudio;
    public AudioClip mirriDamageClip;
 
    void Start()
    {
        hp = 100;
    }

    void Awake()
    {
        mirriAudio = GetComponent<AudioSource>();
    }

    public void takeDamage(int amount)
    {
        hp -= amount;

        mirriAudio.clip = mirriDamageClip;
        mirriAudio.Play();

        if (hp < 1)
        {


            Destroy(gameObject);
            
        }
    }
}
