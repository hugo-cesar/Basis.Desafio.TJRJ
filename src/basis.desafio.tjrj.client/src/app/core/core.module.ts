import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgGridModule } from 'ag-grid-angular';
import { SidenavComponent } from './sidenav/sidenav.component';
import { HomeComponent } from './home/home.component';
import { AuthorComponent } from './author/author.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ActionRenderer } from '../action-renderer/action-renderer.component';
import { SubjectComponent } from './subject/subject.component';
import { BookComponent } from './book/book.component';
import { BookFormComponent } from './book//book-form/book-form.component';
import { ReportComponent } from './report/report.component';

@NgModule({
  declarations: [
    SidenavComponent,
    HomeComponent,
    AuthorComponent,
    ActionRenderer,
    SubjectComponent,
    BookComponent,
    BookFormComponent,
    ReportComponent 
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    AgGridModule
  ],
  exports: [
    SidenavComponent,
    HomeComponent,
    AuthorComponent,

  ]
})
export class CoreModule { }
