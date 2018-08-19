/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EphemeraComponent } from './ephemera.component';

describe('EphemeraComponent', () => {
  let component: EphemeraComponent;
  let fixture: ComponentFixture<EphemeraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EphemeraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EphemeraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
