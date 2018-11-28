


--
-- Database: `banco`
--

create schema banco;
use banco;

-- --------------------------------------------------------

--
-- Estrutura da tabela `conta`
--

CREATE TABLE `conta` (
  `id` int(11) NOT NULL,
  `id_tipo_conta` int(11) NOT NULL,
  `id_pessoa` int(11) NOT NULL,
  `saldo` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `pessoa`
--

CREATE TABLE `pessoa` (
  `id` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipo_conta`
--

CREATE TABLE `tipo_conta` (
  `id` int(11) NOT NULL,
  `descricao` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
(1, 'debito'),
(2, 'credito');

-- --------------------------------------------------------

--
-- Estrutura da tabela `trasacao`
--

CREATE TABLE `trasacao` (
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
  
COMMIT;

CREATE TABLE if not exists `conta_contabil` (
  `id` int(11) AUTO_INCREMENT NOT NULL PRIMARY KEY,
  `pessoa_id` int(11),
  `produto_id` int(11),
  `data` date NOT NULL,
  `hora` time NOT NULL,
  `tipo_transacao_id` int(11),
  `saldo` float
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

ALTER TABLE `banco`.`conta_contabil` 
ADD CONSTRAINT `fk_conta_contabil_pessoa`
  FOREIGN KEY (`pessoa_id`)
  REFERENCES `banco`.`pessoa` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_conta_contabil_produto`
  FOREIGN KEY (`produto_id`)
  REFERENCES `banco`.`conta_salario` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_conta_contabil_tipo_transacao`
  FOREIGN KEY (`tipo_transacao_id`)
  REFERENCES `banco`.`tipo_transacao` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;