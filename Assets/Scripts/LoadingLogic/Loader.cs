using UnityEngine.SceneManagement;

/// <summary>
/// класс хранящий сцены и реализующий более простую и понятную загрузку сцен
/// </summary>
public static class Loader
{
    public enum Scene
    {
        MainMenu,
        LoadingScreen,
        GameScene,
    }

    private static Scene _targetScene;

    public static void Load(Scene targetScene)
    {
        _targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScreen.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(_targetScene.ToString());
    }
}