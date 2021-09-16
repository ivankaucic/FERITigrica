
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("IFrames")]
    [SerializeField] private float iframesDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }


    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        PlayerPrefs.SetFloat("Health", currentHealth);

        if (currentHealth > 0)
        {
            //player hurt
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            { 
                //player dead
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                GameOverWaitTimeScreen();
                SceneManager.LoadScene("GameOver");
                PlayerPrefs.SetInt("Score", 0);
            }

        }

    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for(int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframesDuration/(numberOfFlashes*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iframesDuration/(numberOfFlashes*2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    private IEnumerator GameOverWaitTimeScreen()
    {
        print("Hello");
        yield return new WaitForSeconds(100);
    }


}
