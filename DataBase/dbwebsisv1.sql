-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 01-Fev-2023 às 03:16
-- Versão do servidor: 10.4.24-MariaDB
-- versão do PHP: 7.4.29

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
  `CurrentDate` varchar(12) NOT NULL,
  `ClientName` varchar(80) NOT NULL,
  `SecretaryName` varchar(80) NOT NULL,
  `Office` varchar(60) NOT NULL,
  `Level` int(11) NOT NULL,
  `Code` int(11) NOT NULL,
  `Type` int(11) NOT NULL,
  `DepartureDate` datetime(6) NOT NULL,
  `DepartureTime` varchar(12) NOT NULL,
  `ArrivalDate` datetime(6) NOT NULL,
  `ArrivalTime` varchar(12) NOT NULL,
  `Accountability` varchar(17) NOT NULL,
  `OneWayTickets` int(11) NOT NULL,
  `ReturnTickets` int(11) NOT NULL,
  `Destiny` varchar(60) NOT NULL,
  `UG` varchar(30) NOT NULL,
  `UO` varchar(30) NOT NULL,
  `PA` varchar(30) NOT NULL,
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
(1, 'Secretaria Municipal de Administração', 'SEMAD'),
(2, 'Secretaria Municipal de Agricultura', 'SEMAGRI'),
(3, 'Secretaria Municipal de Educação', 'SEMED'),
(4, 'Secretaria Municipal da Fazenda', 'SEFAZ'),
(5, 'Secretaria Municipal de Turismo', 'SECETUR'),
(6, 'Secretaria Municipal de Assistência Social', 'SEMAPS'),
(7, 'Secretaria Municipal da Saúde', 'SESAU'),
(8, 'Secretaria Municipal de Meio Ambiente', 'SEMEIA'),
(9, 'Secretaria Municipal de Obras', 'SEMOBS'),
(10, 'Secretaria Municipal de Planejamento', 'SEPLAN');

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
(1, 'Administrator', 'admin', '21232f297a57a5a743894a0e4a801fc3', '21232f297a57a5a743894a0e4a801fc3', 1, 1),
(2, 'Marcos Aurélio Silva', 'Marcos.Silva', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 1, 2),
(3, 'Joana Arruda de Oliveira', 'Joana.Oliveira', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 1, 3),
(4, 'Amilton Vieira de Souza', 'Amilton.Vieira', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 1, 4),
(5, 'Anna Caroline Ribeiro Vieira', 'Anna.Ribeiro', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 1, 5),
(6, 'Marcelo Batista Vespasiano', 'Marcelo.Batista', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 1, 6),
(7, 'Luana Cristina de Oliveira', 'Luana.Cristina', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 1, 7),
(8, 'João Fernando Alves do Nascimento', 'João.Alves', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 1, 8),
(9, 'Sarah Marilia Agostinho', 'Sarah.Agostinho', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 1, 9),
(10, 'Miquéias Stanford Salatiel', 'Miqueias.Salatiel', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 1, 10),
(11, 'Lidia Cristina Martins', 'Lidia.Martins', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 1, 1),
(12, 'Carlos Cabral de Assis', 'Carlos.Cabral', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 0, 2),
(13, 'Márcia Pimentel de Souza', 'Marcia.Pimentel', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 0, 3),
(14, 'Renata Coelho Rocha', 'Renata.Rocha', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 0, 4),
(15, 'Raimundo Elzo Fagundes Lontra', 'Raimundo.Elzo', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 0, 5),
(16, 'Pedro Henrrique Cardoso', 'Pedro.Henrrique', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 0, 6),
(17, 'Carol Viana da Conceição', 'Carol.Viana', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 0, 7),
(18, 'Mário Neto de Assis', 'Mario.Neto', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 0, 8),
(19, 'Neuza Cristina Mariles de Souza', 'Neuza.Souza', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 0, 9),
(20, 'Fátima de Castro Alves', 'Fatima.Castro', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 0, 10),
(21, 'Mauro Duarte Rocha', 'Mauro.Duarte', '25f9e794323b453885f5181f1b624d0b', '25f9e794323b453885f5181f1b624d0b', 0, 1);

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
('20230201014312_v11', '3.0.0');

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `secretarias`
--
ALTER TABLE `secretarias`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

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
