using UnityEngine;
using System; // Bắt buộc để dùng Exception
using System.Threading.Tasks;

// [TIÊU CHÍ 3 & 5]: Dùng Lớp Trừu Tượng (Abstract Class), Field, Property
public abstract class Vocabulary
{
    // --- Fields ---
    protected string name;
    protected Sprite pictures;
    protected AudioClip audios;

    // --- Properties ---
    public string TenTuVung { get { return name; } }
    public Sprite HinhAnh { get { return pictures; } }
    public AudioClip AmThanh { get { return audios; } }

    public Vocabulary(string tenTu, string unit)
    {
        this.name = tenTu;
        TaiDuLieuTuThuMuc(unit);
    }

    // --- Phương thức (Method) ---
    private void TaiDuLieuTuThuMuc(string unit)
    {
        // [TIÊU CHÍ 6]: Bắt đầu khối xử lý ngoại lệ
        try
        {
            // 1. TẢI HÌNH ẢNH (Từ file lẻ)
            // Thay vì LoadAll, giờ ta chĩa thẳng đường dẫn vào tên file (VD: Alphabet/pictures/A)
            string duongDanAnh = $"{unit}/pictures/{name}";
            pictures = Resources.Load<Sprite>(duongDanAnh);

            // Ném lỗi nếu file ảnh không tồn tại hoặc bị sai tên
            if (pictures == null)
            {
                throw new Exception($"Lỗi: Không tìm thấy file ảnh '{name}' ở đường dẫn {duongDanAnh}");
            }

            // 2. TẢI ÂM THANH
            string duongDanAmThanh = $"{unit}/audios/{name}";
            audios = Resources.Load<AudioClip>(duongDanAmThanh);

            // Ném lỗi nếu không có file âm thanh
            if (audios == null)
            {
                throw new Exception($"Lỗi: Không tìm thấy file âm thanh '{name}' ở đường dẫn {duongDanAmThanh}");
            }
        }
        catch (Exception ex) // [TIÊU CHÍ 6]: "Tóm" ngoại lệ
        {
            Debug.LogError($"[HỆ THỐNG XỬ LÝ NGOẠI LỆ]: {ex.Message}");
        }
    }

    // [TIÊU CHÍ 3 & 4]: Đa hình (Polymorphism) bằng virtual
    public virtual void pronounce()
    {
        Debug.Log($"Phát âm giọng đọc Tiếng Anh chuẩn của từ: {name}");
    }
}


// ==========================================
// KẾ THỪA: LỚP CON BẢNG CHỮ CÁI VÀ CÁC CHỦ ĐỀ
// ==========================================
public class Alphabet : Vocabulary
{
    public Alphabet(string tenTu) : base(tenTu, "Alphabet") { }

    public override void pronounce()
    {
        base.pronounce();
    }
}

public class Food : Vocabulary
{
    public Food(string tenTu) : base(tenTu, "Food") { }

    public override void pronounce()
    {
        base.pronounce();
    }
}

public class Animal : Vocabulary
{
    public Animal(string tenTu) : base(tenTu, "Animal") { }

    public override async void pronounce()
    {
        // ĐÃ XÓA DÒNG TÌM LOA MUSIC Ở ĐÂY ĐỂ TRÁNH XUNG ĐỘT

        try
        {
            AudioClip tiengKeu = Resources.Load<AudioClip>("Animal/sound effect/" + name);

            if (tiengKeu == null)
            {
                throw new System.Exception("Không tìm thấy file âm thanh cho con vật: " + name);
            }

            Debug.Log("[Hiệu ứng] Đang phát tiếng kêu: " + name);

            // TẠO LOA ẢO: Phát tiếng kêu tại vị trí Camera và không đụng chạm đến Nhạc nền
            AudioSource.PlayClipAtPoint(tiengKeu, Camera.main.transform.position);

            // Bắt hệ thống chờ tiếng kêu phát xong mới chạy tiếp 
            await Task.Delay((int)(tiengKeu.length * 1000));
        }
        catch (System.Exception loiNgoaiLe)
        {
            Debug.LogWarning("[Bỏ qua tiếng kêu] " + loiNgoaiLe.Message);
        }

        // Đọc từ vựng
        base.pronounce();
    }
}

public class Vehicle : Vocabulary
{
    public Vehicle(string tenTu) : base(tenTu, "Vehicle") { }

    public override void pronounce()
    {
        base.pronounce();
    }
}

public class Fruit : Vocabulary
{
    public Fruit(string tenTu) : base(tenTu, "Fruit") { }

    public override void pronounce()
    {
        base.pronounce();
    }
}

public class Job : Vocabulary
{
    public Job(string tenTu) : base(tenTu, "Job") { }

    public override void pronounce()
    {
        base.pronounce();
    }
}