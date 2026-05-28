using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Hàm g?n vào 6 nút Ch? ?? ? màn hình chính
    public void BamChonChuDe()
    {
        // 1. Tóm c? cái nút v?a b?m và l?y tên c?a nó
        GameObject nutVuaBam = EventSystem.current.currentSelectedGameObject;
        string tenChuDe = nutVuaBam.name;

        // 2. G?i tên ch? ?? ?ó lên cho GameManager gi? dùm
        GameManager.chuDeHienTai = tenChuDe;

        // 3. ??i Scene
        if (tenChuDe == "Alphabet")
        {
            // B?m vào b?ng ch? cái thì sang Scene 26 nút
            // (Hãy ch?c ch?n file Scene c?a b?n tên là ALPHABET_SCENE)
            SceneManager.LoadScene("ALPHABET_MENU");
        }
        else
        {
            // B?m vào các ch? ?? còn l?i thì sang Scene 12 nút
            // (Hãy ch?c ch?n file Scene c?a b?n tên là UNIT_SCENE)
            SceneManager.LoadScene("UNIT");
        }
    }
}