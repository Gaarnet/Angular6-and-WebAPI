import { Component, OnInit, Input } from '@angular/core';
import { Student } from '../student'
import { StudentService } from '../student.service'
import { StudentsComponent } from '../students/students.component';
import { Studentdatasource } from '../studentdatasource'
import { Course } from '../course';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import {ModelEditComponent} from '../model-edit/model-edit.component'

@Component({
  selector: 'app-studentdetails',
  templateUrl: './studentdetails.component.html',
  styleUrls: ['./studentdetails.component.scss']
})
export class StudentdetailsComponent implements OnInit {

  course: Course;
  closeResult: string;
  @Input('student') student: Student

  constructor(public service: StudentService, private modalService: NgbModal) { }

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }



  ngOnInit() { }

  onClickMe(id) {
    this.service.removeStudent(id).subscribe()
  }

}
