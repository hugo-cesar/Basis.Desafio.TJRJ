import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionRenderer } from './action-renderer.component';

describe('ActionRendererComponent', () => {
  let component: ActionRenderer;
  let fixture: ComponentFixture<ActionRenderer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ActionRenderer]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ActionRenderer);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
