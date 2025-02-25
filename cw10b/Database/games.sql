-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 18, 2025 at 02:57 PM
-- Wersja serwera: 10.4.32-MariaDB
-- Wersja PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `games`
--
CREATE DATABASE IF NOT EXISTS `games` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `games`;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `games`
--

DROP TABLE IF EXISTS `games`;
CREATE TABLE `games` (
  `id` int(11) NOT NULL,
  `title` varchar(250) NOT NULL,
  `publisher` varchar(200) NOT NULL,
  `release_year` int(11) NOT NULL,
  `price` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `games`
--

INSERT INTO `games` (`id`, `title`, `publisher`, `release_year`, `price`) VALUES
(1, 'The Legend of Zelda: Breath of the Wild', 'Nintendo', 2017, 59.99),
(2, 'Red Dead Redemption 2', 'Rockstar Games', 2018, 59.99),
(3, 'The Witcher 3: Wild Hunt', 'CD Projekt', 2015, 39.99),
(4, 'Super Mario Odyssey', 'Nintendo', 2017, 59.99),
(5, 'Minecraft', 'Mojang', 2011, 26.95),
(6, 'Cyberpunk 2077', 'CD Projekt', 2020, 59.99),
(7, 'God of War', 'Sony Interactive Entertainment', 2018, 39.99),
(8, 'Overwatch', 'Blizzard Entertainment', 2016, 39.99),
(9, 'Fortnite', 'Epic Games', 2017, 0),
(10, 'Grand Theft Auto V', 'Rockstar Games', 2013, 29.99),
(11, 'Dark Souls III', 'FromSoftware', 2016, 59.99),
(12, 'Hollow Knight', 'Team Cherry', 2017, 14.99),
(13, 'Animal Crossing: New Horizons', 'Nintendo', 2020, 59.99),
(14, 'DOOM Eternal', 'Bethesda Softworks', 2020, 59.99),
(15, 'Stardew Valley', 'ConcernedApe', 2016, 14.99);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `games`
--
ALTER TABLE `games`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `games`
--
ALTER TABLE `games`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
