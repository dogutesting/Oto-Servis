-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 26 May 2024, 14:55:41
-- Sunucu sürümü: 10.4.28-MariaDB
-- PHP Sürümü: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `otoservis_veritabani`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `araclar`
--

CREATE TABLE `araclar` (
  `id` int(10) UNSIGNED NOT NULL,
  `aracSahibi` varchar(50) NOT NULL,
  `markasi` varchar(50) NOT NULL,
  `modeli` varchar(50) NOT NULL,
  `modelYili` varchar(10) NOT NULL,
  `kilometre` varchar(50) NOT NULL,
  `plakaNo` varchar(20) NOT NULL,
  `motorNo` varchar(100) NOT NULL,
  `sasiNo` varchar(100) NOT NULL,
  `ruhsatSahibi` varchar(50) NOT NULL,
  `kasaTipi` varchar(50) NOT NULL,
  `renk` varchar(50) NOT NULL,
  `motorHacmi` varchar(50) NOT NULL,
  `tescilTarihi` varchar(50) NOT NULL,
  `trafigeCikisTarihi` varchar(50) NOT NULL,
  `yakitCinsi` varchar(50) NOT NULL,
  `netAgirlik` varchar(50) NOT NULL,
  `sonBakimTarihi` varchar(50) NOT NULL,
  `garantiBitisTarihi` varchar(50) NOT NULL,
  `trafikSigortaBaslamaTarihi` varchar(50) NOT NULL,
  `trafikSigortaBitisTarihi` varchar(50) NOT NULL,
  `kaskoBaslamaTarihi` varchar(50) NOT NULL,
  `kaskoBitisTarihi` varchar(50) NOT NULL,
  `eklenmeTarihi` varchar(50) NOT NULL,
  `aracSahibiId` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `araclar`
--

INSERT INTO `araclar` (`id`, `aracSahibi`, `markasi`, `modeli`, `modelYili`, `kilometre`, `plakaNo`, `motorNo`, `sasiNo`, `ruhsatSahibi`, `kasaTipi`, `renk`, `motorHacmi`, `tescilTarihi`, `trafigeCikisTarihi`, `yakitCinsi`, `netAgirlik`, `sonBakimTarihi`, `garantiBitisTarihi`, `trafikSigortaBaslamaTarihi`, `trafikSigortaBitisTarihi`, `kaskoBaslamaTarihi`, `kaskoBitisTarihi`, `eklenmeTarihi`, `aracSahibiId`) VALUES
(1, 'Barış Gökdemir', 'Ford', 'Connect', '2010', '250000', '01BRS01', '', '', 'Barış Gökdemir', 'Pick Up', 'Gri', '', '', '', '', '', '', '', '', '', '', '', '29-03-2024', 0),
(2, 'Doğukan Sayın', 'Ford', 'Mustang', '2027', '1250', '01GOD881', '', '', 'Doğukan Sayın', 'Sedan', 'siyah', '', '', '', 'Benzin', '', '', '', '', '', '', '', '29-03-2024', 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `birimler`
--

CREATE TABLE `birimler` (
  `id` int(10) UNSIGNED NOT NULL,
  `birimTuru` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `birimler`
--

INSERT INTO `birimler` (`id`, `birimTuru`) VALUES
(1, 'adet'),
(2, 'metre'),
(3, 'litre'),
(4, 'top');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `cariler`
--

CREATE TABLE `cariler` (
  `id` int(10) UNSIGNED NOT NULL,
  `grup` varchar(100) NOT NULL,
  `unvan` varchar(100) NOT NULL,
  `telefon` int(20) NOT NULL,
  `eposta` varchar(100) NOT NULL,
  `adres` text NOT NULL,
  `notlar` text NOT NULL,
  `eklenmeTarihi` varchar(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `cariler`
--

INSERT INTO `cariler` (`id`, `grup`, `unvan`, `telefon`, `eposta`, `adres`, `notlar`, `eklenmeTarihi`) VALUES
(1, 'Müşteri', 'Doğukan Sayın', 2147483647, 'dgknsynnn@gmail.com', 'Onur Mahallesi', 'Programcı', '23-03-2024'),
(2, 'Müşteri', 'Barış Gökdemir', 2147483647, 'brsgkdmr@gmail.com', 'Onur', 'Parkeci', '29-03-2024');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `emirler`
--

CREATE TABLE `emirler` (
  `id` int(10) UNSIGNED NOT NULL,
  `kabulTarihi` varchar(50) NOT NULL,
  `kabulSaati` varchar(50) NOT NULL,
  `isEmriDurumu` varchar(20) NOT NULL,
  `marka` varchar(50) NOT NULL,
  `model` varchar(50) NOT NULL,
  `plakaNo` varchar(25) NOT NULL,
  `cari` varchar(100) NOT NULL,
  `ruhsatSahibi` varchar(100) NOT NULL,
  `girisKM` varchar(100) NOT NULL,
  `araciTeslimEden` varchar(100) NOT NULL,
  `araciTeslimAlan` varchar(100) NOT NULL,
  `sorumluPersonel` varchar(100) NOT NULL,
  `depoDurumu` varchar(100) NOT NULL,
  `musteriTalep` text NOT NULL,
  `personelDurum` text NOT NULL,
  `notlar` text NOT NULL,
  `aracId` int(10) NOT NULL,
  `cariId` int(10) UNSIGNED NOT NULL,
  `eklenmeTarihi` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `emirler`
--

INSERT INTO `emirler` (`id`, `kabulTarihi`, `kabulSaati`, `isEmriDurumu`, `marka`, `model`, `plakaNo`, `cari`, `ruhsatSahibi`, `girisKM`, `araciTeslimEden`, `araciTeslimAlan`, `sorumluPersonel`, `depoDurumu`, `musteriTalep`, `personelDurum`, `notlar`, `aracId`, `cariId`, `eklenmeTarihi`) VALUES
(1, '29 Mart 2024 Cuma', '11:44', 'Kapalı', 'Ford', 'Connect', '01BRS01', 'Barış Gökdemir', 'Barış Gökdemir', '250000', 'Barış Gökdemir', 'Çalışan 1', 'Çalışan 1', '1/2 yarısı dolu', '', '', 'Parkeci', 1, 2, '29-03-2024'),
(3, '29 Mart 2024 Cuma', '11:50', 'Açık', 'Ford', 'Connect', '01BRS01', 'Barış Gökdemir', 'Barış Gökdemir', '250000', 'Barış Gökdemir', 'Çalışan 1', 'Çalışan 1', '1/2', 'Yağ pompası yağ kaçırıyor321321', '', 'Parkeci', 1, 2, '29-03-2024'),
(4, '29 Mart 2024 Cuma', '13:18', 'Açık', 'Ford', 'Mustang', '01GOD881', 'Barış Gökdemir', 'Doğukan Sayın', '1250', 'Doğukan Sayın', 'Gökhan', 'Gökhan', '32132', '3213213', '', '', 2, 2, '29-03-2024');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `stocks`
--

CREATE TABLE `stocks` (
  `id` int(10) UNSIGNED NOT NULL,
  `marka` varchar(50) NOT NULL,
  `urunAdi` varchar(100) NOT NULL,
  `birim` varchar(100) NOT NULL,
  `miktar` varchar(100) NOT NULL,
  `fiyat` decimal(10,0) NOT NULL,
  `barkod` int(20) NOT NULL,
  `eklenmeTarihi` varchar(50) NOT NULL,
  `urunResim` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `stocks`
--

INSERT INTO `stocks` (`id`, `marka`, `urunAdi`, `birim`, `miktar`, `fiyat`, `barkod`, `eklenmeTarihi`, `urunResim`) VALUES
(3, 'Xenon', 'Xenon far lambası', 'adet', '100', 1500, 0, '29-03-2024', ''),
(4, 'Holan', 'Mustang dikiz aynası', 'adet', '150', 2000, 0, '29-03-2024', '');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `araclar`
--
ALTER TABLE `araclar`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `birimler`
--
ALTER TABLE `birimler`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `cariler`
--
ALTER TABLE `cariler`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `emirler`
--
ALTER TABLE `emirler`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `stocks`
--
ALTER TABLE `stocks`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `araclar`
--
ALTER TABLE `araclar`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `birimler`
--
ALTER TABLE `birimler`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `cariler`
--
ALTER TABLE `cariler`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Tablo için AUTO_INCREMENT değeri `emirler`
--
ALTER TABLE `emirler`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `stocks`
--
ALTER TABLE `stocks`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
