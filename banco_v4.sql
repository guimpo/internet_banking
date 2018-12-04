
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
(7, 233444556, '33', 1000, 3, 1);

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
(1, 100);

-- --------------------------------------------------------

--
-- Estrutura da tabela `conta_contabil_investimento_poupanca`
--

CREATE TABLE `conta_contabil_investimento_poupanca` (
  `id` int(11) NOT NULL,
  `valor` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
(1, 100);

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
(2, 'debito automático investimento ', 233444556, 7);

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
  `conta_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `emprestimo`
--

INSERT INTO `emprestimo` (`id`, `valor`, `data_solicitacao`, `parcelas`, `metodo_pagamento`, `tipo_emprestimo_pessoal_id`, `conta_contabil_emprestimo_id`, `conta_id`) VALUES
(5, 100, '2018-11-06', 0, 0, 1, 1, 7);

-- --------------------------------------------------------

--
-- Estrutura da tabela `investimento`
--

CREATE TABLE `investimento` (
  `id` int(11) NOT NULL,
  `data_aplicacao` date DEFAULT NULL,
  `valor` double DEFAULT NULL,
  `tipo_investimento_id` int(11) NOT NULL,
  `conta_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `investimento`
--

INSERT INTO `investimento` (`id`, `data_aplicacao`, `valor`, `tipo_investimento_id`, `conta_id`) VALUES
(1, '2018-11-30', 100, 1, 7),
(2, '2018-12-03', 200, 2, 7),
(3, '2018-12-04', 300, 2, 7),
(4, '2018-12-05', 400, 2, 7);

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
(1, '2018-11-30', NULL, 1, 100, 5);

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
(1, 'empréstimo pessoal', 0.6, 14);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipo_investimento`
--

CREATE TABLE `tipo_investimento` (
  `id` int(11) NOT NULL,
  `descricao` varchar(45) DEFAULT NULL,
  `liquidez` varchar(45) DEFAULT NULL,
  `rentabilidade` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tipo_investimento`
--

INSERT INTO `tipo_investimento` (`id`, `descricao`, `liquidez`, `rentabilidade`) VALUES
(1, 'poupança', 'D+30', 4.05),
(2, 'tesouto selic', 'D+1', 6.5);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipo_investimento_poupanca`
--

CREATE TABLE `tipo_investimento_poupanca` (
  `id` int(11) NOT NULL,
  `investimento_id` int(11) NOT NULL,
  `contacontabil_investimento_poupanca_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipo_investimento_selic`
--

CREATE TABLE `tipo_investimento_selic` (
  `id` int(11) NOT NULL,
  `investimento_id` int(11) NOT NULL,
  `vencimento` date NOT NULL,
  `conta_contabil_investimento_selic_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tipo_investimento_selic`
--

INSERT INTO `tipo_investimento_selic` (`id`, `investimento_id`, `vencimento`, `conta_contabil_investimento_selic_id`) VALUES
(1, 2, '2023-03-01', 1),
(2, 2, '2023-03-01', 1),
(3, 2, '2023-03-01', 1);

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
(3, 'investimento');

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
(8, '2018-11-01', '22:18:53', 1000, 2, 7),
(9, '2018-11-30', '13:18:53', 100, 3, 7);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `conta_contabil_investimento_poupanca`
--
ALTER TABLE `conta_contabil_investimento_poupanca`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `conta_contabil_investimento_selic`
--
ALTER TABLE `conta_contabil_investimento_selic`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `debito_automatico`
--
ALTER TABLE `debito_automatico`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `emprestimo`
--
ALTER TABLE `emprestimo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `investimento`
--
ALTER TABLE `investimento`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `parcela`
--
ALTER TABLE `parcela`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tipo_investimento_selic`
--
ALTER TABLE `tipo_investimento_selic`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tipo_transacao`
--
ALTER TABLE `tipo_transacao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `trasacao`
--
ALTER TABLE `trasacao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

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