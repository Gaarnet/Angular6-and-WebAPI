import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient } from '@angular/common/http'
import { StudentComponent } from '../app/student/student.component';
import { StudentsComponent } from './students/students.component';
import { AddstudentComponent } from './addstudent/addstudent.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms'
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { PopperOptions } from 'popper.js'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StudentsDirective } from './students.directive';
import { StudentdetailsComponent } from './studentdetails/studentdetails.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ModelEditComponent } from './model-edit/model-edit.component';


@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    StudentsComponent,
    AddstudentComponent,
    StudentsDirective,
    StudentdetailsComponent,
    NavbarComponent,
    ModelEditComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgbModule.forRoot(),
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
