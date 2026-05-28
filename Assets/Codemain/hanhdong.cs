using System.Collections;
using UnityEngine;

public class hanhdong : MonoBehaviour
{
    [Header("Liên kết Cánh Tay Tĩnh (Luôn hạ)")]
    public Transform canhTayTinh;

    [Header("Liên kết Bộ Phận Vẫy Tay")]
    public Transform canhTayVay;
    public Transform banTayVay;

    [Header("Cài đặt Thời gian")]
    public float thoiGianCho = 5f;
    public float thoiGianGioTay = 0.2f;
    public float thoiGianVayTay = 1f;

    [Header("Cài đặt Nhảy (Thân)")]
    public float doCaoNhay = 0.5f;

    [Header("Góc Trạng Thái Nghỉ")]
    public float gocNghi_TayTinh = -60f;
    public float gocNghi_TayVay = -60f;

    [Header("Góc Xoay Hành Động")]
    // SỬA LỖI Ở ĐÂY: Đổi "gocGioTay lên" thành "gocGioTay" viết liền
    public float gocGioTay = 120f;
    public float gocVayBanTay = 45f;
    public float tocDoVay = 25f;

    private Vector3 viTriThanBanDau;
    private float gocBanTayBanDau;

    void Start()
    {
        viTriThanBanDau = transform.localPosition;

        if (canhTayTinh != null)
        {
            canhTayTinh.localRotation = Quaternion.Euler(0, 0, gocNghi_TayTinh);
        }
        if (canhTayVay != null)
        {
            canhTayVay.localRotation = Quaternion.Euler(0, 0, gocNghi_TayVay);
        }

        if (banTayVay != null)
        {
            gocBanTayBanDau = banTayVay.localEulerAngles.z;
        }

        StartCoroutine(VongLapKichHoat());
    }

    IEnumerator VongLapKichHoat()
    {
        while (true)
        {
            yield return new WaitForSeconds(thoiGianCho);

            float tongThoiGianAction = thoiGianGioTay + thoiGianVayTay + thoiGianGioTay;

            StartCoroutine(ThucHienNhay(tongThoiGianAction));

            // Sửa lại tên biến ở đây để gọi đúng chữ gocGioTay
            yield return StartCoroutine(XoayBoPhan(canhTayVay, gocNghi_TayVay, gocGioTay, thoiGianGioTay));

            yield return StartCoroutine(ThucHienVayBanTay());

            yield return StartCoroutine(XoayBoPhan(canhTayVay, gocGioTay, gocNghi_TayVay, thoiGianGioTay));
        }
    }

    IEnumerator ThucHienNhay(float thoiGianNhay)
    {
        float t = 0;
        while (t < thoiGianNhay)
        {
            t += Time.deltaTime;
            float chieuCao = Mathf.Sin((t / thoiGianNhay) * Mathf.PI) * doCaoNhay;
            transform.localPosition = new Vector3(viTriThanBanDau.x, viTriThanBanDau.y + chieuCao, viTriThanBanDau.z);
            yield return null;
        }
        transform.localPosition = viTriThanBanDau;
    }

    IEnumerator XoayBoPhan(Transform boPhan, float gocBatDau, float gocDich, float thoiGianXoay)
    {
        if (boPhan == null) yield break;
        float t = 0;
        while (t < thoiGianXoay)
        {
            t += Time.deltaTime;
            float gocHienTai = Mathf.LerpAngle(gocBatDau, gocDich, t / thoiGianXoay);
            boPhan.localRotation = Quaternion.Euler(0, 0, gocHienTai);
            yield return null;
        }
        boPhan.localRotation = Quaternion.Euler(0, 0, gocDich);
    }

    IEnumerator ThucHienVayBanTay()
    {
        if (banTayVay == null) yield break;
        float t = 0;
        while (t < thoiGianVayTay)
        {
            t += Time.deltaTime;
            float gocHienTai = gocBanTayBanDau + Mathf.Sin(t * tocDoVay) * gocVayBanTay;
            banTayVay.localRotation = Quaternion.Euler(0, 0, gocHienTai);
            yield return null;
        }
        banTayVay.localRotation = Quaternion.Euler(0, 0, gocBanTayBanDau);
    }
}