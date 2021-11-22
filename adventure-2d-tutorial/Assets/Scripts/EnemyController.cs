using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    public AudioClip fixSound;
    public ParticleSystem smokeEffect;
    public ParticleSystem hitEffectPrefab;

    AudioSource audioSource;
    Animator animator;
    Rigidbody2D rb2D;
    float timer;
    int direction = 1;
    bool broken = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void Update()
    {
        if (!broken)
        {
            return;
        }
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }
        Vector2 position = rb2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        rb2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        rb2D.simulated = false;

        audioSource.Stop();
        audioSource.PlayOneShot(fixSound); // added, not from tutorial
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
        GameObject.Find("Ruby").GetComponent<RubyController>().FixRobot(); // added, not from tutorial

        ParticleSystem hitEffect = Instantiate(hitEffectPrefab, rb2D.position + Vector2.up * 0.5f, Quaternion.identity);
    }
}
