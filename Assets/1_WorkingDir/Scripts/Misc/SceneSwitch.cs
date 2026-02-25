using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void TransitToScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
