-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema banco
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema banco
-- -----------------------------------------------------

CREATE SCHEMA IF NOT EXISTS `banco`;
USE `banco` ;

-- -----------------------------------------------------
-- Table `banco`.`tipo_conta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`tipo_conta` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `banco`.`pessoa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`pessoa` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `banco`.`conta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`conta` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `numero` INT(10) NULL DEFAULT NULL,
  `agencia` VARCHAR(10) NULL DEFAULT NULL,
  `saldo` DOUBLE NOT NULL,
  `tipo_conta_id` INT(11) NOT NULL,
  `pessoa_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_conta_tipo_conta1_idx` (`tipo_conta_id` ASC) ,
  INDEX `fk_conta_pessoa1_idx` (`pessoa_id` ASC) ,
  CONSTRAINT `fk_conta_tipo_conta1`
    FOREIGN KEY (`tipo_conta_id`)
    REFERENCES `banco`.`tipo_conta` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_conta_pessoa1`
    FOREIGN KEY (`pessoa_id`)
    REFERENCES `banco`.`pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `banco`.`debito_automatico`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`debito_automatico` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(200) NULL,
  `numero_conta` INT NULL,
  `conta_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_debito_automatico_conta1_idx` (`conta_id` ASC) ,
  CONSTRAINT `fk_debito_automatico_conta1`
    FOREIGN KEY (`conta_id`)
    REFERENCES `banco`.`conta` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `banco`.`tipo_transacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`tipo_transacao` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `banco`.`trasacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`trasacao` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `data` DATE NOT NULL,
  `hora` TIME NOT NULL,
  `valor` DOUBLE NOT NULL,
  `tipo_transacao_id` INT(11) NOT NULL,
  `conta_id1` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_trasacao_tipo_transacao1_idx` (`tipo_transacao_id` ASC) ,
  INDEX `fk_trasacao_conta1_idx` (`conta_id1` ASC) ,
  CONSTRAINT `fk_trasacao_tipo_transacao1`
    FOREIGN KEY (`tipo_transacao_id`)
    REFERENCES `banco`.`tipo_transacao` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_trasacao_conta1`
    FOREIGN KEY (`conta_id1`)
    REFERENCES `banco`.`conta` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `banco`.`tipo_emprestimo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`tipo_emprestimo` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(45) NULL,
  `juros_total` DOUBLE NULL,
  `juros_atraso` DOUBLE NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `banco`.`conta_contabil_emprestimo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`conta_contabil_emprestimo` (
  `id` INT NOT NULL,
  `valor` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `banco`.`emprestimo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`emprestimo` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `valor` DOUBLE NULL,
  `data_solicitacao` DATE NULL,
  `tipo_emprestimo_pessoal_id` INT NOT NULL,
  `conta_contabil_emprestimo_id` INT NOT NULL,
  `conta_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_emprestimo_tipo_emprestimo_pessoal1_idx` (`tipo_emprestimo_pessoal_id` ASC) ,
  INDEX `fk_emprestimo_conta_contabil_emprestimo1_idx` (`conta_contabil_emprestimo_id` ASC) ,
  INDEX `fk_emprestimo_conta1_idx` (`conta_id` ASC) ,
  CONSTRAINT `fk_emprestimo_tipo_emprestimo_pessoal1`
    FOREIGN KEY (`tipo_emprestimo_pessoal_id`)
    REFERENCES `banco`.`tipo_emprestimo` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_emprestimo_conta_contabil_emprestimo1`
    FOREIGN KEY (`conta_contabil_emprestimo_id`)
    REFERENCES `banco`.`conta_contabil_emprestimo` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_emprestimo_conta1`
    FOREIGN KEY (`conta_id`)
    REFERENCES `banco`.`conta` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `banco`.`parcela`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`parcela` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `data_vencimento` DATE NULL,
  `data_pagamento` DATE NULL,
  `status` TINYINT NULL,
  `valor` DOUBLE NULL,
  `emprestimo_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_parcela_emprestimo1_idx` (`emprestimo_id` ASC) ,
  CONSTRAINT `fk_parcela_emprestimo1`
    FOREIGN KEY (`emprestimo_id`)
    REFERENCES `banco`.`emprestimo` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `banco`.`tipo_investimento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`tipo_investimento` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(45) NULL,
  `liquidez` VARCHAR(45) NULL,
  `rentabilidade` DOUBLE NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `banco`.`conta_contabil_investimento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`conta_contabil_investimento` (
  `id` INT NOT NULL,
  `valor` DOUBLE NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `banco`.`investimento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco`.`investimento` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `data_aplicacao` DATE NULL,
  `valor` DOUBLE NULL,
  `tipo_investimento_id` INT NOT NULL,
  `conta_contabil_investimento_id` INT NOT NULL,
  `conta_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_investimento_tipo_investimento1_idx` (`tipo_investimento_id` ASC) ,
  INDEX `fk_investimento_conta_contabil_investimento1_idx` (`conta_contabil_investimento_id` ASC) ,
  INDEX `fk_investimento_conta1_idx` (`conta_id` ASC) ,
  CONSTRAINT `fk_investimento_tipo_investimento1`
    FOREIGN KEY (`tipo_investimento_id`)
    REFERENCES `banco`.`tipo_investimento` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_investimento_conta_contabil_investimento1`
    FOREIGN KEY (`conta_contabil_investimento_id`)
    REFERENCES `banco`.`conta_contabil_investimento` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_investimento_conta1`
    FOREIGN KEY (`conta_id`)
    REFERENCES `banco`.`conta` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

INSERT INTO pessoa(id, nome) VALUES(1, 'Kao');
INSERT INTO tipo_conta(id, descricao) VALUES(1, 'conta corrente');
INSERT INTO tipo_transacao(id, descricao) VALUES(1, 'saque');
INSERT INTO tipo_transacao(id, descricao) VALUES(2, 'deposito');
INSERT INTO conta(id, numero, agencia, saldo, tipo_conta_id, pessoa_id) VALUES(1, 123, 456, 1000, 1, 1);

SELECT * FROM trasacao;
SELECT * FROM pessoa;

