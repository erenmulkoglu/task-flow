# TaskFlow - Modern Görev Yönetim Sistemi (TaskFlow - Modern Task Management System)


**ASP.NET Core** ve **React** ile geliştirilmiş tam kapsamlı bir görev yönetim uygulaması. Temiz ve sezgisel arayüzü ile görevlerinizi verimli bir şekilde yönetin.
(A full-stack task management application built with **ASP.NET Core** and **React**. Manage your tasks efficiently with a clean, intuitive interface.)



<img width="1538" height="997" alt="image" src="https://github.com/user-attachments/assets/a4aff607-9a3b-47f7-8651-e4b65dde18f0" />
<img width="1609" height="992" alt="image" src="https://github.com/user-attachments/assets/d09b5c71-2fa2-47b0-8279-0283b4c5496f" />
<img width="1378" height="996" alt="image" src="https://github.com/user-attachments/assets/921c0a35-e98c-42a4-bbd5-31a863f25ab1" />
<img width="1406" height="999" alt="image" src="https://github.com/user-attachments/assets/5e99f8c3-1694-44a9-ba21-d02d57637061" />



## Teknolojiler (Tech)

### Backend
- **ASP.NET Core 2.1** - Web API framework
- **Entity Framework Core 2.1** - ORM
- **SQL Server** - Veritabanı
- **JWT Authentication** - Güvenlik
- **Clean Architecture** - Kod organizasyonu

### Frontend
- **React 18** - UI kütüphanesi
- **React Router v6** - Yönlendirme
- **Axios** - HTTP istemcisi
- **Tailwind CSS 3** - Stil
- **Context API** - State yönetimi



## Özellikler (Features)


### Kimlik Doğrulama (Authentication)
- Kullanıcı kaydı ve girişi (User registration and login)
- JWT tabanlı kimlik doğrulama (JWT-based authentication)
- Güvenli şifre yönetimi (Secure password handling)
- Korumalı rotalar (Protected routes)

### Görev Yönetimi (Task Management)
- Görev oluşturma, okuma, güncelleme ve silme (Create, read, update, and delete tasks)
- Görev önceliği belirleme (Düşük, Orta, Yüksek, Acil) (Set task priorities (Low, Medium, High, Urgent))
- Görev durumu takibi (Yapılacak, Devam Ediyor, Tamamlandı, İptal Edildi) (Track task status (Todo, In Progress, Completed, Cancelled))
- Son tarih ekleme (Add due dates)
- Duruma göre görev filtreleme (Task filtering by status)
- Gerçek zamanlı istatistik panosu (Real-time statistics dashboard)

### Kullanıcı Arayüzü (User Interface)
- Tailwind CSS ile modern, responsive tasarım (Modern, responsive design with Tailwind CSS)
- Sezgisel görev kartları (Intuitive task cards)
- Renkli durum etiketleri (Status badges with color coding)
- Doğrulama özellikli interaktif formlar (Interactive forms with validation)
- Mobil uyumlu düzen (Mobile-friendly layout)


## Proje Yapısı
```
TaskFlow/
├── Backend/
│   ├── TaskFlow.API/          # Web API controller'ları ve başlangıç
│   ├── TaskFlow.Core/         # Domain entity'leri ve DTO'lar
│   ├── TaskFlow.Data/         # Veritabanı context ve repository'ler
│   └── TaskFlow.Service/      # İş mantığı servisleri
└── Frontend/
    └── taskflow-client/       # React uygulaması
        ├── src/
        │   ├── components/    # Yeniden kullanılabilir UI bileşenleri
        │   ├── context/       # React context provider'ları
        │   ├── pages/         # Sayfa bileşenleri
        │   ├── services/      # API servisleri
        │   └── utils/         # Yardımcı fonksiyonlar
        └── public/
```


## API Endpoint'leri

### Kimlik Doğrulama

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| `POST | /api/auth/register` | - Yeni kullanıcı kaydı
| `POST | /api/auth/login` | - Kullanıcı girişi

### Görevler (Kimlik Doğrulama Gerektirir)
- `GET /api/tasks` - Tüm görevleri getir
- `GET /api/tasks/{id}` - ID'ye göre görev getir
- `POST /api/tasks` - Yeni görev oluştur
- `PUT /api/tasks/{id}` - Görevi güncelle
- `DELETE /api/tasks/{id}` - Görevi sil
- `GET /api/tasks/status/{status}` - Duruma göre görevleri getir
- `GET /api/tasks/category/{categoryId}` - Kategoriye göre görevleri getir


## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır - detaylar için [LICENSE](LICENSE) dosyasına bakın.

## Geliştirici

**Eren Mülkoğlu**

- GitHub: [@erenmulkoglu](https://github.com/erenmulkoglu)
- LinkedIn: [Eren Mülkoğlu](https://linkedin.com/in/erenmulkoglu)
- GitLab: [@erenmulkoglu](https://gitlab.com/erenmulkoglu)
