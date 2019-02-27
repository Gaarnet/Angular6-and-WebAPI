import { Injectable } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import {HttpClient} from '@angular/common/http'
import {HttpHeaders} from '@angular/common/http'
import { Student } from './student';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http:HttpClient) { }
 

  getCourses(){
   return this.http.get("https://localhost:44361/api/Course")
  }

}
