import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { HttpClient } from '@angular/common/http'
import { HttpHeaders } from '@angular/common/http'
import { Student } from './student';
import { Subject } from 'rxjs/Subject'
import 'rxjs/add/operator/map'
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class StudentService {

  private messageSource = new BehaviorSubject("Default message");
  currentMessage = this.messageSource.asObservable();

  public studentSubject = new Subject<any>();
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  getStudents(page) {
    return this.http.get("https://localhost:44361/api/student/students/" + page)
  }
  getStudent(studentId) {
    return this.http.get("https://localhost:44361/api/student/" + studentId)
  }
  postStudent(student: Student) {
    return this.http.post("https://localhost:44361/api/student", student, this.httpOptions)
  }
  updateStudent(student: Student) {
    return this.http.put("https://localhost:44361/api/student", student, this.httpOptions)
  }
  removeStudent(stundentId) {
    return this.http.delete("https://localhost:44361/api/student/" + stundentId)
  }
  changeMessage(message: string) {
    this.messageSource.next(message)
  }

}
