using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject player;
    private Vector2 _lookDirection;
    private float _lookAngle;
    private float timer = 0;
    public float fireRate;
    private bool isTimer = true;
    public Sprite CatShoot;
    public Sprite Cat;
    public int additionalShots = 0;
    private bool isNextShotLeft = true;
    private AudioSource audioSource;
    public AudioClip shotSound;

    void Start()
    {
        audioSource = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _lookAngle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle + 90f);
        if (Input.GetMouseButton(0))
        {
            if(isTimer)
            {
                if (audioSource != null && shotSound != null)
                {
                    audioSource.PlayOneShot(shotSound);
                }
                player.GetComponent<SpriteRenderer>().sprite = CatShoot;
                Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                for (int i = 0; i < additionalShots; i++)
                {
                    float angleOffset = 10f * (i + 1);
                    if (isNextShotLeft)
                    {
                        Quaternion leftRotation = Quaternion.Euler(0f, 0f, _lookAngle + 90f - angleOffset);
                        Instantiate(bulletPrefab, transform.position, leftRotation);
                    }
                    else
                    {
                        Quaternion rightRotation = Quaternion.Euler(0f, 0f, _lookAngle + 90f + angleOffset);
                        Instantiate(bulletPrefab, transform.position, rightRotation);
                    }
                    isNextShotLeft = !isNextShotLeft;
                }
                timer = 0;
                isTimer = false;
                
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= fireRate)
                {
                    isTimer = true;
                }
            }
        } 
        else
        {
            player.GetComponent<SpriteRenderer>().sprite = Cat;
        }
    }
}
