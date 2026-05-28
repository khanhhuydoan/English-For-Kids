using UnityEngine;
using UnityEngine.EventSystems;

public class Audios_active : MonoBehaviour
{
    public AudioSource loaPhatAmThanh;

    // Hàm này gắn vào 12 nút B1->B12 (hoặc 26 nút chữ cái)
    public void BamNutTuDong()
    {
        GameObject nutVuaBam = EventSystem.current.currentSelectedGameObject;

        if (nutVuaBam != null)
        {
            string tenTuVung = nutVuaBam.name;
            Vocabulary tuHienTai = null;

            switch (GameManager.chuDeHienTai)
            {
                case "Alphabet": tuHienTai = new Alphabet(tenTuVung); break;
                case "Animal": tuHienTai = new Animal(tenTuVung); break;
                case "Food": tuHienTai = new Food(tenTuVung); break;
                case "Fruit": tuHienTai = new Fruit(tenTuVung); break;
                case "Vehicle": tuHienTai = new Vehicle(tenTuVung); break;
                case "Job": tuHienTai = new Job(tenTuVung); break;
            }

            // Chỉ cần lấy file mp3 ra phát (Không cần đổi ảnh nữa vì QuanLyBangHoc đã đổi rồi)
            if (tuHienTai != null && tuHienTai.AmThanh != null)
            {
                loaPhatAmThanh.clip = tuHienTai.AmThanh;
                loaPhatAmThanh.Play();
                tuHienTai.pronounce();
            }
        }
    }
}