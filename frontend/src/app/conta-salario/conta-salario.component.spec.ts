import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContaSalarioComponent } from './conta-salario.component';

describe('ContaSalarioComponent', () => {
  let component: ContaSalarioComponent;
  let fixture: ComponentFixture<ContaSalarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContaSalarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContaSalarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
