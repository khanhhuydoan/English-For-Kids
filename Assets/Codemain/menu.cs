using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // 
   public void Batdau ()
    {
        SceneManager.LoadScene(1);
    }
    public void ThoatGame()
    {
        // In ra ?? xác ??nh thoát thành công
        Debug.Log("?ã b?m nút Thoát Game!");

        //thoát game 
        Application.Quit();
        //thoát ch? ?? ch?y th?
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    // tr? v?
    public void trove ()
    {
        SceneManager.LoadScene(0);
    }
    //vào quiz
    public void QUIZ()
    {
        SceneManager.LoadScene(4);
    }
    //vào ch? ?? alphabet
    public void ALPHABET()
    {
        SceneManager.LoadScene(2);
    }
}
