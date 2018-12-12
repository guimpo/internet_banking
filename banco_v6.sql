
--
-- Database: `banco`
--

create database banco;
use banco;

-- --------------------------------------------------------

--
-- Estrutura da tabela `conta`
--

CREATE TABLE `conta` (
  `id` int(11) NOT NULL,
  `numero` int(10) DEFAULT NULL,
  `agencia` varchar(10) DEFAULT NULL,
  `saldo` double NOT NULL,
  `tipo_conta_id` int(11) NOT NULL,
  `pessoa_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `conta`
--

INSERT INTO `conta` (`id`, `numero`, `agencia`, `saldo`, `tipo_conta_id`, `pessoa_id`) VALUES
(7, 233444556, '33', 3151.0499999999997, 3, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `conta_contabil_emprestimo`
--

CREATE TABLE `conta_contabil_emprestimo` (
  `id` int(11) NOT NULL,
  `valor` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `conta_contabil_emprestimo`
--

INSERT INTO `conta_contabil_emprestimo` (`id`, `valor`) VALUES
(1, 100),
(2, -500),
(3, -1000),
(4, -500),
(5, -1000),
(6, -1000),
(7, -1000);

-- --------------------------------------------------------

--
-- Estrutura da tabela `conta_contabil_investimento_poupanca`
--

CREATE TABLE `conta_contabil_investimento_poupanca` (
  `id` int(11) NOT NULL,
  `valor` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `conta_contabil_investimento_poupanca`
--

INSERT INTO `conta_contabil_investimento_poupanca` (`id`, `valor`) VALUES
(1, 100),
(2, -50),
(3, -50),
(4, 200),
(5, -150),
(6, 50),
(7, 100),
(8, -100),
(9, -50),
(10, 100),
(11, 100),
(12, 50),
(13, 50),
(14, 300),
(15, -100),
(16, -50),
(17, 50),
(18, -50),
(19, -50),
(20, -50),
(21, -50),
(22, -100),
(23, -50),
(24, -150),
(25, 100),
(26, -50),
(27, -50),
(28, 50),
(29, 100),
(30, 50),
(31, 100),
(32, -50),
(33, 100),
(34, 150),
(35, 150),
(36, 100),
(37, 200),
(38, -100),
(39, -150);

-- --------------------------------------------------------

--
-- Estrutura da tabela `conta_contabil_investimento_selic`
--

CREATE TABLE `conta_contabil_investimento_selic` (
  `id` int(11) NOT NULL,
  `valor` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `conta_contabil_investimento_selic`
--

INSERT INTO `conta_contabil_investimento_selic` (`id`, `valor`) VALUES
(1, -82.78000000000007);

-- --------------------------------------------------------

--
-- Estrutura da tabela `debito_automatico`
--

CREATE TABLE `debito_automatico` (
  `id` int(11) NOT NULL,
  `descricao` varchar(200) DEFAULT NULL,
  `numero_conta` int(11) DEFAULT NULL,
  `conta_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `debito_automatico`
--

INSERT INTO `debito_automatico` (`id`, `descricao`, `numero_conta`, `conta_id`) VALUES
(3, 'luz', 987654, 7),
(4, 'Gás', 2312312, 7),
(5, 'água', 21341, 7),
(6, 'Pagamento de emprestimo pessoal', 123, 7);

-- --------------------------------------------------------

--
-- Estrutura da tabela `emprestimo`
--

CREATE TABLE `emprestimo` (
  `id` int(11) NOT NULL,
  `valor` double DEFAULT NULL,
  `data_solicitacao` date DEFAULT NULL,
  `parcelas` int(11) NOT NULL,
  `metodo_pagamento` int(11) NOT NULL,
  `tipo_emprestimo_pessoal_id` int(11) NOT NULL,
  `conta_contabil_emprestimo_id` int(11) NOT NULL,
  `conta_id` int(11) NOT NULL,
  `garantia` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `emprestimo`
--

INSERT INTO `emprestimo` (`id`, `valor`, `data_solicitacao`, `parcelas`, `metodo_pagamento`, `tipo_emprestimo_pessoal_id`, `conta_contabil_emprestimo_id`, `conta_id`, `garantia`) VALUES
(5, 100, '2018-11-06', 0, 0, 1, 1, 7, NULL),
(6, 1000, '2018-12-12', 12, 1, 1, 5, 7, 550),
(7, 1000, '2018-12-12', 12, 1, 1, 6, 7, 0),
(8, 1000, '2018-12-12', 5, 1, 1, 7, 7, 150);

-- --------------------------------------------------------

--
-- Estrutura da tabela `investimento`
--

CREATE TABLE `investimento` (
  `id` int(11) NOT NULL,
  `data_aplicacao` date DEFAULT NULL,
  `valor` double DEFAULT NULL,
  `status` tinyint(1) NOT NULL,
  `tipo_investimento_id` int(11) NOT NULL,
  `conta_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `investimento`
--

INSERT INTO `investimento` (`id`, `data_aplicacao`, `valor`, `status`, `tipo_investimento_id`, `conta_id`) VALUES
(31, '2018-11-30', 500, 1, 1, 7),
(33, '2018-12-11', 100, 0, 2, 7),
(34, '2018-12-11', 100, 0, 2, 7),
(35, '2018-12-11', 100, 0, 2, 7),
(36, '2018-12-11', 100, 0, 2, 7),
(37, '2018-12-11', 100, 0, 2, 7),
(38, '2018-12-11', 100, 0, 2, 7),
(39, '2018-12-11', 100, 0, 2, 7),
(40, '2018-12-11', 100, 0, 2, 7),
(41, '2018-12-11', 100, 0, 2, 7),
(42, '2018-12-11', 100, 0, 2, 7),
(43, '2018-12-11', 100, 0, 2, 7),
(44, '2018-12-11', 100, 0, 2, 7),
(45, '2018-12-11', 100, 0, 2, 7),
(46, '2018-12-11', 100, 0, 2, 7),
(47, '2018-12-11', 100, 0, 2, 7),
(48, '2018-12-11', 100, 0, 2, 7),
(49, '2018-12-11', 100, 0, 2, 7),
(50, '2018-12-11', 100, 0, 2, 7),
(51, '2018-12-11', 100, 0, 2, 7),
(52, '2018-12-11', 100, 0, 2, 7),
(53, '2018-12-11', 100, 0, 2, 7),
(54, '2018-12-11', 100, 1, 2, 7),
(55, '2018-12-11', 100, 1, 2, 7),
(56, '2018-12-11', 100, 1, 2, 7),
(57, '2018-12-11', 100, 1, 2, 7),
(58, '2018-12-11', 100, 1, 2, 7),
(59, '2018-12-11', 100, 1, 2, 7),
(60, '2018-12-11', 100, 1, 2, 7),
(61, '2018-12-11', 100, 1, 2, 7),
(62, '2018-12-11', 100, 1, 2, 7),
(63, '2018-12-12', 200, 1, 1, 7),
(64, '2018-12-12', -150, 1, 1, 7),
(65, '2018-12-12', 50, 1, 1, 7),
(66, '2018-12-12', 100, 1, 1, 7),
(67, '2018-12-12', -100, 1, 1, 7),
(68, '2018-12-12', -50, 1, 1, 7),
(69, '2018-12-12', 100, 1, 1, 7),
(70, '2018-12-12', 100, 1, 1, 7),
(71, '2018-12-12', 50, 1, 1, 7),
(72, '2018-12-12', 50, 1, 1, 7),
(73, '2018-12-12', 300, 1, 1, 7),
(74, '2018-12-12', -100, 1, 1, 7),
(75, '2018-12-12', -50, 1, 1, 7),
(76, '2018-12-12', 50, 1, 1, 7),
(77, '2018-12-12', -50, 1, 1, 7),
(78, '2018-12-12', -50, 1, 1, 7),
(79, '2018-12-12', -50, 1, 1, 7),
(80, '2018-12-12', -50, 1, 1, 7),
(81, '2018-12-12', -100, 1, 1, 7),
(82, '2018-12-12', -50, 1, 1, 7),
(83, '2018-12-12', -150, 1, 1, 7),
(84, '2018-12-12', 100, 1, 1, 7),
(85, '2018-12-12', -50, 1, 1, 7),
(86, '2018-12-12', -50, 1, 1, 7),
(87, '2018-12-12', 50, 1, 1, 7),
(88, '2018-12-12', 100, 1, 1, 7),
(89, '2018-12-12', 50, 0, 1, 7),
(90, '2018-12-12', 100, 1, 2, 7),
(91, '2018-12-12', 100, 0, 2, 7),
(92, '2018-12-12', 100, 0, 1, 7),
(93, '2018-12-12', -50, 0, 1, 7),
(94, '2018-12-12', 100, 0, 1, 7),
(95, '2018-12-12', 150, 0, 1, 7),
(96, '2018-12-12', 150, 0, 1, 7),
(97, '2018-12-12', 100, 0, 1, 7),
(98, '2018-12-12', 200, 0, 1, 7),
(99, '2018-12-12', -100, 0, 1, 7),
(100, '2018-12-12', -150, 0, 1, 7);

-- --------------------------------------------------------

--
-- Estrutura da tabela `parcela`
--

CREATE TABLE `parcela` (
  `id` int(11) NOT NULL,
  `data_vencimento` date DEFAULT NULL,
  `data_pagamento` date DEFAULT NULL,
  `status` tinyint(4) DEFAULT NULL,
  `valor` double DEFAULT NULL,
  `emprestimo_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `parcela`
--

INSERT INTO `parcela` (`id`, `data_vencimento`, `data_pagamento`, `status`, `valor`, `emprestimo_id`) VALUES
(1, '2018-11-30', NULL, 1, 100, 5),
(2, '2019-01-12', NULL, 0, 85.70833333333333, 6),
(3, '2019-02-12', NULL, 0, 85.70833333333333, 6),
(4, '2019-03-12', NULL, 0, 85.70833333333333, 6),
(5, '2019-04-12', NULL, 0, 85.70833333333333, 6),
(6, '2019-05-12', NULL, 0, 85.70833333333333, 6),
(7, '2019-06-12', NULL, 0, 85.70833333333333, 6),
(8, '2019-07-12', NULL, 0, 85.70833333333333, 6),
(9, '2019-08-12', NULL, 0, 85.70833333333333, 6),
(10, '2019-09-12', NULL, 0, 85.70833333333333, 6),
(11, '2019-10-12', NULL, 0, 85.70833333333333, 6),
(12, '2019-11-12', NULL, 0, 85.70833333333333, 6),
(13, '2019-12-12', NULL, 0, 85.70833333333333, 6),
(14, '2019-01-12', NULL, 0, 87.08333333333333, 7),
(15, '2019-02-12', NULL, 0, 87.08333333333333, 7),
(16, '2019-03-12', NULL, 0, 87.08333333333333, 7),
(17, '2019-04-12', NULL, 0, 87.08333333333333, 7),
(18, '2019-05-12', NULL, 0, 87.08333333333333, 7),
(19, '2019-06-12', NULL, 0, 87.08333333333333, 7),
(20, '2019-07-12', NULL, 0, 87.08333333333333, 7),
(21, '2019-08-12', NULL, 0, 87.08333333333333, 7),
(22, '2019-09-12', NULL, 0, 87.08333333333333, 7),
(23, '2019-10-12', NULL, 0, 87.08333333333333, 7),
(24, '2019-11-12', NULL, 0, 87.08333333333333, 7),
(25, '2019-12-12', NULL, 0, 87.08333333333333, 7),
(26, '2019-01-12', NULL, 0, 208.1, 8),
(27, '2019-02-12', NULL, 0, 208.1, 8),
(28, '2019-03-12', NULL, 0, 208.1, 8),
(29, '2019-04-12', NULL, 0, 208.1, 8),
(30, '2019-05-12', NULL, 0, 208.1, 8);

-- --------------------------------------------------------

--
-- Estrutura da tabela `pessoa`
--

CREATE TABLE `pessoa` (
  `id` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `pessoa`
--

INSERT INTO `pessoa` (`id`, `nome`) VALUES
(1, 'Epaminondas da silva');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipo_conta`
--

CREATE TABLE `tipo_conta` (
  `id` int(11) NOT NULL,
  `descricao` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tipo_conta`
--

INSERT INTO `tipo_conta` (`id`, `descricao`) VALUES
(3, 'conta corrente');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipo_emprestimo`
--

CREATE TABLE `tipo_emprestimo` (
  `id` int(11) NOT NULL,
  `descricao` varchar(45) DEFAULT NULL,
  `juros_total` double DEFAULT NULL,
  `juros_atraso` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tipo_emprestimo`
--

INSERT INTO `tipo_emprestimo` (`id`, `descricao`, `juros_total`, `juros_atraso`) VALUES
(1, 'empréstimo pessoal', 4.5, 6);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipo_investimento`
--

CREATE TABLE `tipo_investimento` (
  `id` int(11) NOT NULL,
  `descricao` varchar(45) DEFAULT NULL,
  `liquidez` varchar(45) DEFAULT NULL,
  `rentabilidade` double DEFAULT NULL,
  `taxa_administracao` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tipo_investimento`
--

INSERT INTO `tipo_investimento` (`id`, `descricao`, `liquidez`, `rentabilidade`, `taxa_administracao`) VALUES
(1, 'poupança', 'D+30', 4.05, 0),
(2, 'tesouto selic 2023', 'D+1', 6.4, 0.3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipo_investimento_poupanca`
--

CREATE TABLE `tipo_investimento_poupanca` (
  `id` int(11) NOT NULL,
  `valor_bloqueado` double NOT NULL,
  `investimento_id` int(11) NOT NULL,
  `contacontabil_investimento_poupanca_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tipo_investimento_poupanca`
--

INSERT INTO `tipo_investimento_poupanca` (`id`, `valor_bloqueado`, `investimento_id`, `contacontabil_investimento_poupanca_id`) VALUES
(1, 0, 63, 4),
(2, 0, 64, 5),
(3, 0, 65, 6),
(4, 0, 66, 7),
(5, 0, 67, 8),
(6, 0, 68, 9),
(7, 0, 69, 10),
(8, 0, 70, 11),
(9, 0, 71, 12),
(10, 0, 72, 13),
(11, 0, 73, 14),
(12, 0, 74, 15),
(13, 0, 75, 16),
(14, 0, 76, 17),
(15, 0, 77, 18),
(16, 0, 78, 19),
(17, 0, 79, 20),
(18, 0, 80, 21),
(19, 0, 81, 22),
(20, 0, 82, 23),
(21, 0, 83, 24),
(22, 0, 84, 25),
(23, 0, 85, 26),
(24, 0, 86, 27),
(25, 0, 87, 28),
(26, 0, 88, 29),
(27, 0, 89, 30),
(28, 0, 92, 31),
(29, 0, 93, 32),
(30, 0, 94, 33),
(31, 0, 95, 34),
(32, 0, 96, 35),
(33, 0, 97, 36),
(34, 0, 98, 37),
(35, 0, 99, 38),
(36, 0, 100, 39);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipo_investimento_selic`
--

CREATE TABLE `tipo_investimento_selic` (
  `id` int(11) NOT NULL,
  `investimento_id` int(11) NOT NULL,
  `vencimento` date NOT NULL,
  `quantidade` int(11) NOT NULL,
  `conta_contabil_investimento_selic_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tipo_investimento_selic`
--

INSERT INTO `tipo_investimento_selic` (`id`, `investimento_id`, `vencimento`, `quantidade`, `conta_contabil_investimento_selic_id`) VALUES
(3, 33, '2023-03-01', 1, 1),
(4, 34, '2023-03-01', 1, 1),
(5, 35, '2023-03-01', 1, 1),
(6, 36, '2023-03-01', 1, 1),
(7, 37, '2023-03-01', 1, 1),
(8, 38, '2023-03-01', 1, 1),
(9, 39, '2023-03-01', 1, 1),
(10, 40, '2023-03-01', 1, 1),
(11, 41, '2023-03-01', 1, 1),
(12, 42, '2023-03-01', 1, 1),
(13, 43, '2023-03-01', 1, 1),
(14, 44, '2023-03-01', 1, 1),
(15, 45, '2023-03-01', 1, 1),
(16, 46, '2023-03-01', 1, 1),
(17, 47, '2023-03-01', 1, 1),
(18, 48, '2023-03-01', 1, 1),
(19, 49, '2023-03-01', 1, 1),
(20, 50, '2023-03-01', 1, 1),
(21, 51, '2023-03-01', 1, 1),
(22, 52, '2023-03-01', 1, 1),
(23, 53, '2023-03-01', 1, 1),
(24, 54, '2023-03-01', 1, 1),
(25, 55, '2023-03-01', 1, 1),
(26, 56, '2023-03-01', 1, 1),
(27, 57, '2023-03-01', 1, 1),
(28, 58, '2023-03-01', 1, 1),
(29, 59, '2023-03-01', 1, 1),
(30, 60, '2023-03-01', 1, 1),
(31, 61, '2023-03-01', 1, 1),
(32, 62, '2023-03-01', 1, 1),
(33, 90, '2023-03-01', 1, 1),
(34, 91, '2023-03-01', 1, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipo_transacao`
--

CREATE TABLE `tipo_transacao` (
  `id` int(11) NOT NULL,
  `descricao` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tipo_transacao`
--

INSERT INTO `tipo_transacao` (`id`, `descricao`) VALUES
(1, 'saque '),
(2, 'deposito'),
(3, 'aplicação investimento'),
(4, 'resgate de investimento'),
(5, 'emprestimo');

-- --------------------------------------------------------

--
-- Estrutura da tabela `trasacao`
--

CREATE TABLE `trasacao` (
  `id` int(11) NOT NULL,
  `data` date NOT NULL,
  `hora` time NOT NULL,
  `valor` double NOT NULL,
  `tipo_transacao_id` int(11) NOT NULL,
  `conta_id1` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `trasacao`
--

INSERT INTO `trasacao` (`id`, `data`, `hora`, `valor`, `tipo_transacao_id`, `conta_id1`) VALUES
(1, '2018-12-11', '15:57:21', 100, 3, 7),
(2, '2018-12-11', '15:57:38', 100, 4, 7),
(3, '2018-12-11', '15:57:55', 800, 3, 7),
(4, '2018-12-11', '16:10:38', 100, 3, 7),
(5, '2018-12-11', '16:14:47', 300, 3, 7),
(6, '2018-12-11', '16:16:18', 100, 4, 7),
(7, '2018-12-11', '16:19:01', 100, 4, 7),
(8, '2018-12-11', '16:19:19', 100, 3, 7),
(9, '2018-12-11', '16:19:35', 300, 3, 7),
(10, '2018-12-11', '16:19:49', 600, 4, 7),
(11, '2018-12-11', '16:20:09', 900, 3, 7),
(12, '2018-12-11', '16:20:52', 900, 4, 7),
(13, '2018-12-11', '16:30:26', 100, 3, 7),
(14, '2018-12-11', '16:55:32', 300, 3, 7),
(15, '2018-12-11', '16:56:02', 400, 4, 7),
(16, '2018-12-11', '16:56:23', 900, 3, 7),
(17, '2018-12-12', '09:27:38', 1000, 2, 7),
(18, '2018-12-12', '09:28:19', 200, 3, 7),
(19, '2018-12-12', '09:28:31', 150, 2, 7),
(20, '2018-12-12', '09:28:39', 50, 3, 7),
(21, '2018-12-12', '09:28:52', 100, 3, 7),
(22, '2018-12-12', '09:29:02', 100, 2, 7),
(23, '2018-12-12', '09:29:12', 50, 2, 7),
(26, '2018-12-12', '09:41:29', 1000, 5, 7),
(27, '2018-12-12', '09:42:12', 100, 3, 7),
(28, '2018-12-12', '09:45:44', 100, 3, 7),
(29, '2018-12-12', '09:45:51', 50, 3, 7),
(30, '2018-12-12', '09:45:59', 50, 3, 7),
(31, '2018-12-12', '09:46:14', 300, 3, 7),
(32, '2018-12-12', '09:46:26', 100, 2, 7),
(33, '2018-12-12', '09:46:33', 50, 2, 7),
(34, '2018-12-12', '09:46:41', 50, 3, 7),
(35, '2018-12-12', '09:46:51', 50, 2, 7),
(36, '2018-12-12', '09:46:58', 50, 2, 7),
(37, '2018-12-12', '09:47:04', 50, 2, 7),
(38, '2018-12-12', '09:47:10', 50, 2, 7),
(39, '2018-12-12', '09:47:16', 100, 2, 7),
(40, '2018-12-12', '09:53:10', 50, 2, 7),
(41, '2018-12-12', '09:53:19', 150, 2, 7),
(42, '2018-12-12', '09:53:27', 100, 3, 7),
(43, '2018-12-12', '09:53:33', 50, 2, 7),
(44, '2018-12-12', '09:54:31', 50, 2, 7),
(45, '2018-12-12', '09:54:53', 1000, 5, 7),
(46, '2018-12-12', '09:55:10', 50, 3, 7),
(47, '2018-12-12', '09:55:18', 100, 3, 7),
(48, '2018-12-12', '09:55:50', 1000, 5, 7),
(49, '2018-12-12', '09:56:43', 50, 3, 7),
(50, '2018-12-12', '10:11:07', 200, 3, 7),
(51, '2018-12-12', '10:11:15', 100, 4, 7),
(52, '2018-12-12', '10:11:31', 100, 3, 7),
(53, '2018-12-12', '10:11:39', 50, 2, 7),
(54, '2018-12-12', '10:11:46', 100, 3, 7),
(55, '2018-12-12', '10:11:56', 150, 3, 7),
(56, '2018-12-12', '10:12:28', 150, 3, 7),
(57, '2018-12-12', '10:14:03', 100, 3, 7),
(58, '2018-12-12', '10:14:11', 200, 3, 7),
(59, '2018-12-12', '10:14:17', 100, 2, 7),
(60, '2018-12-12', '10:14:24', 150, 2, 7);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `conta`
--
ALTER TABLE `conta`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_conta_tipo_conta1_idx` (`tipo_conta_id`),
  ADD KEY `fk_conta_pessoa1_idx` (`pessoa_id`);

--
-- Indexes for table `conta_contabil_emprestimo`
--
ALTER TABLE `conta_contabil_emprestimo`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `conta_contabil_investimento_poupanca`
--
ALTER TABLE `conta_contabil_investimento_poupanca`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `conta_contabil_investimento_selic`
--
ALTER TABLE `conta_contabil_investimento_selic`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `debito_automatico`
--
ALTER TABLE `debito_automatico`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_debito_automatico_conta1_idx` (`conta_id`);

--
-- Indexes for table `emprestimo`
--
ALTER TABLE `emprestimo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_emprestimo_tipo_emprestimo_pessoal1_idx` (`tipo_emprestimo_pessoal_id`),
  ADD KEY `fk_emprestimo_conta_contabil_emprestimo1_idx` (`conta_contabil_emprestimo_id`),
  ADD KEY `fk_emprestimo_conta1_idx` (`conta_id`);

--
-- Indexes for table `investimento`
--
ALTER TABLE `investimento`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_investimento_tipo_investimento1_idx` (`tipo_investimento_id`),
  ADD KEY `fk_investimento_conta1_idx` (`conta_id`);

--
-- Indexes for table `parcela`
--
ALTER TABLE `parcela`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_parcela_emprestimo1_idx` (`emprestimo_id`);

--
-- Indexes for table `pessoa`
--
ALTER TABLE `pessoa`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tipo_conta`
--
ALTER TABLE `tipo_conta`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tipo_emprestimo`
--
ALTER TABLE `tipo_emprestimo`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tipo_investimento`
--
ALTER TABLE `tipo_investimento`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tipo_investimento_poupanca`
--
ALTER TABLE `tipo_investimento_poupanca`
  ADD PRIMARY KEY (`id`),
  ADD KEY `investimento_id` (`investimento_id`),
  ADD KEY `contacontabil_investimento_poupanca_id` (`contacontabil_investimento_poupanca_id`);

--
-- Indexes for table `tipo_investimento_selic`
--
ALTER TABLE `tipo_investimento_selic`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_investimentoSelic_investimento` (`investimento_id`),
  ADD KEY `conta_contabil_investimento_selic` (`conta_contabil_investimento_selic_id`);

--
-- Indexes for table `tipo_transacao`
--
ALTER TABLE `tipo_transacao`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `trasacao`
--
ALTER TABLE `trasacao`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_trasacao_tipo_transacao1_idx` (`tipo_transacao_id`),
  ADD KEY `fk_trasacao_conta1_idx` (`conta_id1`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `conta`
--
ALTER TABLE `conta`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `conta_contabil_emprestimo`
--
ALTER TABLE `conta_contabil_emprestimo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `conta_contabil_investimento_poupanca`
--
ALTER TABLE `conta_contabil_investimento_poupanca`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `conta_contabil_investimento_selic`
--
ALTER TABLE `conta_contabil_investimento_selic`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `debito_automatico`
--
ALTER TABLE `debito_automatico`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `emprestimo`
--
ALTER TABLE `emprestimo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `investimento`
--
ALTER TABLE `investimento`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;

--
-- AUTO_INCREMENT for table `parcela`
--
ALTER TABLE `parcela`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `pessoa`
--
ALTER TABLE `pessoa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tipo_conta`
--
ALTER TABLE `tipo_conta`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tipo_emprestimo`
--
ALTER TABLE `tipo_emprestimo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tipo_investimento`
--
ALTER TABLE `tipo_investimento`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tipo_investimento_poupanca`
--
ALTER TABLE `tipo_investimento_poupanca`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `tipo_investimento_selic`
--
ALTER TABLE `tipo_investimento_selic`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `tipo_transacao`
--
ALTER TABLE `tipo_transacao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `trasacao`
--
ALTER TABLE `trasacao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `conta`
--
ALTER TABLE `conta`
  ADD CONSTRAINT `fk_conta_pessoa1` FOREIGN KEY (`pessoa_id`) REFERENCES `pessoa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_conta_tipo_conta1` FOREIGN KEY (`tipo_conta_id`) REFERENCES `tipo_conta` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `debito_automatico`
--
ALTER TABLE `debito_automatico`
  ADD CONSTRAINT `fk_debito_automatico_conta1` FOREIGN KEY (`conta_id`) REFERENCES `conta` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `emprestimo`
--
ALTER TABLE `emprestimo`
  ADD CONSTRAINT `fk_emprestimo_conta1` FOREIGN KEY (`conta_id`) REFERENCES `conta` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_emprestimo_emprestimo` FOREIGN KEY (`conta_contabil_emprestimo_id`) REFERENCES `conta_contabil_emprestimo` (`id`),
  ADD CONSTRAINT `fk_emprestimo_tipo_emprestimo_pessoal1` FOREIGN KEY (`tipo_emprestimo_pessoal_id`) REFERENCES `tipo_emprestimo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `investimento`
--
ALTER TABLE `investimento`
  ADD CONSTRAINT `fk_investimento_conta` FOREIGN KEY (`conta_id`) REFERENCES `conta` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_investimento_tipo_investimento` FOREIGN KEY (`tipo_investimento_id`) REFERENCES `tipo_investimento` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `parcela`
--
ALTER TABLE `parcela`
  ADD CONSTRAINT `fk_parcela_emprestimo1` FOREIGN KEY (`emprestimo_id`) REFERENCES `emprestimo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `tipo_investimento_poupanca`
--
ALTER TABLE `tipo_investimento_poupanca`
  ADD CONSTRAINT `fk_investimento_conta_contabil_investimento_poupanca` FOREIGN KEY (`contacontabil_investimento_poupanca_id`) REFERENCES `conta_contabil_investimento_poupanca` (`id`),
  ADD CONSTRAINT `fk_investimento_tipo` FOREIGN KEY (`investimento_id`) REFERENCES `investimento` (`id`);

--
-- Limitadores para a tabela `tipo_investimento_selic`
--
ALTER TABLE `tipo_investimento_selic`
  ADD CONSTRAINT `fk_investimentoSelic_investimento` FOREIGN KEY (`investimento_id`) REFERENCES `investimento` (`id`),
  ADD CONSTRAINT `fk_investimento_conta_contabil_investimento_selic` FOREIGN KEY (`conta_contabil_investimento_selic_id`) REFERENCES `conta_contabil_investimento_selic` (`id`);

--
-- Limitadores para a tabela `trasacao`
--
ALTER TABLE `trasacao`
  ADD CONSTRAINT `fk_trasacao_conta1` FOREIGN KEY (`conta_id1`) REFERENCES `conta` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_trasacao_tipo_transacao1` FOREIGN KEY (`tipo_transacao_id`) REFERENCES `tipo_transacao` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;




COMMIT;