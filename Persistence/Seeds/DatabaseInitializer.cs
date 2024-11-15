﻿using Domain.Entities;
using Persistence.Contexts;
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
                    "САЙТ-ВИЗИТКА",
                    "Ваш личный сайт или сайт вашего предприятия. Как правило содержит до 8 страниц и форму обратной связи. Функционал сайта можно расширить за счет модулей, добавив фотогалерею, калькулятор и многое другое.",
                    12000
                );
            list.Add(obj1);
            //-------------

            var obj2 = new SiteTypeEntity(
                    "САЙТ-ПОРТАЛ",
                    "Информативный, развлекательный портал, интерактивный блог, либо форум. Этот тип сайта является очень функциональным и позволяет создавать действительно крупные проекты со специфическим функционалом.",
                    15000
                );
            list.Add(obj2);
            //-------------

            var obj3 = new SiteTypeEntity(
                    "ИНТЕРНЕТ-МАГАЗИН",
                    "Продаете товары? Желаете чтобы у вас был их каталог с возможностью покупки онлайн? Все это вам поможет сделать Интернет-магазин. Функционал сайта можно расширить за счет модулей.",
                    17000
                );
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
                    "ФОРУМ",
                    "Уникальная форум-система позволит создать площадку для обсуждения тем на вашем сайте. Обычно используется для сайтов сетей или сообществ.",
                    7000
                );
            list.Add(obj1);
            //-------------

            var obj2 = new SiteModulesEntity(
                    "КОРЗИНА ПОКУПОК",
                    "Корзина товаров. Необходима для оформления заказа с множеством товаров одновременно.",
                    7000
                );
            list.Add(obj2);
            //-------------

            var obj3 = new SiteModulesEntity(
                    "СТРАНИЦЫ",
                    "Модуль создания собственных страниц. Встроенный визуальный редактор. Возможность импорта из Word..",
                    5000
                );
            list.Add(obj3);
            //-------------

            var obj4 = new SiteModulesEntity(
                    "НОВОСТНОЙ БЛОГ",
                    "Вы можете наполнить сайт статьями, либо вести свой блог. Вам будет доступен визуальный редактор публикаций, и система тегов.",
                    5700
                );
            list.Add(obj4);
            //-------------

            var obj5 = new SiteModulesEntity(
                    "ФАЙЛОВЫЙ МЕНЕДЖЕР",
                    "Позволяет загружать изображения и файлы на сайт. Удобен для создания статей и оформления страниц медийным контентом.",
                    0
                );
            list.Add(obj5);
            //-------------

            var obj6 = new SiteModulesEntity(
                    "СЛАЙДЕР",
                    "Слайдер - это блок с баннерами, которые циклически сменяют друг друга. Как правило размещен в верхней части сайта.",
                    2900
                );
            list.Add(obj6);
            //-------------

            var obj7 = new SiteModulesEntity(
                    "ФОТО ГАЛЕРЕЯ",
                    "Позволит вам организовать фото-каталог ваших работ с возможностью создавать категории.",
                    4200
                );
            list.Add(obj7);
            //-------------

            var obj8 = new SiteModulesEntity(
                    "КАЛЬКУЛЯТОР",
                    "Калькулятор создается индивидуально. Ваши клиенты легко смогут рассчитать стоимость услуг и быстрее оформят заказ.",
                    14300
                );
            list.Add(obj8);
            //-------------

            var obj9 = new SiteModulesEntity(
                    "ОБРАТНАЯ СВЯЗЬ",
                    "Форма обратной связи позволяющая посетителю сайта написать вам на e-mail.",
                    1200
                );
            list.Add(obj9);
            //-------------

            var obj10 = new SiteModulesEntity(
                    "ОБРАТНЫЙ ЗВОНОК",
                    "Кнопка обратного звонка. Отправляет Вам сообщение в Telegram с номером посетителя, который заполнил всплывающую форму на сайте.",
                    4300
                );
            list.Add(obj10);
            //-------------

            var obj11 = new SiteModulesEntity(
                    "ПОДПИСКА И РАССЫЛКА",
                    "Позволяет пользователям сайта подписываться на новости и рассылку с вашего сайта.",
                    2800
                );
            list.Add(obj11);
            //-------------

            var obj12 = new SiteModulesEntity(
                    "МУЛЬТИЯЗЫЧНЫЙ САЙТ",
                    "Мультиязычный модуль, позволяющий переводить сайт на разные языки.",
                    11000
                );
            list.Add(obj12);
            //-------------

            var obj13 = new SiteModulesEntity(
                    "КАТАЛОГ ТОВАРОВ",
                    "Каталог товаров для интернет-магазина любого типа. Позволяет создавать категории и загружать товары через панель администратора.",
                    20000
                );
            list.Add(obj13);
            //-------------

            var obj14 = new SiteModulesEntity(
                    "ОНЛАЙН ОПЛАТА",
                    "Подключение полуавтоматического онлайн сервиса приема платежей для интернет-магазина.",
                    7200
                );
            list.Add(obj14);
            //-------------

            var obj15 = new SiteModulesEntity(
                    "ВЫБОР ВАЛЮТЫ",
                    "Позволяет переводить всю валюту заданному по курсу в любую другую валюту мира.",
                    2800
                );
            list.Add(obj15);
            //-------------

            var obj16 = new SiteModulesEntity(
                    "МУЛЬТИКАТЕГОРИИ",
                    "Позволяет присваивать товару принадлежность сразу к нескольким категориям.",
                    0
                );
            list.Add(obj16);
            //-------------

            var obj17 = new SiteModulesEntity(
                    "ВИДЫ ТОВАРОВ",
                    "Дает возможность создавать разновидности одной и той же позиции товара с разными цветами ценой и т.п.",
                    2900
                );
            list.Add(obj17);
            //-------------

            var obj18 = new SiteModulesEntity(
                    "АКЦИИ",
                    "Модуль акций. Позволяет оформлять акции и группировать товары на время их проведения.",
                    2200
                );
            list.Add(obj18);
            //-------------

            var obj19 = new SiteModulesEntity(
                    "XML/API ИМПОРТЁР",
                    "Импортер товаров со складов поставщика с XML файла либо через API (таких как Brain и т.п.). Импортер будет написан исходя из пожеланий заказчика.",
                    22000
                );
            list.Add(obj19);
            //-------------

            var obj20 = new SiteModulesEntity(
                    "РЕКОМЕНДОВАННЫЕ ТОВАРЫ",
                    "На странице товаров, можно рекомендовать товары из других категорий.",
                    2100
                );
            list.Add(obj20);
            //-------------

            var obj21 = new SiteModulesEntity(
                    "ОПТОВЫЕ ЦЕНЫ",
                    "Позволяет указывать цены с привязкой к количеству купленных товаров. Например если покупатель берет 100 едениц товара, то цена будет другая нежели за одну.",
                    5700
                );
            list.Add(obj21);
            //-------------

            var obj22 = new SiteModulesEntity(
                    "ПОИСКОВЫЕ ФИЛЬТРЫ",
                    "Дает возможность выбирать товар в категориях с учетом его характеристик. Напирмер мобильные телефоны можно сортировать по бренду, диагонали, объему батареи и т.д.",
                    14200
                );
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
                    "ДИЗАЙН ОТ WEBCANAPE",
                    "Адаптивный дизайн созданный полностью на усмотрение WebCanape, c минимальными правками со стороны заказчика (возможность выбора цветовой гаммы и т.п.). Отрисовка предварительного макета не делается.",
                    12000
                );
            list.Add(obj1);
            //-------------

            var obj2 = new SiteDesignEntity(
                    "Индивидуальный дизайн",
                    "Адаптивный дизайн в котором все элементы согласовываются с заказчиком. Создается предварительный макет базовых страниц в формате PSD/PDF. Разработка занимает больше времени чем 'дизайн от WebCanape'.",
                    28000
                );
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
                    "СОЗДАНИЕ ЛОГОТИПА",
                    "Создание фирменного уникального логотипа в векторном формате.",
                    5800
                );
            list.Add(obj1);
            //-------------

            var obj2 = new OptionalDesignEntity(
                    "БАННЕР",
                    "Отрисовка баннера или слайдера в формате psd/png.",
                    2900
                );
            list.Add(obj2);
            //-------------

            var obj3 = new OptionalDesignEntity(
                    "ЛЕНДИНГ",
                    "Дизайн и верстка лендинг страницы призывающей клиента к действию.",
                    15700
                );
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
                    "ПРОСТАЯ СТРАНИЦА",
                    "Текстовая и графическая информация. Без сложных таблиц и множества изображений.",
                    900
                );
            list.Add(obj1);
            //-------------

            var obj2 = new SiteSupportEntity(
                    "СЛОЖНАЯ СТРАНИЦА",
                    "Страница с таблицами, видео, всплывающими картинками, либо адаптивной версткой.",
                    2500
                );
            list.Add(obj2);
            //-------------

            var obj3 = new SiteSupportEntity(
                    "РЕДАКТИРОВАНИЕ СТРАНИЦЫ",
                    "Страница с таблицами, видео, всплывающими картинками, либо адаптивной версткой.",
                    400
                );
            list.Add(obj3);
            //-------------

            var obj4 = new SiteSupportEntity(
                    "РАЗМЕЩЕНИЕ МАТЕРИАЛА",
                    "Размещение материала предоставленного в электронном виде. Цена зависит от сложности позиции и рассчитывается индивидуально.",
                    500
                );
            list.Add(obj4);
            //-------------

            var obj5 = new SiteSupportEntity(
                    "ПЕРЕВОД САЙТА",
                    "Наполнение сайта переведенным текстом. Стоимость указана за одну страницу.",
                    700
                );
            list.Add(obj5);
            //-------------

            var obj6 = new SiteSupportEntity(
                    "ПЕРЕНОС ДАННЫХ",
                    "Перенос данных с прежнего сайта в больших, или малых количествах. В том числе перенос товаров интернет-магазина, комментариев, либо отдельнло созданных страниц. Цена может менятся в зависимости от сложности задачи.",
                    14000
                );
            list.Add(obj6);
            //-------------

            var obj7 = new SiteSupportEntity(
                    "ИЗМЕНЕНИЕ ТЕЛЕФОНА",
                    "Изменение телефона или адреса на сайте.",
                    0
                );
            list.Add(obj7);
            //-------------

            var obj8 = new SiteSupportEntity(
                    "ХОСТИНГ - 1 ГОД",
                    "Покупая хостинг у нас, мы гарантируем Вам стабильную работу сайта! Настройку сервера и защиту от DDOS атак. Цена на хостинг может манятся в зависимости от масштаба проекта.",
                    8000
                );
            list.Add(obj8);
            //-------------

            var obj9 = new SiteSupportEntity(
                    "РЕЗЕРВНЫЕ КОПИИ",
                    "Ежедневное резервное копирование сайта и базы данных в облачное хранилище.",
                    0
                );
            list.Add(obj9);
            //-------------

            var obj10 = new SiteSupportEntity(
                    "ОБСЛУЖИВАНИЕ ДОМЕНА",
                    "Покупка и продление домена на год. В стоимость входит подключение облачных DNS, с защитой сайта от DDOS атак.",
                    2800
                );
            list.Add(obj10);
            //-------------

            var obj11 = new SiteSupportEntity(
                    "ЯНДЕКС КАРТА",
                    "Ваше предприятие будет доступно на карте мира с точным маршрутом проезда, изображениями фасада и графиком работы. На картах мира Яндекс вас легко можно будет найти по названию предприятия.",
                    1000
                );
            list.Add(obj11);
            //-------------

            var obj12 = new SiteSupportEntity(
                    "ПОЧТОВЫЙ СЕРВЕР",
                    "Установка и настройка почтового сервера, который позволяет клиентам получать письма о заказах, либо же используюется для формы обратной связи. При этом домен почты будет иметь вид info@domain.com (где domain.com - название вашего сайта). Кроме этого письма с такого сервера никогда не попадают в СПАМ.",
                    2900
                );
            list.Add(obj12);
            //-------------

            var obj13 = new SiteSupportEntity(
                    "СКРИПТЫ",
                    "Счетчики посещаемости, Онлайн консультант для магазина, Гостевая книга, Google/Yandex карты и т.п.",
                    0
                );
            list.Add(obj13);
            //-------------

            //####################################
            await db.SiteSupports.AddRangeAsync(list);
            await db.SaveChangesAsync();
        }
        #endregion

        #region Users
        if (await db.Users.CountAsync() == 0) 
        {
            var list = new List<UserEntity>();

            var user1 = new UserEntity(
                                        "vd@mail.ru",
                                        "vdvdvd",
                                        "admin", 
                                        "+7(999)999-99-99",
                                        "Валерия",
                                        "Андреевна",
                                        "Дружинина"
                                        );// или admin

            list.Add(user1);
            // ------------------------

            var user2 = new UserEntity(
                                        "mv@mail.ru",
                                        "mvmvmv",
                                        "admin",
                                        "+7(999)999-99-98",
                                        "Воротилова",
                                        "Маргарита",
                                        "Юрьевна"
                                        );// или admin

            list.Add(user2);
            // ------------------------ 

            var user3 = new UserEntity(
                                       "yk@mail.ru",
                                       "ykykyk",
                                       "user",
                                       "+7(999)999-99-97",
                                       "Кулакова",
                                       "Яна",
                                       "Алексеевна"
                                       );// или admin

            list.Add(user3);
            // ------------------------ 

            var user4 = new UserEntity(
                                       "kk@mail.ru",
                                       "kkkkkk",
                                       "user",
                                       "+7(999)999-99-96",
                                       "Хлусович",
                                       "Кристина",
                                       "Витальевна"
                                       );// или admin

            list.Add(user4);
            // ------------------------ 

            var user5 = new UserEntity(
                                       "se@mail.ru",
                                       "sesese",
                                       "user",
                                       "+7(999)999-99-95",
                                       "Стрелова",
                                       "Екатерина",
                                       "Александровна"
                                       );// или admin

            list.Add(user5);
            // ------------------------ 


            var user6 = new UserEntity(
                                           "bе@mail.ru",
                                           "bеbеbе",
                                           "user",
                                           "+7(999)999-99-94",
                                           "Баранова",
                                           "Екатерина",
                                           "Сергеевна"
                                           );// или admin

            list.Add(user6);
            // ------------------------ 



            var user7 = new UserEntity(
                                       "ie@mail.ru",
                                       "ieieie",
                                       "user",
                                       "+7(999)999-99-93",
                                       "Иванова",
                                       "Екатерина",
                                       "Андреевна"
                                       );// или admin

            list.Add(user7);
            // ------------------------ 


            var user8 = new UserEntity(
                                       "dh@mail.ru",
                                       "hdhdhd",
                                       "user",
                                       "+7(999)999-99-92",
                                       "Хроменков",
                                       "Дмитрий",
                                       "Алексеевич"
                                       );// или admin

            list.Add(user8);
            // ------------------------ 


            var user9 = new UserEntity(
                                       "nk@mail.ru",
                                       "nknknk",
                                       "user",
                                       "+7(999)999-99-91",
                                       "Косов",
                                       "Никита",
                                       "Станиславович"
                                       );// или admin

            list.Add(user9);
            // ------------------------ 


            var user10 = new UserEntity(
                                       "iz@mail.ru",
                                       "iziziz",
                                       "user",
                                       "+7(999)999-99-90",
                                       "Зубарева",
                                       "Ирина",
                                       "Руслановна"
                                       );// или admin

            list.Add(user10);
            // ------------------------ 


            var user11 = new UserEntity(
                                       "dp@mail.ru",
                                       "dpdpdp",
                                       "user",
                                       "+7(999)999-99-89",
                                       "Плешков",
                                       "Даниил",
                                       "Романович"
                                       );// или admin

            list.Add(user11);
            // ------------------------ 


            var user12 = new UserEntity(
                                       "ad@mail.ru",
                                       "adadad",
                                       "user",
                                       "+7(999)999-99-88",
                                       "Данилова",
                                       "Анна",
                                       "Даниловна"
                                       );// или admin

            list.Add(user12);
            // ------------------------ 


            //####################################
            await db.Users.AddRangeAsync(list);
            await db.SaveChangesAsync();
        }
        #endregion

        #region devTimeline
        if (await db.DevelopmentTimelines.CountAsync() == 0)
        {
            var list = new List<DevelopmentTimelineEntity>();

            var obj1 = new DevelopmentTimelineEntity(
                    "Не имеет значения",
                    1f
                );
            list.Add(obj1);
            //-------------

            var obj2 = new DevelopmentTimelineEntity(
                    "В течение 3 месяцев",
                    1.1f
                );
            list.Add(obj2);
            //-------------

            var obj3 = new DevelopmentTimelineEntity(
                    "в течение месяца",
                    1.3f
                );
            list.Add(obj3);
            //-------------

            //####################################
            await db.DevelopmentTimelines.AddRangeAsync(list);
            await db.SaveChangesAsync();
        }
        #endregion
    }
}
