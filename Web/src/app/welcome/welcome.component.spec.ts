import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { WelcomeComponent } from './welcome.component';
import { UserSurveyService } from '../shared/services/usersurvey.service';
import { NgForm, FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

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
      providers: [UserSurveyService]
    })
    .compileComponents();

    userSurveyService = TestBed.get(UserSurveyService);
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WelcomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('form onsubmit should set nickname', () => {
    const testForm = <NgForm>{
      value: {
        nickname: 'John'
      }
    };
    component.onSubmit(testForm);
    expect(userSurveyService.UserSurvey.nickname).toBe('John');
  });

  it('form onsubmit should set surveyId', () => {
    const testForm = <NgForm>{
      value: {
        nickname: 'John'
      }
    };
    component.onSubmit(testForm);
    expect(userSurveyService.UserSurvey.surveyId).toBe(1);
  });

  // it('form onsubmit should navigate to survey componenent', () => {
  //   const testForm = <NgForm>{
  //     value: {
  //       nickname: 'John'
  //     }
  //   };
  //   component.onSubmit(testForm);
  //   //const navigateSpy = spyOn(router, 'navigate');
  //   //expect(mockRouter.navigate).toHaveBeenCalledWith(['/survey/1']);
  //   expect(userSurveyService.UserSurvey.surveyId).toBe(1);
  // });
});
