using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CountScore : MonoBehaviour
{
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject coin4;
    public TextMeshProUGUI scoreText;
    private void Update()
    {
        int score = 0;
        if (coin1 != null) score++;
        if (coin2 != null) score++;
        if (coin3 != null) score++;
        if (coin4 != null) score++;
        if(score == 0)
        {
            SceneManager.LoadScene("Win");
        }
        scoreText.text = "Remain Coins: " + score;
    }
}