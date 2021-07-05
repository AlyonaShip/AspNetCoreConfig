import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditorDataComponent } from './editor-data.component';

describe('EditorDataComponent', () => {
  let component: EditorDataComponent;
  let fixture: ComponentFixture<EditorDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditorDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditorDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
