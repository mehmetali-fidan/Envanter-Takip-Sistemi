# Envanter-Takip-Sistemi
C# ile geliştirilmiş stok yönetim sistemi ödevi
# ETYS - Envanter Takip ve Yönetim Sistemi

Bu proje, işletmelerin stoklarını, ürün kategorilerini ve tedarikçi bilgilerini dijital ortamda yönetebilmesi için geliştirilmiş bir **C# Windows Form** uygulamasıdır.

## 🚀 Projenin Amacı ve Ne İş Yaptığı
Uygulama, temel envanter yönetimi süreçlerini dijitalleştirerek manuel takibi ortadan kaldırmayı hedefler. Temel özellikleri:
* **Ürün Yönetimi:** Ürün ekleme, silme, güncelleme ve listeleme (CRUD).
* **Kategori Yönetimi:** Ürünlerin kategorilere göre ayrılması ve kolay filtrelenmesi.
* **Kritik Stok Takibi:** Stok miktarı azalan ürünlerin ana panelde uyarı olarak gösterilmesi.
* **Güvenli Giriş:** Kullanıcı adı ve şifre ile yetkilendirilmiş erişim.

## 🛠 Kullanılan Teknolojiler
* **Dil:** C# (C-Sharp)
* **Framework:** .NET Framework
* **Veritabanı:** Microsoft SQL Server (MDF Local DB)
* **Arayüz:** Windows Forms

## 📸 Ekran Görüntüleri
1. **Giriş Ekranı:** ![Giriş](ekran_goruntusu_linki_1)
2. **Ana Yönetim Paneli:** ![Ana Panel](ekran_goruntusu_linki_2)
3. **Ürün İşlemleri Sayfası:** ![Ürünler](ekran_goruntusu_linki_3)

## 📖 Kullanım Talimatları
1. Projeyi Visual Studio ile açın.
2. `App.config` dosyasındaki SQL bağlantı adresinin doğruluğunu kontrol edin.
3. Projeyi `F5` tuşu ile başlatın.
4. **Giriş Bilgileri:**
   - **Kullanıcı Adı:** admin (veya veritabanındaki diğer kullanıcılar)
   - **Şifre:** (Belirlediğiniz şifre)
5. Sol taraftaki menüden "Ürünler" sekmesine giderek stoklarınızı yönetmeye başlayabilirsiniz.

## 📂 Dosya Yapısı
* `Form1.cs`: Kullanıcı giriş ekranı.
* `FrmAnaPanel.cs`: İstatistikler ve hızlı erişim menüsü.
* `FrmUrunler.cs`: Ürün yönetim merkezi.
* `Veritabanı Dosyaları`: Proje klasörü altındaki `.mdf` dosyası.
* <img width="830" height="518" alt="Ekran görüntüsü 2026-05-15 205021" src="https://github.com/user-attachments/assets/b9215bbe-a961-4536-911d-870864b29561" />
<img width="881" height="522" alt="Ekran görüntüsü 2026-05-15 205042" src="https://github.com/user-attachments/assets/81d4002c-748b-4f00-8fc8-a3836044f600" />
<img width="1180" height="610" alt="Ekran görüntüsü 2026-05-15 205101" src="https://github.com/user-attachments/assets/2df0ff3e-f0fc-418d-840b-e2acacc9f8d1" />



