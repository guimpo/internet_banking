ALTER TABLE `tipo_investimento_selic` ADD `quantidade` INT NOT NULL AFTER `vencimento`;
INSERT INTO tipo_transacao (id, descricao) VALUES (4, 'emprestimo');
ALTER TABLE `investimento` ADD `status` BOOLEAN NOT NULL AFTER `valor`;

UPDATE `tipo_transacao` SET `descricao` = 'aplicação investimento' WHERE `tipo_transacao`.`id` = 3;
INSERT INTO `tipo_transacao` (`id`, `descricao`) VALUES (NULL, 'investimento_resgate');
UPDATE `tipo_transacao` SET `descricao` = 'resgate de investimento' WHERE `tipo_transacao`.`id` = 4;

ALTER TABLE `emprestimo` ADD garantia double DEFAULT NULL;
UPDATE `tipo_emprestimo` SET `juros_total` = 4.5, `juros_atraso` = 6 WHERE `id` = 1;
INSERT INTO `tipo_transacao` (`id`, `descricao`) VALUES (6, 'emprestimo');
