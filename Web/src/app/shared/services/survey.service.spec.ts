import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { SurveyService } from './survey.service';

describe('SurveyService', () => {
   beforeEach(() => TestBed.configureTestingModule({
    imports: [
        HttpClientTestingModule
      ]
  }));

  it('should be created', () => {
    const service: SurveyService = TestBed.get(SurveyService);
    expect(service).toBeTruthy();
  });
});
