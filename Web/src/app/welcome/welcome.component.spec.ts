import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { WelcomeComponent } from './welcome.component';
import { UserSurveyService } from '../shared/services/usersurvey.service';
import { NgForm, FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { MockUserSurveyService } from '../shared/mocks/mock';

describe('WelcomeComponent', () => {
  let component: WelcomeComponent;
  let fixture: ComponentFixture<WelcomeComponent>;
  let userSurveyService: UserSurveyService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule.withRoutes([]),
        FormsModule,
        HttpClientTestingModule
      ],
      declarations: [WelcomeComponent],
      providers: [
        { provide: UserSurveyService, useClass: MockUserSurveyService }
      ]
    })
    .compileComponents()
    .then(() => {
      fixture = TestBed.createComponent(WelcomeComponent);
      component = fixture.componentInstance;
      userSurveyService = TestBed.get(UserSurveyService);
      fixture.detectChanges();
    });
  }));

  beforeEach(() => {
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('form onsubmit should set nickname and survey id', () => {
    const testForm = {
      value: {
        nickname: 'John'
      }
    } as NgForm;

    component.onSubmit(testForm);

    expect(userSurveyService.UserSurvey.nickname).toBe('John');
    expect(userSurveyService.UserSurvey.surveyId).toBe(1);
  });
});
