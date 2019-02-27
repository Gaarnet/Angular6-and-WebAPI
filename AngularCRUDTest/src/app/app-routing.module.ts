import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentComponent } from '../app/student/student.component'
import { StudentsComponent } from '../app/students/students.component'
import { AddstudentComponent } from '../app/addstudent/addstudent.component'
import{ModelEditComponent} from '../app/model-edit/model-edit.component'

const routes: Routes = [
  {
    path: 'students',
    component: StudentsComponent
  },
  {
    path: 'student/:id',
    component: StudentComponent
  },
  {
    path: 'stutent/add/:id',
    component: AddstudentComponent
  },
  {
    path: 'students/stutent/update/:id',
    component: AddstudentComponent
  },
  {
    path:'students/stutent/modalUpdate/:id',
    component:ModelEditComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
