import { Component, OnInit, Input } from '@angular/core';
import { StudentService } from '../student.service'
import { Student } from '../student'
import { Observable } from 'rxjs'
import { Course } from '../course'
import { trigger, style, transition, animate, keyframes, query, stagger } from '@angular/animations'
import { ActivatedRoute } from '@angular/router'
import { identifierModuleUrl } from '@angular/compiler';
import { Studentdatasource } from '../studentdatasource'
import { StudentdetailsComponent } from '../studentdetails/studentdetails.component'


@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss'],
  animations: [
    trigger('listStagger', [
      transition('*<=>*', [
        query(':enter', [
          style({ opacity: 0, transform: 'translateY(-15px)' }),
          stagger('100ms',
            animate('550ms ease-out',
              style({ opacity: 1, transform: 'translateY(0px)' })))
        ], { optional: true }),
        query(':leave', animate('50ms', style({ opacity: 0 })), { optional: true })
      ])
    ])
  ]
})
export class StudentsComponent implements OnInit {

  id: object;
  pageCount: object;
  course$: Course[];
  studentDataSource: Studentdatasource;
  addStudent: Student;
  collapseHelper: object[]

  
  student: Student;

  constructor(private service: StudentService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => this.id = params.id)
  }

  
  onSubmit() {
    this.service.getStudent(-1).subscribe((data: Student) => {
      this.addStudent = data
      console.log(this.addStudent)
    })
  }

  ngOnInit() {
    this.service.getStudents(0).subscribe((data: Studentdatasource) => {
      this.studentDataSource = data;
    })
  }

  onSelectPage(page) {
    this.service.getStudents(page).subscribe((data: Studentdatasource) => {
      this.studentDataSource = data;

    })
  }
}
