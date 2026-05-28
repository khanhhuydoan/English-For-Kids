using UnityEngine;

public class DieuKhienNhacTuXa : MonoBehaviour
{
    // Hàm này dùng để tìm hệ thống nhạc và bấm tắt
    public void BamDeTatNhac()
    {
        // Máy tính sẽ tự động tìm vật thể có tên chính xác là "MUSIC"
        GameObject heThongNhac = GameObject.Find("MUSIC");

        if (heThongNhac != null)
        {
            // Nếu tìm thấy, gọi hàm TatNhac() ở bên trong kịch bản Music
            heThongNhac.GetComponent<Music>().TatNhac();
        }
        else
        {
            Debug.Log("Không tìm thấy vật thể MUSIC nào đang chạy!");
        }
    }
    public void BamDeBatNhac()
    {
        GameObject heThongNhac = GameObject.Find("MUSIC");
        if (heThongNhac != null)
        {
            heThongNhac.GetComponent<Music>().BatNhac(); // Gọi hàm BatNhac đã viết ở file Music.cs
        }
        else
        {
            Debug.Log("Không tìm thấy vật thể MUSIC để bật!");
        }
    }
    //  2 HÀM NÀY ĐỂ ĐIỀU KHIỂN BẢNG OPTIONS ---

    public void BatTatNhacTuXa(bool trangThai)
    {
        // Tự động tìm vật thể MUSIC đang sống sót
        GameObject heThongNhac = GameObject.Find("MUSIC");
        if (heThongNhac != null)
        {
            // Truyền trạng thái bật/tắt vào hàm gốc
            heThongNhac.GetComponent<Music>().BatTatNhac(trangThai);
        }
    }

    public void KeoAmLuongTuXa(float giaTri)
    {
        GameObject heThongNhac = GameObject.Find("MUSIC");
        if (heThongNhac != null)
        {
            // Truyền độ lớn âm lượng vào hàm gốc
            heThongNhac.GetComponent<Music>().ChinhAmLuong(giaTri);
        }
    }
}