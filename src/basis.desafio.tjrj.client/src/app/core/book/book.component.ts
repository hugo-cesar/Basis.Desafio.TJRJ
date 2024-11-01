import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { ColDef, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { FormBuilder } from '@angular/forms';
import { ActionRenderer } from '../../action-renderer/action-renderer.component';
import { Subject } from '../subject/subject.component';
import { Author } from '../author/author.component';
import { Router } from '@angular/router';

export interface PurchaseType {
  id: number;
  name: string;
  price: number;
}

export interface Book {
  id: number;
  title: string;
  publisher: string;
  edition: number;
  publicationYear: string;
  authors: Author[];
  subjects: Subject[];
  purchaseTypes: PurchaseType[];
}

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})

export class BookComponent implements OnInit {
  public books: Book[] = [];
  public authors: Author[] = [];
  public title = 'basis.desafio.tjrj.client';
  public showToast: boolean = false;
  public toastMessage: string = '';
  public toastTitle: string = '';
  public toastType: 'success' | 'error' = 'success';
  private gridApi: any;

  public columnDefs: ColDef[] = [
    { field: 'id', headerName: 'Código', sortable: true, filter: false, width: 120 },
    { field: 'title', headerName: 'Título', sortable: true, filter: 'agTextColumnFilter' },
    { field: 'publisher', headerName: 'Editora', sortable: true, filter: 'agTextColumnFilter' },
    { field: 'edition', headerName: 'Edição', sortable: true, filter: 'agTextColumnFilter', width: 130 },
    { field: 'publicationYear', headerName: 'Ano de Publicação', sortable: true, filter: 'agTextColumnFilter' },
    {
      field: 'authors',
      headerName: 'Autores',
      cellRenderer: (params: any) => {
        const authors = params.data?.authors;

        if (Array.isArray(authors) && authors.length > 0) {
          const items = authors
            .map((author: Author) => `<li>${author.name}</li>`)
            .join('');
          return `<ul style="padding-left: 20px; margin: 0;">${items}</ul>`;
        }
        return '-';
      },
      autoHeight: true
    },
    {
      field: 'subjects',
      headerName: 'Assuntos',
      cellRenderer: (params: any) => {
        const subjects = params.data?.subjects;

        if (Array.isArray(subjects) && subjects.length > 0) {
          const items = subjects
            .map((subject: Subject) => `<li>${subject.description}</li>`)
            .join('');
          return `<ul style="padding-left: 20px; margin: 0;">${items}</ul>`;
        }
        return '-';
      },
      autoHeight: true,
    },
    {
      field: 'purchaseTypes',
      headerName: 'Tipo Compra/Valor',
      cellRenderer: (params: any) => {
        const purchaseTypes = params.data?.purchaseTypes;

        if (Array.isArray(purchaseTypes) && purchaseTypes.length > 0) {
          const items = purchaseTypes
            .map((subject: PurchaseType) => `<li>${subject.name} - ${subject.price.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</li>`)
            .join('');
          return `<ul style="padding-left: 20px; margin: 0;">${items}</ul>`;
        }
        return '-';
      },
      autoHeight: true,
    },
    {
      headerName: 'Ações',
      cellRenderer: ActionRenderer,
      cellRendererParams: {
        context: { componentParent: this },
        isBookPage: true,
        onDelete: (bookId: number) => this.delete(bookId),
        onEdit: (bookId: number) => this.edit(bookId)
      },
      width: 300
    }
  ];

  public gridOptions: GridOptions = {
    pagination: true,
    paginationPageSize: 100,
    localeText: {
      page: 'Página',
      to: 'de',
      of: 'de',
      next: 'Próxima',
      previous: 'Anterior',
      pageSize: 'Tamanho da Página',
      noRowsToDisplay: 'Nenhum registro para exibir',
    },
  };

  constructor(private http: HttpClient, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.getBooks();
  }

  onGridReady(event: GridReadyEvent) {
    this.gridApi = event.api;
    this.gridApi.sizeColumnsToFit();
  }

  openToast(message: string, title: string, type: 'success' | 'error' = 'success') {
    this.toastMessage = message;
    this.toastTitle = title;
    this.toastType = type;
    this.showToast = true;

    setTimeout(() => {
      this.showToast = false;
    }, 3000);
  }

  closeToast() {
    this.showToast = false;
  }

  getBooks() {
    this.http.get<Book[]>('/books').subscribe(
      (result) => {
        this.books = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  delete(bookId: number) {
    if (confirm('Você tem certeza que deseja deletar este livro?')) {
      this.http.delete(`/books/${bookId}`).subscribe(
        () => {
          this.books = this.books.filter(book => book.id !== bookId);
          this.openToast('Livro deletado com sucesso!', 'Sucesso', 'success');
        },
        (error) => {
          this.openToast('Erro ao deletar livro. Tente novamente.', 'Erro', 'error');
        }
      );
    }
  }

  edit(bookId: number) {
    this.router.navigate(['/livros/editar', bookId]);
  }
}
