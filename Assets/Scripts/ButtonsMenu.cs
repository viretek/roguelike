using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;

    private void Start()
    {
        // Подключаем обработчики событий к кнопкам
        playButton.onClick.AddListener(OnPlayButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnPlayButtonClick()
    {
        // Загрузка сцены с игрой
        SceneManager.LoadScene("GameScene");
    }

    private void OnExitButtonClick()
    {
        // Код для выхода из приложения
        Debug.Log("Выходим из приложения");
        Application.Quit();
    }
}
