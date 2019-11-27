import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { UserSurveyService } from './usersurvey.service';

describe('UserserviceService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [
        HttpClientTestingModule
      ]
  }));

  it('should be created', () => {
    const service: UserSurveyService = TestBed.get(UserSurveyService);
    expect(service).toBeTruthy();
  });
});
