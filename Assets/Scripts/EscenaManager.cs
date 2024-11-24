using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EscenaManager : MonoBehaviour
{
    public BulletMovement BulletMovement;
    public GameObject player;
    private AudioSource audioSource;       
    public AudioClip restartSound;
    public AudioClip exitSound;
    public string sceneName;
    public string sceneNameMenu;
    public GameObject canvas;
    private void Start()
    {
        audioSource = player.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            audioSource.Pause();
            canvas.SetActive(true);
        }
    }
    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1;
        if (audioSource != null && restartSound != null)
        {
            audioSource.PlayOneShot(restartSound);
        }
        BulletMovement.ResetDefaultValues();
        StartCoroutine(LoadSceneWithDelay(0.5f));
    }

    public void ChangeSceneMenu(string sceneName)
    {
        Time.timeScale = 1;
        if (audioSource != null && restartSound != null)
        {
            audioSource.PlayOneShot(restartSound);
        }
        BulletMovement.ResetDefaultValues();
        StartCoroutine(LoadSceneWithDelayMenu(0.5f));
    }

    public void doExitGame()
    {
        audioSource.Stop();
        if (audioSource != null && exitSound != null)
        {
            audioSource.PlayOneShot(exitSound);
        }
        StartCoroutine(ExitWithDelay(1f));
    }

    private IEnumerator LoadSceneWithDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator LoadSceneWithDelayMenu(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(sceneNameMenu);
    }

    private IEnumerator ExitWithDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Application.Quit();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        if (audioSource != null && restartSound != null)
        {
            audioSource.PlayOneShot(restartSound);
        }
        audioSource.UnPause();
        canvas.SetActive(false);
    }
}
