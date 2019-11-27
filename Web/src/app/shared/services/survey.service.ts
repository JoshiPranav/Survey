import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Survey } from '../entities/survey';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SurveyService {
  private endpoint = environment.baseUrl + 'survey/';
  public Survey: Survey;
  constructor(private http: HttpClient) { }

  getSurvey(surveyId: number): Observable<boolean> {
    return this.http.get(this.endpoint + surveyId)
      .pipe(
        map((data: any) => {
          this.Survey = data;
          return true;
        }));
  }
}
