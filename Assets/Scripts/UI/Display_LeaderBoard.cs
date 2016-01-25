using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Display_LeaderBoard : MonoBehaviour {

    public Text[] highscoreText;
    LeaderBoard leaderboardManager;

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". Loading...";
        }

        leaderboardManager = GetComponent<LeaderBoard>();

        StartCoroutine("RefreshHighScores");
	}


	public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". ";
            if (highscoreList.Length > i)
            {
                highscoreText[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }
    }
	
	IEnumerator RefreshHighScores() {
	    while (true)
        {
            leaderboardManager.DownloadHighScores();
            yield return new WaitForSeconds(30);
        }
	}
}
