


--
-- Database: `banco`
--

CREATE schema IF NOT EXISTS banco;
USE banco;

-- --------------------------------------------------------

--
-- Estrutura da tabela `conta`
--

CREATE TABLE IF NOT EXISTS `conta` (
  `id` int(11) NOT NULL,
  `id_tipo_conta` int(11) NOT NULL,
  `id_pessoa` int(11) NOT NULL,
  `saldo` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `pessoa`
--

CREATE TABLE IF NOT EXISTS `pessoa` (
  `id` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipo_conta`
--

CREATE TABLE IF NOT EXISTS `tipo_conta` (
  `id` int(11) NOT NULL,
  `descricao` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipo_transacao`
--

CREATE TABLE IF NOT EXISTS `tipo_transacao` (
  `id` int(11) NOT NULL,
  `descricao` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tipo_transacao`
--

INSERT INTO `tipo_transacao` (`id`, `descricao`) VALUES
(1, 'debito'),
(2, 'credito');

-- --------------------------------------------------------

--
-- Estrutura da tabela `trasacao`
--

CREATE TABLE IF NOT EXISTS `trasacao` (
  `id` int(11) NOT NULL,
  `id_tipo_transacao` int(11) NOT NULL,
  `data` date NOT NULL,
  `hora` time NOT NULL,
  `valor` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `conta`
--
ALTER TABLE `conta`
  ADD KEY `id_tipo` (`id_tipo_conta`),
  ADD KEY `id_pessoa` (`id_pessoa`);

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
-- Indexes for table `tipo_transacao`
--
ALTER TABLE `tipo_transacao`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `trasacao`
--
ALTER TABLE `trasacao`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_transacao_tipo` (`id_tipo_transacao`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pessoa`
--
ALTER TABLE `pessoa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tipo_conta`
--
ALTER TABLE `tipo_conta`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tipo_transacao`
--
ALTER TABLE `tipo_transacao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `trasacao`
--
ALTER TABLE `trasacao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `conta`
--
ALTER TABLE `conta`
  ADD CONSTRAINT `fk_conta_pessoa` FOREIGN KEY (`id_pessoa`) REFERENCES `pessoa` (`id`),
  ADD CONSTRAINT `fk_conta_tipo` FOREIGN KEY (`id_tipo_conta`) REFERENCES `tipo_conta` (`id`);

--
-- Limitadores para a tabela `trasacao`
--
ALTER TABLE `trasacao`
  ADD CONSTRAINT `fk_transacao_tipo` FOREIGN KEY (`id_tipo_transacao`) REFERENCES `tipo_transacao` (`id`);
  
--
--  Estrutura da tabela `conta_cadastrada`
--
CREATE TABLE `conta_cadastrada` (
  `id` int primary key auto_increment,
  `id_conta` int NOT NULL,
  `descricao` varchar(200) NOT NULL,
  `numero_conta` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

ALTER TABLE `conta`ADD PRIMARY KEY (`id`);
ALTER TABLE `conta_cadastrada` ADD CONSTRAINT `fk_conta_id` FOREIGN KEY (`id_conta`) REFERENCES conta (id);

COMMIT;

select * from trasacao ;


INSERT INTO pessoa (id,nome )
  VALUES (2, "kao" );

    CREATE TABLE if not exists `conta_salario` (
  `id` int(11) AUTO_INCREMENT NOT NULL PRIMARY KEY,
  `numero` int(10),
  `agencia` varchar(10),
  `id_tipo_conta` int(11) NOT NULL,
  `id_pessoa` int(11) NOT NULL,
  `saldo` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

ALTER TABLE `conta_salario`
ADD CONSTRAINT `fk_conta_salario_conta_pessoa` FOREIGN KEY (`id_pessoa`) REFERENCES `pessoa` (`id`),
ADD CONSTRAINT `fk_conta_salario_conta_tipo` FOREIGN KEY (`id_tipo_conta`) REFERENCES `tipo_conta` (`id`);

INSERT INTO `banco`.`conta_salario` (`numero`, `agencia`, `id_tipo_conta`, `id_pessoa`, `saldo`)
VALUES ('123456', '654321', '2', '3', '130');

INSERT INTO `banco`.`pessoa` (`id`, `nome`) VALUES ('3', 'paulo');

INSERT INTO `banco`.`pessoa` (`id`, `nome`) VALUES ('4', 'alessandro');


INSERT INTO `banco`.`conta_salario` (`numero`, `agencia`, `id_tipo_conta`, `id_pessoa`, `saldo`)
VALUES ('123456', '654321', '2', '3', '200');