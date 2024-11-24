using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainEscenaManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip restartSound;
    public AudioClip exitSound;
    public string sceneName;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ChangeScene(string sceneName)
    {
        if (audioSource != null && restartSound != null)
        {
            audioSource.PlayOneShot(restartSound);
        }
        StartCoroutine(LoadSceneWithDelay(0.5f));
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
    private IEnumerator ExitWithDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Application.Quit();
    }
}
