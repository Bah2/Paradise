using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHp = 100, hp;
    void Start()
    {
        hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int amount)
    {
        hp -= amount;
        if (hp < 1)
            Destroy(gameObject);
    }
}
