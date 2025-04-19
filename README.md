# Интернет-магазин рукодельных товаров (UWP/WinUI3)

## 📝 Описание проекта
**Курсовая работа** для 3-го курса по разработке UWP-приложения для Windows 10/11 с использованием современных технологий:
- **WinUI 3** для нативного интерфейса
- **.NET** в качестве платформы
- **JSON** для хранения данных
- **Markdown** для оформления описаний

Магазин специализируется на продаже уникальных handmade-товаров.

## ⚙️ Системные требования
| Компонент | Требования |
|-----------|------------------------|
| **Операционная система** | Windows 10 (версия 1809+) или Windows 11 |
| **Разработка** | Visual Studio 2022 с компонентами: <br>Разработка приложений WinUI <br>.NET 7 и выше |
| **Использовались** | Visual Studio 2022 (17.13.5) <br>.Net 9 <br>Community toolkit |

## 🛠 Технологический стек
	WinUI 3 --> Интерфейс
	Community Toolkit --> MarqueeText, .md render, tags
	Newtonsoft.Json --> База данных

## 📋 Основные функции
- 🔍 Просмотр каталога с Markdown-описаниями
- 🛒 Система корзины (аналог "Added to cart")
- 💳 Виртуальные примеры товаров


## 🗃️ Структура данных
Пример записи в `products.json`:
```json
{
    "Id": 165646848,
    "Name": "Плюшевая игрушка Данте своими руками",
    "Description": "#ПЛЮШЕВЫЙ БОГ ДАНТЕ\n\n## ОПИСАНИЕ\nЭто не просто игрушка - ...",
    "Category": "Искусство (да-да, это уже не просто игрушка!)",
    "Cost": 14999.99,
    "Rating": 5.0,
    "Provider": "Боги плюшевого искусства",
    "Tags": [ 
        "шедевр", 
        "ручная магия", 
        "Данте божественный", 
        "игрушка-легенда" 
    ],
    "Commentaries": [

    ],
    "Specs": [

    ],
    "Pictures": [
      "https://..."
    ]
  }
```

## 🖥️ Примеры кода
### Рендеринг Markdown
Используется community toolkit
```Xaml
xmlns:md="using:CommunityToolkit.Labs.WinUI.MarkdownTextBlock"

<md:MarkdownTextBlock x:Name="MarkdownTextBlock"
                      Text="{x:Bind Product.Description}"
                      UseAutoLinks="True"
                      UseEmphasisExtras="True"
                      UseListExtras="True"
                      UsePipeTables="True"
                      UseTaskLists="True"/>
```

### Загрузка данных
```csharp
// Чтение JSON-файла

StorageFile file = await StorageFile
                            .GetFileFromApplicationUriAsync(GlobalConst.DEFAULT_PRODUCT_JSON_PATH);
string json = await FileIO.ReadTextAsync(file);
```

## 🚀 Установка и запуск
1. Клонировать репозиторий:\
    `bash`: git clone https://github.com/Seregogy/Store.git
  
2. Открыть решение в VS2022

3. Восстановить пакеты:\
    `Visual Studio PowerShell`: dotnet restore

4. Запустить (F5)

## Установка релиза
1. Скачиваем `Store.rar`

2. Разархивируем в любой удобный путь

3. Установка
   - *Однокнопочная*

     ПКМ по `Installer.ps1` -> выполнить в PowerShell

   - *Ручная* 
     
     1. Открыть папку `.app`
     2. Установить сертификат разработчика `Store_1.0.12.0_x64.cer`
     3. Установить приложение `Store_1.0.12.0_x64.msix`

## 📜 Лицензия
MIT License\
Copyright (c) 2025 [Seregogy](https://github.com/Seregogy)\
Разрешено использование в любых целях.

---

[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows)](https://www.microsoft.com/windows)
[![UWP](https://img.shields.io/badge/UWP-%20-blueviolet?logo=.net)](https://docs.microsoft.com/uwp)
