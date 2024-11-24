using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int vida;
    public GameObject finJuego;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip deathSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            vida--;
            if (vida <= 0)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(deathSound);
                finJuego.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                if (audioSource != null && hitSound != null)
                {
                    audioSource.PlayOneShot(hitSound);
                }
                animator.SetTrigger("Hit");
            }

        }
    }

    public int getLife()
    {
        return vida;
    }
}
