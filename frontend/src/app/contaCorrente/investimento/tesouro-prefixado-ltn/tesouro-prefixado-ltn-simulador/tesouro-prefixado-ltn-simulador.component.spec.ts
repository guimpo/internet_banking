import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TesouroPrefixadoLtnSimuladorComponent } from './tesouro-prefixado-ltn-simulador.component';

describe('TesouroPrefixadoLtnSimuladorComponent', () => {
  let component: TesouroPrefixadoLtnSimuladorComponent;
  let fixture: ComponentFixture<TesouroPrefixadoLtnSimuladorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TesouroPrefixadoLtnSimuladorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TesouroPrefixadoLtnSimuladorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
