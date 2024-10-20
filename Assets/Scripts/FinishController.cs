using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer finishRenderer;
    [SerializeField] private AudioSource finishSound;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject finishParticle;
    [SerializeField] private GameObject trailRenderer;
    [SerializeField] private LevelChanger levelChanger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject explosion = Instantiate(finishParticle, transform.position, transform.rotation);
            finishSound.Play();
            finishRenderer.enabled = false;
            trailRenderer.transform.parent = null;
            player.gameObject.SetActive(false);
            if(gameObject.CompareTag("LastFinish"))
            {
                levelChanger.FadeToFirstLevel();
            }
            else
            {
                levelChanger.FadeToNextLevel();
            }
        }
    }

    private void RestartLevels()
    {
        SceneManager.LoadScene(0);
    }
}
