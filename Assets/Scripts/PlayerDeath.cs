using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;

    [SerializeField] private AudioSource _audioDeath;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        _audioDeath.Play();
        _rb.bodyType = RigidbodyType2D.Static;
        _anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        if (LifeData.Lifes > 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
