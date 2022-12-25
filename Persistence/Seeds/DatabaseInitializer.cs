using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Seeds;

public static class DatabaseInitializer
{
    public static async Task SeedAsync(ApplicationDbContext db)
    {
        string str_ini_by = "Initializer";

        #region SiteTipes
        if (await db.SiteTypes.CountAsync() == 0)
        {
            var list = new List<SiteTypeEntity>();

            var obj1 = new SiteTypeEntity(
                    "Сайт-Визитка",
                    "Ваш личный сайт, либо сайт вашего предприятия. Как правило содержит до 8 страниц и форму обратной связи. Функционал сайта можно расширить за счет модулей, добавив фотогалерею и другие.",
                    400,
                    str_ini_by
                );
            obj1.Id = 1;
            list.Add(obj1);
            //-------------

            var obj2 = new SiteTypeEntity(
                    "Сайт-Портал",
                    "Информативный, развлекательный портал, интерактивный блог, либо форум. Этот тип сайта является очень функциональным и позволяет создавать действительно крупные проекты со специфическим функционалом.",
                    740,
                    str_ini_by
                );
            obj2.Id = 2;
            list.Add(obj2);
            //-------------

            var obj3 = new SiteTypeEntity(
                    "Интернет магазин",
                    "Продаете товары? Желаете чтобы у вас был их каталог с возможностью покупки онлайн? Все это вам поможет сделать Интернет-магазин. Функционал сайта можно расширить за счет модулей.",
                    820,
                    str_ini_by
                );
            obj3.Id = 3;
            list.Add(obj3);
            //-------------

            //####################################
            await db.SiteTypes.AddRangeAsync(list);
            await db.SaveChangesAsync();
        }
        #endregion

        #region SiteModules
        if (await db.SiteModules.CountAsync() == 0)
        {
            var list = new List<SiteModulesEntity>();

            var obj1 = new SiteModulesEntity(
                    "Форум",
                    "Уникальная форум-система pedanto, позволит создать площадку для обсуждения тем на вашем сайте. Обычно используется для сайтов сетей или сообществ.",
                    100,
                    str_ini_by
                );
            obj1.Id = 1;
            list.Add(obj1);
            //-------------

            var obj2 = new SiteModulesEntity(
                    "Корзина покупок",
                    "Корзина товаров. Необходима для оформления заказа с множеством товаров одновременно.",
                    300,
                    str_ini_by
                );
            obj2.Id = 2;
            list.Add(obj2);
            //-------------

            var obj3 = new SiteModulesEntity(
                    "Страницы",
                    "Модуль создания собственных страниц. Встроенный визуальный редактор. Возможность импорта из Word.",
                    60,
                    str_ini_by
                );
            obj3.Id = 3;
            list.Add(obj3);
            //-------------

            var obj4 = new SiteModulesEntity(
                    "Новостной блог",
                    "Вы можете наполнить сайт статьями, либо вести свой блог. Вам будет доступен визуальный редактор публикаций, и система тегов.",
                    80,
                    str_ini_by
                );
            obj4.Id = 4;
            list.Add(obj4);
            //-------------

            var obj5 = new SiteModulesEntity(
                    "Файловый менеджер",
                    "Позволяет загружать изображения и файлы на сайт. Удобен для создания статей и оформления страниц медийным контентом.",
                    0,
                    str_ini_by
                );
            obj5.Id = 5;
            list.Add(obj5);
            //-------------

            var obj6 = new SiteModulesEntity(
                    "Слайдер",
                    "Слайдер - это блок с баннерами, которые циклически сменяют друг друга. Как правило размещен в верхней части сайта.",
                    60,
                    str_ini_by
                );
            obj6.Id = 6;
            list.Add(obj6);
            //-------------

            var obj7 = new SiteModulesEntity(
                    "Фото галерея",
                    "Позволит вам организовать фото-каталог ваших работ с возможностью создавать категории.",
                    60,
                    str_ini_by
                );
            obj7.Id = 7;
            list.Add(obj7);
            //-------------

            var obj8 = new SiteModulesEntity(
                    "Калькулятор",
                    "Калькулятор создается индивидуально. Например этот в котором вы сейчас находитесь, был создан полностью с нуля.",
                    200,
                    str_ini_by
                );
            obj8.Id = 8;
            list.Add(obj8);
            //-------------

            var obj9 = new SiteModulesEntity(
                    "Обратная связь",
                    "Форма обратной связи позволяющая посетителю сайта написать вам на e-mail.",
                    20,
                    str_ini_by
                );
            obj9.Id = 9;
            list.Add(obj9);
            //-------------

            var obj10 = new SiteModulesEntity(
                    "Обратный звонок",
                    "Кнопка обратного звонка. Отправляет Вам сообщение в Telegram с номером посетителя, который заполнил всплывающую форму на сайте.",
                    60,
                    str_ini_by
                );
            obj10.Id = 10;
            list.Add(obj10);
            //-------------

            var obj11 = new SiteModulesEntity(
                    "Подписка и рассылка",
                    "Позволяет пользователям сайта подписываться на новости и рассылку с вашего сайта.",
                    40,
                    str_ini_by
                );
            obj11.Id = 11;
            list.Add(obj11);
            //-------------

            var obj12 = new SiteModulesEntity(
                    "Мультиязычный сайт",
                    "Мультиязычный модуль, позволяющий переводить сайт на разные языки.",
                    150,
                    str_ini_by
                );
            obj12.Id = 12;
            list.Add(obj12);
            //-------------

            var obj13 = new SiteModulesEntity(
                    "Каталог товаров",
                    "Каталог товаров для интернет-магазина любого типа. Позволяет создавать категории и загружать товары через панель администратора.",
                    300,
                    str_ini_by
                );
            obj13.Id = 13;
            list.Add(obj13);
            //-------------

            var obj14 = new SiteModulesEntity(
                    "Онлайн оплата",
                    "Подключение полуавтоматического онлайн сервиса приема платежей для интернет-магазина.",
                    100,
                    str_ini_by
                );
            obj14.Id = 14;
            list.Add(obj14);
            //-------------

            var obj15 = new SiteModulesEntity(
                    "Выбор валюты",
                    "Позволяет переводить всю валюту заданному по курсу в любую другую валюту мира.",
                    40,
                    str_ini_by
                );
            obj15.Id = 15;
            list.Add(obj15);
            //-------------

            var obj16 = new SiteModulesEntity(
                    "Мультикатегории",
                    "Позволяет присваивать товару принадлежность сразу к нескольким категориям.",
                    0,
                    str_ini_by
                );
            obj16.Id = 16;
            list.Add(obj16);
            //-------------

            var obj17 = new SiteModulesEntity(
                    "Виды товаров",
                    "Дает возможность создавать разновидности одной и той же позиции товара с разными цветами ценой и т.п.",
                    40,
                    str_ini_by
                );
            obj17.Id = 17;
            list.Add(obj17);
            //-------------

            var obj18 = new SiteModulesEntity(
                    "Акции",
                    "Модуль акций. Позволяет оформлять акции и группировать товары на время их проведения.",
                    30,
                    str_ini_by
                );
            obj18.Id = 18;
            list.Add(obj18);
            //-------------

            var obj19 = new SiteModulesEntity(
                    "XML/API импортер",
                    "Импортер товаров со складов поставщика с XML файла либо через API (таких как Brain и т.п.). Импортер будет написан исходя из пожеланий заказчика.",
                    300,
                    str_ini_by
                );
            obj19.Id = 19;
            list.Add(obj19);
            //-------------

            var obj20 = new SiteModulesEntity(
                    "Рекомендованные товары",
                    "На странице товаров, можно рекомендовать товары из других категорий.",
                    30,
                    str_ini_by
                );
            obj20.Id = 20;
            list.Add(obj20);
            //-------------

            var obj21 = new SiteModulesEntity(
                    "Оптовые цены",
                    "Позволяет указывать цены с привязкой к количеству купленных товаров. Например если покупатель берет 100 едениц товара, то цена будет другая нежели за одну.",
                    80,
                    str_ini_by
                );
            obj21.Id = 21;
            list.Add(obj21);
            //-------------

            var obj22 = new SiteModulesEntity(
                    "Поисковые фильтры",
                    "Дает возможность выбирать товар в категориях с учетом его характеристик. Напирмер мобильные телефоны можно сортировать по бренду, диагонали, объему батареи и т.д.",
                    200,
                    str_ini_by
                );
            obj22.Id = 22;
            list.Add(obj22);
            //-------------

            //####################################
            await db.SiteModules.AddRangeAsync(list);
            await db.SaveChangesAsync();
        }
        #endregion

        #region SiteDesigns
        if (await db.SiteDesigns.CountAsync() == 0)
        {
            var list = new List<SiteDesignEntity>();

            var obj1 = new SiteDesignEntity(
                    "Дизайн от DigitSBMPEI",
                    "Адаптивный дизайн созданный полностью на усмотрение DigitSBMPEI, c минимальными правками со стороны заказчика (возможность выбора цветовой гаммы и т.п.). Отрисовка предварительного макета не делается.",
                    160,
                    str_ini_by
                );
            obj1.Id = 1;
            list.Add(obj1);
            //-------------

            var obj2 = new SiteDesignEntity(
                    "Индивидуальный дизайн",
                    "Адаптивный дизайн в котором все элементы согласовываются с заказчиком. Создается предварительный макет базовых страниц в формате PSD/PDF. Разработка занимает больше времени чем 'дизайн от Pedanto'.",
                    400,
                    str_ini_by
                );
            obj2.Id = 2;
            list.Add(obj2);
            //-------------

            //####################################
            await db.SiteDesigns.AddRangeAsync(list);
            await db.SaveChangesAsync();
        }
        #endregion

        #region OptionalDesigns
        if (await db.OptionalDesigns.CountAsync() == 0)
        {
            var list = new List<OptionalDesignEntity>();

            var obj1 = new OptionalDesignEntity(
                    "Создание логотипа",
                    "Создание фирменного уникального логотипа в векторном формате.",
                    80,
                    str_ini_by
                );
            obj1.Id = 1;
            list.Add(obj1);
            //-------------

            var obj2 = new OptionalDesignEntity(
                    "Баннер",
                    "Отрисовка баннера или слайдера в формате psd/png.",
                    40,
                    str_ini_by
                );
            obj2.Id = 2;
            list.Add(obj2);
            //-------------

            var obj3 = new OptionalDesignEntity(
                    "Лендинг",
                    "Дизайн и верстка лендинг страницы призывающей клиента к действию.",
                    220,
                    str_ini_by
                );
            obj3.Id = 3;
            list.Add(obj3);
            //-------------

            //####################################
            await db.OptionalDesigns.AddRangeAsync(list);
            await db.SaveChangesAsync();
        }
        #endregion

        #region SiteSupports
        if (await db.SiteSupports.CountAsync() == 0)
        {
            var list = new List<SiteSupportEntity>();

            var obj1 = new SiteSupportEntity(
                    "Простая страница",
                    "Текстовая и графическая информация. Без сложных таблиц и множества изображений.",
                    12,
                    str_ini_by
                );
            obj1.Id = 1;
            list.Add(obj1);
            //-------------

            var obj2 = new SiteSupportEntity(
                    "Сложная страница",
                    "Страница с таблицами, видео, всплывающими картинками, либо адаптивной версткой.",
                    36,
                    str_ini_by
                );
            obj2.Id = 2;
            list.Add(obj2);
            //-------------

            var obj3 = new SiteSupportEntity(
                    "Редактирование страницы",
                    "Страница с таблицами, видео, всплывающими картинками, либо адаптивной версткой.",
                    5,
                    str_ini_by
                );
            obj3.Id = 3;
            list.Add(obj3);
            //-------------

            var obj4 = new SiteSupportEntity(
                    "Размещение материала",
                    "Размещение материала предоставленного в электронном виде. Цена зависит от сложности позиции и рассчитывается индивидуально.",
                    7,
                    str_ini_by
                );
            obj4.Id = 4;
            list.Add(obj4);
            //-------------

            var obj5 = new SiteSupportEntity(
                    "Перевод сайта",
                    "Наполнение сайта переведенным текстом. Стоимость указана за одну страницу.",
                    10,
                    str_ini_by
                );
            obj5.Id = 5;
            list.Add(obj5);
            //-------------

            var obj6 = new SiteSupportEntity(
                    "Перенос данных",
                    "Перенос данных с прежнего сайта в больших, или малых количествах. В том числе перенос товаров интернет-магазина, комментариев, либо отдельнло созданных страниц. Цена может менятся в зависимости от сложности задачи.",
                    200,
                    str_ini_by
                );
            obj6.Id = 6;
            list.Add(obj6);
            //-------------

            var obj7 = new SiteSupportEntity(
                    "Изменение телефона",
                    "Изменение телефона или адреса на сайте.",
                    0,
                    str_ini_by
                );
            obj7.Id = 7;
            list.Add(obj7);
            //-------------

            var obj8 = new SiteSupportEntity(
                    "Хостинг - 1 год",
                    "Покупая хостинг у нас, мы гарантируем Вам стабильную работу сайта! Настройку сервера и защиту от DDOS атак. Цена на хостинг может манятся в заыисимости от масштаба проекта.",
                    100,
                    str_ini_by
                );
            obj8.Id = 8;
            list.Add(obj8);
            //-------------

            var obj9 = new SiteSupportEntity(
                    "Резервные копии",
                    "Ежедневное резервное копирование сайта и базы данных в облачное хранилище.",
                    0,
                    str_ini_by
                );
            obj9.Id = 9;
            list.Add(obj9);
            //-------------

            var obj10 = new SiteSupportEntity(
                    "Обслуживание домена",
                    "Покупка и продление домена на год. В стоимость входит подключение облачных DNS, с защитой сайта от DDOS атак.",
                    40,
                    str_ini_by
                );
            obj10.Id = 10;
            list.Add(obj10);
            //-------------

            var obj11 = new SiteSupportEntity(
                    "Google карта",
                    "Ваше предприятие будет доступно на карте мира с точным маршрутом проезда, изображениями фасада и графиком работы. На картах мира Google вас легко можно будет найти по названию предприятия.",
                    15,
                    str_ini_by
                );
            obj11.Id = 11;
            list.Add(obj11);
            //-------------

            var obj12 = new SiteSupportEntity(
                    "Почтовый сервер",
                    "Установка и настройка почтового сервера, который позволяет клиентам получать письма о заказах, либо же используюется для формы обратной связи. При этом домен почты будет иметь вид info@domain.com (где domain.com - название вашего сайта). Кроме этого письма с такого сервера никогда не попадают в СПАМ.",
                    40,
                    str_ini_by
                );
            obj12.Id = 12;
            list.Add(obj12);
            //-------------

            var obj13 = new SiteSupportEntity(
                    "Скрипты",
                    "Счетчики посещаемости, Онлайн консультант для магазина, Гостевая книга, Google/Yandex карты и т.п.",
                    0,
                    str_ini_by
                );
            obj13.Id = 13;
            list.Add(obj13);
            //-------------

            //####################################
            await db.SiteSupports.AddRangeAsync(list);
            await db.SaveChangesAsync();
        }
        #endregion
    }
}
