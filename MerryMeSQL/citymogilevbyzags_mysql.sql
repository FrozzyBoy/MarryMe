--
-- Скрипт сгенерирован Devart dbForge Studio for MySQL, Версия 6.3.341.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 24.05.2015 20:04:35
-- Версия сервера: 5.1.53-community
-- Версия клиента: 4.1
--


USE citymogilevbyzags;

CREATE TABLE `место регистрации` (
  Код int(10) DEFAULT NULL,
  Наименование nvarchar(50) DEFAULT NULL
)
ENGINE = INNODB
AVG_ROW_LENGTH = 16384
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

CREATE TABLE `по умолчанию` (
  Код_обращения int(10) DEFAULT NULL,
  Код_обращения_Интернет int(10) DEFAULT NULL,
  Код_места_регистрации int(10) DEFAULT NULL,
  Код_специалиста int(10) DEFAULT NULL,
  Все boolean DEFAULT NULL,
  Автосохранение boolean DEFAULT NULL,
  Количество_автосохранений tinyint(3) UNSIGNED DEFAULT NULL,
  Путь_для_автосохранения nvarchar(255) DEFAULT NULL
)
ENGINE = INNODB
AVG_ROW_LENGTH = 16384
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

CREATE TABLE `регистрация браков` (
  Счетчик int(10) DEFAULT NULL,
  Дата_обращения datetime DEFAULT NULL,
  Код_зала int(10) DEFAULT NULL,
  Код_обращения int(10) DEFAULT NULL,
  Код_места_регистрации int(10) DEFAULT NULL,
  Код_специалиста int(10) DEFAULT NULL,
  Фамилия_жениха nvarchar(50) DEFAULT NULL,
  Имя_жениха nvarchar(50) DEFAULT NULL,
  Отчество_жениха nvarchar(50) DEFAULT NULL,
  Идентификационный_номер_жениха nvarchar(14) DEFAULT NULL,
  Номер_телефона_жениха nvarchar(20) DEFAULT NULL,
  Фамилия_невесты nvarchar(50) DEFAULT NULL,
  Имя_невесты nvarchar(50) DEFAULT NULL,
  Отчество_невесты nvarchar(50) DEFAULT NULL,
  Идентификационный_номер_невесты nvarchar(14) DEFAULT NULL,
  Номер_телефона_невесты nvarchar(20) DEFAULT NULL,
  Дата_регистрации_брака datetime DEFAULT NULL,
  Время_регистрации_брака datetime DEFAULT NULL,
  Подано_заявление boolean DEFAULT NULL,
  Примечание nvarchar(255) DEFAULT NULL,
  Email nvarchar(50) DEFAULT NULL,
  Спланировано boolean DEFAULT NULL
)
ENGINE = INNODB
AVG_ROW_LENGTH = 82
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

CREATE TABLE `учетные записи` (
  Код int(10) NOT NULL DEFAULT 0,
  Учетная_запись varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Пароль varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Подтверждение_пароля varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Код_специалиста int(10) DEFAULT NULL,
  ФИО varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  Дата_рождения datetime DEFAULT NULL,
  Тип_учетной_записи varchar(15) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (Код)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 8192
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

CREATE TABLE залы (
  Код int(10) DEFAULT NULL,
  Наименование nvarchar(25) DEFAULT NULL,
  Начало_работы datetime DEFAULT NULL,
  Окончание_работы datetime DEFAULT NULL,
  Норма_времени_на_регистрацию datetime DEFAULT NULL,
  Понедельник boolean DEFAULT NULL,
  Вторник boolean DEFAULT NULL,
  Среда boolean DEFAULT NULL,
  Четверг boolean DEFAULT NULL,
  Пятница boolean DEFAULT NULL,
  Суббота boolean DEFAULT NULL,
  Воскресенье boolean DEFAULT NULL
)
ENGINE = INNODB
AVG_ROW_LENGTH = 4096
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

CREATE TABLE имена (
  Имя nvarchar(50) DEFAULT NULL,
  Пол nvarchar(1) DEFAULT NULL
)
ENGINE = INNODB
AVG_ROW_LENGTH = 47
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

CREATE TABLE обращения (
  Код int(10) DEFAULT NULL,
  Наименование nvarchar(30) DEFAULT NULL
)
ENGINE = INNODB
AVG_ROW_LENGTH = 4096
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

CREATE TABLE общие (
  Счетчик int(10) DEFAULT NULL,
  Название_учреждения nvarchar(100) DEFAULT NULL,
  Должность_подписывающего nvarchar(100) DEFAULT NULL,
  ФИО_подписывающего nvarchar(50) DEFAULT NULL,
  Телефон nvarchar(50) DEFAULT NULL
)
ENGINE = INNODB
AVG_ROW_LENGTH = 16384
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

CREATE TABLE отчества (
  Отчество nvarchar(50) DEFAULT NULL,
  Пол nvarchar(1) DEFAULT NULL
)
ENGINE = INNODB
AVG_ROW_LENGTH = 64
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

CREATE TABLE специалисты (
  Код int(10) DEFAULT NULL,
  Специалист nvarchar(50) DEFAULT NULL,
  Должность nvarchar(50) DEFAULT NULL
)
ENGINE = INNODB
AVG_ROW_LENGTH = 8192
CHARACTER SET cp1251
COLLATE cp1251_general_ci;