import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Updatetask } from './updatetask';

describe('Updatetask', () => {
  let component: Updatetask;
  let fixture: ComponentFixture<Updatetask>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Updatetask]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Updatetask);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
