--
-- Alterações necessárias para o empréstimo
--
ALTER TABLE `emprestimo` ADD garantia double DEFAULT NULL;
UPDATE `tipo_emprestimo` SET `juros_total` = 4.5, `juros_atraso` = 6 WHERE `id` = 1;
INSERT INTO `tipo_transacao` (`id`, `descricao`) VALUES (5, 'emprestimo');
UPDATE `investimento` SET `status` = 0 WHERE `id` = 27;
INSERT INTO `investimento` (`id`, `data_aplicacao`, `valor`, `tipo_investimento_id`, `conta_id`, `status`) VALUES (31, '2018-11-30', 500, 1, 7, false);