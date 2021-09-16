using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [Header("FIretrap TImers")]

    [SerializeField] private float damage;
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggeredTrap;
    private bool activeTrap;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!triggeredTrap)
        {
            StartCoroutine(ActivateFiretrap());
        }
        if(activeTrap)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        triggeredTrap = true;
        spriteRend.color = Color.red;

        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        activeTrap = true;
        anim.SetBool("activated", true);

        yield return new WaitForSeconds(activeTime);
        activeTrap = false;
        triggeredTrap = false;
        anim.SetBool("activated", false);
    }


}
