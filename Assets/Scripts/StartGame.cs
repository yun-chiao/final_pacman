using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneToLoad;
    public OSC osc;
    void Start()
    {
        OscMessage message;
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SwitchScene);
        Debug.Log("Start Scene!");
        message = new OscMessage();
        message.address = "/trigger/7";
        message.values.Add(1);
        osc.Send(message);
    }

    void SwitchScene()
    {
        //TODO: 進入主遊戲畫面
        OscMessage message;
        Debug.Log("Start Game!");
        message = new OscMessage();
        message.address = "/trigger/7";
        message.values.Add(0);
        osc.Send(message);
        SceneManager.LoadScene("SampleScene");
    }
}
