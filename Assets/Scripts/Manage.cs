using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manage : MonoBehaviour
{
    public player player;
    public float RespawnTime ;
    public int lives ;
    public float RofTruyn ;
    public ParticleSystem Explosion;
    public TextMeshProUGUI Die;


    private void Start()
    {
        Die.gameObject.SetActive(false);
    }
        public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.Explosion.transform.position = asteroid.transform.position; // dang lam gio den day
        this.Explosion.Play();

    }
    public void PlayerDie()
    {
        this.Explosion.transform.position = this.player.transform.position; // dang lam gio den day
        this.Explosion.Play();
        this.lives--;
        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.RespawnTime);
        }
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Truyndamere");
        this.player.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollisions), this.RofTruyn);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        Invoke("ReloadScene", 2f);
        Die.gameObject.SetActive(true);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("LV1");
    }
}
