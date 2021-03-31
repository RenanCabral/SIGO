import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultingPanelComponent } from './consulting-panel.component';

describe('ConsultingPanelComponent', () => {
  let component: ConsultingPanelComponent;
  let fixture: ComponentFixture<ConsultingPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultingPanelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultingPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
