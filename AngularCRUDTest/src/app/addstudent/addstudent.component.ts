import { Component, OnInit } from '@angular/core';
import { StudentService } from '../student.service'
import { Student } from '../student'
import { Observable } from 'rxjs'
import { ActivatedRoute } from '@angular/router'
import { FormBuilder, FormGroup, FormControl } from '@angular/forms'
import { Router } from '@angular/router'
import { Course } from '../course';
import { CourseService } from '../course.service';
import { typeWithParameters } from '@angular/compiler/src/render3/util';

@Component({
  selector: 'app-addstudent',
  templateUrl: './addstudent.component.html',
  styleUrls: ['./addstudent.component.scss']
})

export class AddstudentComponent implements OnInit {
  student$: Student;
  studentId: number;
  buttonText: string = "Update";

  constructor(private service: StudentService, private formBuilder: FormBuilder, private router: Router, private courseService: CourseService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => this.studentId = params.id)
  }

  ngOnInit() {
    this.service.getStudent(this.studentId).subscribe((data: Student) => {
      this.student$ = data
    })

    if (this.studentId == -1) {
      this.buttonText = "Add"
    };
  }

  onClickMe() {
    this.service.postStudent(this.student$).subscribe();
  }
}
