using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuanLyBangHoc : MonoBehaviour
{
    public TextMeshProUGUI textTieuDeChuDe; // Ch?a cái ch? "New Text" to trên cùng
    public GameObject[] mang12Nut;          // Ch?a 12 nút B1 ??n B12

    // Hàm này t? ??ng ch?y ngay khi Scene (Màn hình) này v?a ???c m? lên
    void Start()
    {
        KhoiTaoDuLieu();
    }

    public void KhoiTaoDuLieu()
    {
        // 1. ??i ch? tiêu ?? (Ví d?: ??i "New Text" thành "Animal")
        textTieuDeChuDe.text = GameManager.chuDeHienTai;

        // 2. L?y danh sách 12 t? v?ng t??ng ?ng v?i ch? ??
        string[] danhSachTu = LayDanhSachTu();

        // 3. Vòng l?p thay ??i 12 cái nút
        for (int i = 0; i < mang12Nut.Length; i++)
        {
            if (i < danhSachTu.Length)
            {
                mang12Nut[i].SetActive(true); // B?t nút lên
                string tenTuVung = danhSachTu[i];

                // ??i tên c?a v?t th? nút (?? h? th?ng âm thanh ??c ???c)
                mang12Nut[i].name = tenTuVung;

                // ??i ch? Text hi?n th? bên trong nút
                mang12Nut[i].GetComponentInChildren<TextMeshProUGUI>().text = tenTuVung;

                // Load d? li?u (?nh/Ti?ng) t? L?p cha Vocabulary
                Vocabulary tuLoadHinh = null;
                switch (GameManager.chuDeHienTai)
                {
                    
                    case "Animal": tuLoadHinh = new Animal(tenTuVung); break;
                    case "Food": tuLoadHinh = new Food(tenTuVung); break;
                    case "Fruit": tuLoadHinh = new Fruit(tenTuVung); break;
                    case "Vehicle": tuLoadHinh = new Vehicle(tenTuVung); break;
                    case "Job": tuLoadHinh = new Job(tenTuVung); break;
                }

                // G?n ?nh vào nút
                if (tuLoadHinh != null && tuLoadHinh.HinhAnh != null)
                {
                    mang12Nut[i].GetComponent<Image>().sprite = tuLoadHinh.HinhAnh;
                }
            }
            else
            {
                // N?u ch? ?? nào có ít h?n 12 t? thì t?t các nút d? th?a ?i cho ??p
                mang12Nut[i].SetActive(false);
            }
        }
    }

    // Hàm ph? dùng ?? ki?m tra xem ?ang ch?n Ch? ?? gì ?? l?y ?úng danh sách 12 t?
    private string[] LayDanhSachTu()
    {
        switch (GameManager.chuDeHienTai)
        {
           
            case "Animal": return GameManager.tuVungAnimal;
            case "Food": return GameManager.tuVungFood;
            case "Fruit": return GameManager.tuVungFruit;
            case "Vehicle": return GameManager.tuVungVehicle;
            case "Job": return GameManager.tuVungJob;
            default: return new string[0]; // Tr? v? danh sách tr?ng n?u b? l?i
        }
    }

    // Hàm g?n vào Nút Quay L?i (M?i tên xanh góc trái)
    public void BamQuayLai()
    {
        // QUAN TR?NG: S?a ch? "MENU" thành ?úng tên file Scene menu c?a b?n n?u b?n ??t tên khác
        SceneManager.LoadScene("MENU_1");
    }
}