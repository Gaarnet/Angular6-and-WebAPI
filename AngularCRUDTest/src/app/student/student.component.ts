import { Component, OnInit } from '@angular/core';
import { StudentService } from '../student.service'
import { Student } from '../student'
import { Observable } from 'rxjs'
import { ActivatedRoute } from '@angular/router'
import { StudentsDirective } from '../students.directive';


@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {

  student$: Student;
  constructor(private service: StudentService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => this.student$ = params.id)
  }

  ngOnInit() {
    this.service.getStudent(this.student$).subscribe((data: Student) => {
      this.student$ = data
      console.log(this.student$.courses)
    })
  }

}
