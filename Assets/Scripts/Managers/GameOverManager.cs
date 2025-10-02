using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay = 5f;


    Animator anim;
	float restartTimer;

    [SerializeField] PlayerStats playerStats; // Gets player's currentHealth


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerStats.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay) {
				Application.LoadLevel(Application.loadedLevel);
			}
        }
    }
}
