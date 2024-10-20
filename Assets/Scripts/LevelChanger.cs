using UnityEngine.SceneManagement;
using UnityEngine;
using System.Runtime.InteropServices;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public ProgressController ProgressController;
    private int levelToLoad;


    public void FadeToNextLevel()
    {
        ProgressController.CurrentLevel++;
        PlayerPrefs.SetInt("Level", ProgressController.CurrentLevel);
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComlete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void FadeToFirstLevel()
    {
        animator.SetTrigger("LastFadeOut");
    }

    public void RestartLevels()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(0);
    }
}
