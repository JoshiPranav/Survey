import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SurveyComponent } from './survey.component';
import { RouterTestingModule } from '@angular/router/testing';
import { QuestionComponent } from '../question/question.component';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('SurveyComponent', () => {
  let component: SurveyComponent;
  let questionComponent: QuestionComponent;
  let fixture: ComponentFixture<SurveyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        FormsModule,
        HttpClientTestingModule
      ],
      declarations: [ SurveyComponent, QuestionComponent ]
    })
    .compileComponents()
    .then(() => {
      fixture = TestBed.createComponent(SurveyComponent);
      component = fixture.componentInstance;
      fixture.detectChanges();
    })
    ;
  }));

  beforeEach(() => {
    
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
