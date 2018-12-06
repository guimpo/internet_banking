import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TesouroPrefixadoLtnComponent } from './tesouro-prefixado-ltn.component';

describe('TesouroPrefixadoLtnComponent', () => {
  let component: TesouroPrefixadoLtnComponent;
  let fixture: ComponentFixture<TesouroPrefixadoLtnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TesouroPrefixadoLtnComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TesouroPrefixadoLtnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
