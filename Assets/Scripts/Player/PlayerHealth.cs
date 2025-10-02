using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    // Will obtain the below from PlayerStats instead

    /*public int startingHealth = 100;
    public int currentHealth;*/

    // All UI elements will be dealt with by UI script

    /*public Slider healthSlider;
    public Image damageImage;*/
    public AudioClip deathClip;
    /*public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);*/



    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;
    //bool damaged;

    int id_die = Animator.StringToHash("Die"); // Hashing for animations

    [SerializeField] PlayerStats playerStats; // Obstains current/startingHealth from here
    [SerializeField] UI_Events visualEvents; // Sets off visuals


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        playerStats.currentHealth = playerStats.startingHealth;
    }

    //Handled by UI script
    /*void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }*/


    public void TakeDamage (int amount)
    {
        playerStats.damaged = true;

        playerStats.currentHealth -= amount;

        //healthSlider.value = currentHealth;
        visualEvents.OnPlayerAttacked?.Invoke();

        playerAudio.Play ();

        if(playerStats.currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

        anim.SetTrigger (id_die); // Replaced string with int

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }
}
