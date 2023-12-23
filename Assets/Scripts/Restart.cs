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
        //TODO: �i�J�C���}�l�e��
        SceneManager.LoadScene("start");
    }
}
