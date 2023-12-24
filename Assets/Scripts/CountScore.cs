using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CountScore : MonoBehaviour
{
    public OSC osc;
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
            OscMessage message;
            message = new OscMessage();
            message.address = "/trigger/5";
            message.values.Add(0);
            osc.Send(message);
            message = new OscMessage();
            message.address = "/trigger/7";
            message.values.Add(1);
            osc.Send(message);
            SceneManager.LoadScene("Win");
        }
        scoreText.text = "Remain Coins: " + score;
    }
}