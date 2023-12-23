using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneToLoad;

    void Start()
    {
        Button button = GetComponent<Button>();

        button.onClick.AddListener(SwitchScene);
    }

    void SwitchScene()
    {
        //TODO: �i�J�D�C���e��
        SceneManager.LoadScene("SampleScene");
    }
}
