ALTER TABLE `tipo_investimento_selic` ADD `quantidade` INT NOT NULL AFTER `vencimento`;
INSERT INTO tipo_transacao (id, descricao) VALUES (4, 'emprestimo');