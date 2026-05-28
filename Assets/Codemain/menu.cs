using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
   public void Batdau ()
    {
        SceneManager.LoadScene(1);
    }
    public void ThoatGame()
    {
        // In ra dòng ch? này ? c?a s? Console ?? b?n bi?t nút ?ã b?m thành công
        Debug.Log("?ã b?m nút Thoát Game!");

        //thoát game (Ch? ho?t ??ng khi ?ã Build ra file game th?t)
        Application.Quit();

        //  t?t ch? ?? Play ngay bên trong ph?n m?m Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void trove ()
    {
        SceneManager.LoadScene(0);
    }
    public void QUIZ()
    {
        SceneManager.LoadScene(4);
    }
    public void ALPHABET()
    {
        SceneManager.LoadScene(2);
    }
}
