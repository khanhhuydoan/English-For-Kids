using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; // Dùng ?? xáo tr?n và l?c trùng
using TMPro;
using UnityEngine.SceneManagement; //  DÒNG NÀY CÓ QUY?N CHUY?N SCENE

public class QuizManager : MonoBehaviour
{
    [Header("Giao Di?n UI")]
    public GameObject panelStart;
    public GameObject panelQuiz;
    public GameObject panelKetQua; // B?NG M?I THÊM
    public Image imgCauHoi;
    public Button[] btnDapAn;
    public TextMeshProUGUI txtDiemSo; // CH? HI?N TH? ?I?M S?

    [Header("Cài ??t D? Li?u")]
    public string[] danhSachChuDe = {"Food", "Animal", "Vehicle", "Fruit", "Job" };

    private Dictionary<string, List<Sprite>> khoTuVung = new Dictionary<string, List<Sprite>>();

    private string dapAnDung;
    private int soCauDaLam = 0;
    private int soCauDung = 0; // BI?N M?I: ??M S? CÂU ?ÚNG
    private int tongSoCau = 5;

    void Start()
    {
        foreach (string chuDe in danhSachChuDe)
        {
            Sprite[] cacAnh = Resources.LoadAll<Sprite>(chuDe + "/pictures");

            // L?c ??m xem ch? ?? này có ?? 4 "TÊN T? V?NG KHÁC NHAU" không (b? qua ?uôi _0, _1)
            int soTuKhacNhau = cacAnh.Select(anh => anh.name.Split('_')[0]).Distinct().Count();

            if (soTuKhacNhau >= 4)
            {
                khoTuVung.Add(chuDe, cacAnh.ToList());
            }
            else
            {
                Debug.LogWarning($"[B? qua] Ch? ?? '{chuDe}' không ?? 4 t? v?ng khác nhau ?? làm quiz.");
            }
        }
    }

    public void BatDauQuiz()
    {
        if (khoTuVung.Count == 0) return;

        soCauDaLam = 0;
        soCauDung = 0; // Reset ?i?m v? 0
        panelStart.SetActive(false);
        panelKetQua.SetActive(false); // ??m b?o b?ng k?t qu? ?ang t?t
        panelQuiz.SetActive(true);
        TaoCauHoiMoi();
    }

    private void TaoCauHoiMoi()
    {
        if (soCauDaLam >= tongSoCau)
        {
            KetThucQuiz();
            return;
        }

        List<string> cacChuDeHopLe = khoTuVung.Keys.ToList();
        string chuDeDuocChon = cacChuDeHopLe[Random.Range(0, cacChuDeHopLe.Count)];
        List<Sprite> anhCuaChuDe = khoTuVung[chuDeDuocChon];

        // 1. CH?N ?NH ?ÚNG VÀ LÀM S?CH TÊN (C?t b? ?uôi _0, _1)
        Sprite anhDung = anhCuaChuDe[Random.Range(0, anhCuaChuDe.Count)];
        dapAnDung = anhDung.name.Split('_')[0]; // Ví d?: "farmer_0" -> l?y ch? "farmer"
        imgCauHoi.sprite = anhDung;

        // 2. T?O DANH SÁCH 4 ?ÁP ÁN CH?NG TRÙNG L?P
        List<string> cacDapAn = new List<string>();
        cacDapAn.Add(dapAnDung);

        // Vòng l?p tìm 3 ?áp án sai KHÔNG TRÙNG NHAU
        int soLanLap = 0; // Tránh treo máy n?u thi?u d? li?u
        while (cacDapAn.Count < 4 && soLanLap < 100)
        {
            soLanLap++;
            Sprite anhNgauNhien = anhCuaChuDe[Random.Range(0, anhCuaChuDe.Count)];
            string tenSai = anhNgauNhien.name.Split('_')[0]; // Làm s?ch tên rác

            // Ch? thêm vào n?u tên này ch?a có trong danh sách 4 ?áp án
            if (!cacDapAn.Contains(tenSai))
            {
                cacDapAn.Add(tenSai);
            }
        }

        // 3. XÁO TR?N V? TRÍ 4 NÚT
        cacDapAn = cacDapAn.OrderBy(x => Random.value).ToList();

        // 4. HI?N TH? LÊN GIAO DI?N
        for (int i = 0; i < btnDapAn.Length; i++)
        {
            string textDapAn = cacDapAn[i];
            btnDapAn[i].GetComponentInChildren<TextMeshProUGUI>().text = textDapAn;
            btnDapAn[i].image.color = Color.white;
            btnDapAn[i].interactable = true;

            btnDapAn[i].onClick.RemoveAllListeners();
            Button nutHienTai = btnDapAn[i];
            btnDapAn[i].onClick.AddListener(() => KiemTraDapAn(textDapAn, nutHienTai));
        }
    }

    private void KiemTraDapAn(string cauTraLoi, Button nutDuocChon)
    {
        foreach (Button btn in btnDapAn) btn.interactable = false;

        if (cauTraLoi == dapAnDung)
        {
            nutDuocChon.image.color = Color.green;
            soCauDung++; // C?NG 1 ?I?M N?U CH?N ?ÚNG
        }
        else
        {
            nutDuocChon.image.color = Color.red;
            foreach (Button btn in btnDapAn)
            {
                if (btn.GetComponentInChildren<TextMeshProUGUI>().text == dapAnDung)
                {
                    btn.image.color = Color.green;
                }
            }
        }

        soCauDaLam++;
        StartCoroutine(ChuyenCauHoiTiepTheo());
    }

    private IEnumerator ChuyenCauHoiTiepTheo()
    {
        yield return new WaitForSeconds(1.5f);
        TaoCauHoiMoi();
    }

    private void KetThucQuiz()
    {
        // T?t b?ng Quiz, B?t b?ng K?t Qu? và hi?n th? s? ?i?m
        panelQuiz.SetActive(false);
        panelKetQua.SetActive(true);
        txtDiemSo.text = $"Correct answers:\n{soCauDung} / {tongSoCau}";
    }

    // Hàm này dùng ?? g?n vào nút "Tr? V?" ? b?ng K?t Qu?
    public void QuayVeMenuStart()
    {
        panelKetQua.SetActive(false);
        panelStart.SetActive(true);
    }
    public void ExitQuizToMenu()
    {
        // 1. D?ng m?i ho?t ??ng ?ang ch?y (nh? vi?c ch? 1.5s ?? nh?y câu m?i)
        StopAllCoroutines();

        // 2. D?n d?p giao di?n: T?t h?t các b?ng liên quan ??n Quiz
        panelQuiz.SetActive(false);
        panelKetQua.SetActive(false);

        // 3. Hi?n l?i b?ng ch?n ch? ??/B?t ??u
        panelStart.SetActive(true);

        Debug.Log("?ã thoát Quiz và quay v? Menu chính.");
    }
    // Hàm này dùng ?? chuy?n h?n sang Scene khác
    public void VeSceneMenuGoc(string tenScene)
    {
        // Ph?i d?ng th?i gian ch? n?u ?ang d? dang câu h?i
        StopAllCoroutines();

        // T?i Scene m?i d?a theo tên b?n nh?p vào
        SceneManager.LoadScene(tenScene);
    }
}