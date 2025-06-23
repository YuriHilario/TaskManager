import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Entryview } from './entryview';

describe('Entryview', () => {
  let component: Entryview;
  let fixture: ComponentFixture<Entryview>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Entryview]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Entryview);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
