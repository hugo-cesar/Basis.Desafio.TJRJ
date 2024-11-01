import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './core/home/home.component';
import { AuthorComponent } from './core/author/author.component';
import { SubjectComponent } from './core/subject/subject.component';
import { BookComponent } from './core/book/book.component';
import { BookFormComponent } from './core/book/book-form/book-form.component';
import { ReportComponent } from './core/report/report.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'autores', component: AuthorComponent },
  { path: 'assuntos', component: SubjectComponent },
  { path: 'livros', component: BookComponent },
  { path: 'livros/cadastrar', component: BookFormComponent },
  { path: 'livros/editar/:id', component: BookFormComponent },
  { path: 'relatorios', component: ReportComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
