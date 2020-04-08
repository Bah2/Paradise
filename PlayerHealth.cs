using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float regenSpeed = 2;
    public float startingHealth = 100;                            // The amount of health the player starts the game with.
    public float currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip damageClip;
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public float deathTimer = 0;
    public int wait;

    Animator anim;                                              // Reference to the Animator component.
    AudioSource damageAudio;
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    Player_Move playerMovement;                                 // Reference to the player's movement.
    public bool isDead;                                                // Whether the player is dead.
    public bool damaged;                                               // True when the player gets damaged.
    public bool safe;

    public Texture2D picture;

    void Awake()
    {
        // Setting up the references.
        //        anim = GetComponent<Animator>();
        damageAudio = GetComponent<AudioSource>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<Player_Move>();

        // Set the initial health of the player.
        currentHealth = startingHealth;
    }


    void Update()
    {
        if (isDead) //purkkaviritys, et ei regenaa vedessä
            safe = false;

        if (safe && currentHealth < startingHealth && !isDead)
            currentHealth += regenSpeed * Time.deltaTime;


        // If the player has just been damaged...

        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
        healthSlider.value = currentHealth;
    }


    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.


        // Play the hurt sound effect.
        damageAudio.clip = damageClip;
        damageAudio.Play();


        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "WaterCollider")
        {
            TakeDamage(200);
        }

    }


    public void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        safe = false;

        Debug.Log("kual");
        // Tell the animator that the player is dead.
        //        anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        playerAudio.clip = deathClip;
        playerAudio.Play();

        // Turn off the movement and shooting scripts.
        playerMovement.enabled = false;

        StartCoroutine(Wait(3f));

        Cursor.visible = (true);

    }

    void OnGUI()
    {
        if (isDead == true)
        {
            GUI.DrawTexture(new Rect(500, 100, 900, 700), picture);
        }
    }

    IEnumerator Wait(float sec) //venaillaan parametrin määräämän ajan ennen menua
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("start_menu", LoadSceneMode.Single);
    }
}
