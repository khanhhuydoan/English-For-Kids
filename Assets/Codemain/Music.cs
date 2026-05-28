using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioSource loaNhac;       // Chi?c loa phát nh?c
    public Slider thanhKeoAmLuong;    // Thanh ch?nh to nh?
    public Toggle nutBatTat;          // Nút h?p ki?m b?t/t?t nh?c

    private static Music thucThe;

    void Awake()
    {
        // Bí kíp "B?t t?": Chuy?n Scene không b? t?t nh?c
        if (thucThe == null)
        {
            thucThe = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        // Khi v?a m? game, c?p nh?t cái thanh kéo và nút tích cho kh?p v?i Loa
        if (thanhKeoAmLuong != null) thanhKeoAmLuong.value = loaNhac.volume;
        if (nutBatTat != null) nutBatTat.isOn = loaNhac.isPlaying;
    }

    // 1. HÀM G?N VÀO NÚT B?T/T?T (TOGGLE)
    public void BatTatNhac(bool dangBat)
    {
        if (dangBat == true)
        {
            loaNhac.Play(); // B?t nh?c
        }
        else
        {
            loaNhac.Pause(); // T?m d?ng nh?c
        }
    }

    // 2. HÀM G?N VÀO THANH KÉO (SLIDER)
    public void ChinhAmLuong(float giaTri)
    {
        loaNhac.volume = giaTri; // Gán âm l??ng b?ng ?úng v? trí c?a thanh kéo
    }
    // Hàm này  T?t Nh?c
    public void TatNhac()
    {
        if (loaNhac != null)
        {
            loaNhac.Pause(); // L?nh t?m d?ng nh?c
        }
    }

    //  hàm B?t Nh?c (n?u b?n ??nh làm 1 nút riêng ?? b?t)
    public void BatNhac()
    {
        if (loaNhac != null)
        {
            loaNhac.Play(); // L?nh phát l?i nh?c
        }
    }
}