-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 13-Fev-2023 às 17:48
-- Versão do servidor: 10.4.25-MariaDB
-- versão do PHP: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `dbwebsis`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `autorização de viagem`
--

CREATE TABLE `autorização de viagem` (
  `Id` int(11) NOT NULL,
  `CurrentYear` varchar(4) NOT NULL,
  `CurrentDate` datetime(6) NOT NULL,
  `ClientName` varchar(80) NOT NULL,
  `SecretaryName` varchar(80) NOT NULL,
  `Office` varchar(60) NOT NULL,
  `Level` int(11) NOT NULL,
  `Code` int(11) NOT NULL,
  `Type` int(11) NOT NULL,
  `DepartureDate` datetime(6) NOT NULL,
  `DepartureTime` varchar(5) NOT NULL,
  `ArrivalDate` datetime(6) NOT NULL,
  `ArrivalTime` varchar(5) NOT NULL,
  `Accountability` datetime(6) NOT NULL,
  `OneWayTickets` int(11) NOT NULL,
  `ReturnTickets` int(11) NOT NULL,
  `Destiny` varchar(60) NOT NULL,
  `UG` varchar(8) NOT NULL,
  `UO` varchar(8) NOT NULL,
  `PA` varchar(8) NOT NULL,
  `Expanses` varchar(30) NOT NULL,
  `Font` int(11) NOT NULL,
  `FoodQuantity` int(11) NOT NULL,
  `HostingQuantity` int(11) NOT NULL,
  `FoodUnitaryValue` longtext NOT NULL,
  `HostingUnitaryValue` longtext NOT NULL,
  `FoodTotalValue` longtext NOT NULL,
  `HostingTotalValue` longtext NOT NULL,
  `ExpanseTotalValue` longtext NOT NULL,
  `Goal` varchar(300) NOT NULL,
  `SecretariesId` int(11) NOT NULL,
  `UsersId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `secretarias`
--

CREATE TABLE `secretarias` (
  `Id` int(11) NOT NULL,
  `Name` varchar(80) NOT NULL,
  `Acronym` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `secretarias`
--

INSERT INTO `secretarias` (`Id`, `Name`, `Acronym`) VALUES
(1, 'Secretaria Municipal de Administração', 'SEMAD');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `Id` int(11) NOT NULL,
  `Name` varchar(80) NOT NULL,
  `Login` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `CheckedPassword` varchar(50) NOT NULL,
  `Type` int(11) NOT NULL,
  `SecretariesId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuarios`
--

INSERT INTO `usuarios` (`Id`, `Name`, `Login`, `Password`, `CheckedPassword`, `Type`, `SecretariesId`) VALUES
(1, 'Administrator', 'admin', '21232f297a57a5a743894a0e4a801fc3', '21232f297a57a5a743894a0e4a801fc3', 1, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20230213162741_v10', '3.0.0');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `autorização de viagem`
--
ALTER TABLE `autorização de viagem`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Autorização de Viagem_SecretariesId` (`SecretariesId`),
  ADD KEY `IX_Autorização de Viagem_UsersId` (`UsersId`);

--
-- Índices para tabela `secretarias`
--
ALTER TABLE `secretarias`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Usuarios_SecretariesId` (`SecretariesId`);

--
-- Índices para tabela `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `autorização de viagem`
--
ALTER TABLE `autorização de viagem`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `secretarias`
--
ALTER TABLE `secretarias`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `autorização de viagem`
--
ALTER TABLE `autorização de viagem`
  ADD CONSTRAINT `FK_Autorização de Viagem_Secretarias_SecretariesId` FOREIGN KEY (`SecretariesId`) REFERENCES `secretarias` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Autorização de Viagem_Usuarios_UsersId` FOREIGN KEY (`UsersId`) REFERENCES `usuarios` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `FK_Usuarios_Secretarias_SecretariesId` FOREIGN KEY (`SecretariesId`) REFERENCES `secretarias` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
