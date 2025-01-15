using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
   

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void GoToPond()
    {
        SceneManager.LoadScene(1);

    }

    public void GoToCave()
    {
        SceneManager.LoadScene(2);

    }







}
