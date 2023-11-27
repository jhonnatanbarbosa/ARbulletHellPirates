using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneIndex;
    public void ChangeToScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
