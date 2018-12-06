import { TestBed } from '@angular/core/testing';

import { TesouroPrefixadoLtnService } from './tesouro-prefixado-ltn.service';

describe('TesouroPrefixadoLtnService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TesouroPrefixadoLtnService = TestBed.get(TesouroPrefixadoLtnService);
    expect(service).toBeTruthy();
  });
});
