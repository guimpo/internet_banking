INSERT INTO tipo_transacao (id, descricao) VALUES (4, 'emprestimo');

ALTER TABLE `tipo_investimento_poupanca` ADD `valor_bloqueado` DOUBLE NOT NULL AFTER `id`;