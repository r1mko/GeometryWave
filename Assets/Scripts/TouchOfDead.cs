using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchOfDead : MonoBehaviour
{
    [SerializeField] private AudioSource playerDeathSound;
    public GravityController gravityController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerDeathSound.Play();
        gravityController.PlayerDeath();
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
