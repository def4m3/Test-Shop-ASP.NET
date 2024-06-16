# ASP.NET Проект для управления товарами и заказами

## Обзор

Этот проект представляет собой приложение ASP.NET Core, предназначенное для управления товарами и заказами. В нем используются несколько ключевых шаблонов проектирования и технологий для обеспечения масштабируемой, поддерживаемой и эффективной архитектуры.

## Особенности

- **Управление товарами**: CRUD операции для товаров.
- **Управление заказами**: CRUD операции для заказов.
- **CQRS (Command Query Responsibility Segregation)**: Разделение операций чтения и записи для оптимизации производительности и поддерживаемости.
- **MediatR**: Реализация шаблона CQRS с помощью обработки команд и запросов, что способствует слабой связанности между компонентами.
- **AutoMapper**: Упрощает маппинг объектов, облегчая преобразование объектов передачи данных (DTO) в доменные сущности и наоборот.

## Используемые технологии и шаблоны

- **ASP.NET Core**: Фреймворк для создания веб-приложения.
- **Entity Framework Core**: ORM для доступа к базе данных.
- **CQRS (Command Query Responsibility Segregation)**: Повышает эффективность приложения за счет разделения операций чтения и записи.
- **MediatR**: Управляет отправкой команд и запросов, обеспечивая чистую и слабосвязанную архитектуру.
- **AutoMapper**: Автоматизирует маппинг объектов, уменьшая количество шаблонного кода, необходимого для преобразования данных.
