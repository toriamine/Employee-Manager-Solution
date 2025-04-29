# Employee Manager Solution

Проект реализован в виде **многоуровневого решения (Multi-project Solution)**, с разделением на логические слои:

- `Core` — бизнес-логика и модели (Domain + Application Layer)
- `WebApp` — пользовательский веб-интерфейс (Presentation Layer)
- `Tests` — модульные тесты бизнес-логики
- `ConsoleApp` — альтернативный интерфейс для демонстрации (опционально)

Архитектура приближена к **Layered / Modular Monolith**, что позволяет легко масштабировать проект, добавлять другие UI (например, мобильный или API), а также тестировать логику независимо от представления.

---

![GitHub last commit](https://img.shields.io/github/last-commit/toriamine/Employee-Manager-Solution)
![GitHub language count](https://img.shields.io/github/languages/count/toriamine/Employee-Manager-Solution)
![GitHub repo size](https://img.shields.io/github/repo-size/toriamine/Employee-Manager-Solution)
![GitHub license](https://img.shields.io/github/license/toriamine/Employee-Manager-Solution)

---

Функционал:
- 📄 Просмотр списка сотрудников
- ➕ Добавление новых сотрудников
- 🖊 Редактирование информации о сотрудниках
- ❌ Удаление сотрудников
- 🧪 Юнит-тестирование сервисной логики

## 🛠️ Стек технологий

- ASP.NET Core 9 (Razor Pages)
- Entity Framework Core + PostgreSQL
- Bootstrap 5
- xUnit + EF Core InMemory

---

## Скриншоты

Веб-приложение:


https://github.com/user-attachments/assets/60051456-4d27-457f-a71b-1af0451dc120



Консольное приложение:


https://github.com/user-attachments/assets/0ba1dc13-d7e0-4078-b764-9000ef660af3


---

## Особенности:
- Реализован стандартный CRUD
- Web API для работы с данными
- Структурированная архитектура проекта
- Покрытие тестами бизнес-логики

