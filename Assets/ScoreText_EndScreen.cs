using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreText_EndScreen : MonoBehaviour
{
    public Transform Player;
    public CanvasGroup Highscore;
    public Text HighscoreText;
    public AudioClip HighscoreClip;

    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    bool started;
    public void StartDisplay()
    {
        if (started)
            return;
        started = true;
        StartCoroutine(Display());
    }

    private IEnumerator Display()
    {
        int tempScore = 0;
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        if (Mathf.RoundToInt(Player.transform.position.z) > highscore)
            PlayerPrefs.SetInt("Highscore", Mathf.RoundToInt(Player.transform.position.z));
        HighscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0);
        GetComponent<AudioSource>().Play();
        while (tempScore < Mathf.RoundToInt(Player.transform.position.z))
        {
            tempScore++;
            text.text = "Score: " + tempScore;
            yield return null;
        }
        GetComponent<AudioSource>().Stop();
        bool playing = false;
        if (tempScore > highscore)
        {
            while (1 - Highscore.alpha > 0.01)
            {
                Highscore.alpha += 0.01f;
                if (Highscore.alpha > 0.3 && !playing)
                {
                    playing = true;
                    AudioSource.PlayClipAtPoint(HighscoreClip, Camera.main.transform.position);
                }
                yield return null;
            }
        }
        while (Input.GetButtonUp("Jump") == false)
            yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        started = false;
        yield break;
    }
}
