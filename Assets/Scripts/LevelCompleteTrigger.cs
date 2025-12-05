using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteTrigger : MonoBehaviour
{
    public string nextSceneName = "Nivel2";
    public string levelKey = "Nivel1Completado";
    public float delay = 0.5f;
    public AudioSource completeSound;
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;
        PlayerPrefs.SetInt(levelKey, 1);
        PlayerPrefs.Save();

        if (completeSound)
        {
            completeSound.Play();
        }

        StartCoroutine(LoadNext());
    }

    IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}
