-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Час створення: Квт 07 2020 р., 23:51
-- Версія сервера: 10.1.34-MariaDB
-- Версія PHP: 7.2.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База даних: `prakt`
--

-- --------------------------------------------------------

--
-- Структура таблиці `data`
--

CREATE TABLE `data` (
  `id` int(11) NOT NULL,
  `surname` text NOT NULL,
  `street_name` text NOT NULL,
  `building_num` text NOT NULL,
  `floor_num` int(11) NOT NULL,
  `room_num` int(11) NOT NULL,
  `used_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблиці `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `login` text NOT NULL,
  `pass` text NOT NULL,
  `fname` text NOT NULL,
  `lname` text NOT NULL,
  `email` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп даних таблиці `users`
--

INSERT INTO `users` (`id`, `login`, `pass`, `fname`, `lname`, `email`) VALUES
(1, 'login', 'ddd', 'dd', 'dd', 'dd'),
(2, 'arsen', 'Arsen228Za#', 'Arsen', 'Bobruk', 'arsen@fdfm'),
(3, 'arsen4', 'CD3A9F7050E2E59E8D5A05B348382FEF', 'dsfkn', 'sdlfkn', 'flknds@lndsf'),
(4, 'ar$en', '3A3B2B2AF602F6AA5A6896EB34107204', 'arsen', 'slavic', 'arsenslavik@gmail.com');

--
-- Індекси збережених таблиць
--

--
-- Індекси таблиці `data`
--
ALTER TABLE `data`
  ADD PRIMARY KEY (`id`);

--
-- Індекси таблиці `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для збережених таблиць
--

--
-- AUTO_INCREMENT для таблиці `data`
--
ALTER TABLE `data`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблиці `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
