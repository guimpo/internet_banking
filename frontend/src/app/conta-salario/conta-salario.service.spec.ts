import { TestBed } from '@angular/core/testing';

import { ContaSalarioService } from './conta-salario.service';

describe('ContaSalarioService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ContaSalarioService = TestBed.get(ContaSalarioService);
    expect(service).toBeTruthy();
  });
});
