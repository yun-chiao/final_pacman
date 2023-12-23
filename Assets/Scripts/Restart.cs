using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string sceneToLoad;
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SwitchScene);
    }

    void SwitchScene()
    {
        //TODO: 進入遊戲開始畫面
        SceneManager.LoadScene("start");
    }
}
