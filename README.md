# ClientSamgk
[![.NET](https://img.shields.io/badge/.NET-8.0%2C%209.0-512BD4)](#)
[![language](https://img.shields.io/badge/language-C%23-239120)](https://learn.microsoft.com/ru-ru/dotnet/csharp/tour-of-csharp/overview)
[![GitHub release](https://img.shields.io/github/v/release/TheCrazyWolf/Api-Client-for-samgk.ru)](https://github.com/TheCrazyWolf/Api-Client-for-samgk.ru/releases/latest)
[![GitHub release date](https://img.shields.io/github/release-date/TheCrazyWolf/Api-Client-for-samgk.ru)](#)
[![Nuget](https://img.shields.io/nuget/v/ClientSamgk)](https://www.nuget.org/packages/ClientSamgk)
[![Nuget download count](https://img.shields.io/nuget/dt/ClientSamgk)](https://www.nuget.org/packages/ClientSamgk)
[![getting started](https://img.shields.io/badge/docs-1D76DB)](https://clientsamgk-docs.vercel.app)

.NET библиотека для REST API [Самарского государственного колледжа](https://samgk.ru)

## Оглавление
- [Установка](#установка)
- [Документация](#-документация)
- [Участие в проекте](#-участие-в-проекте)
- [Лицензия](#лицензия)

## 🚀 Установка

Вы можете установить библиотеку, используя пакет из **NuGet** или загрузив файл `.nupkg` из последнего релиза на GitHub.

### Установка через NuGet

```cmd
dotnet add package ClientSamgk
```

Больше информации доступно на странице NuGet: [ClientSamgk](https://www.nuget.org/packages/ClientSamgk).

### Установка через nupkg file

1. Скачайте nupkg файл из [последнего релиза](https://github.com/TheCrazyWolf/Api-Client-for-samgk.ru/releases/latest). 
2. Создайте локальный источник NuGet:
    * Создайте папку для локального хранения пакетов, например:
        ```cmd
        mkdir ./local-packages
        ```
    * Добавьте локальный источник в конфигурацию NuGet:
        ```cmd
        dotnet nuget add source <полный_путь_к_папке>/local-packages --name LocalPackages
        ```
4. Установите пакет в свой проект из локального источника (обязательно укажите версию):
```cmd
dotnet add package ClientSamgk --version=3.1.3 --source LocalPackages
```

## 📚 Документация

Подробную информацию о функционале библиотеки, API и примеры использования вы можете найти в [документации](https://clientsamgk-docs.vercel.app).

## 📥 Участие в проекте

Есть **интересные идеи** или хотите **поделиться** своим вкладом? Узнайте больше о том, как принять участие в проекте, в разделе [Contributing](CONTRIBUTING.md). 

Ваши предложения и улучшения помогут сделать проект лучше!

## Лицензия

Copyright © 2023-2025 TheCrazyWolf

[![License: MIT](https://img.shields.io/badge/License-MIT-lightgrey.svg)](https://www.tldrlegal.com/license/mit-license)