import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { ColDef, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActionRenderer } from '../../action-renderer/action-renderer.component';

export interface Author {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css'],
})
export class AuthorComponent implements OnInit {
  public authors: Author[] = [];
  public authorForm: FormGroup;
  public title = 'basis.desafio.tjrj.client';
  public showToast: boolean = false;
  public toastMessage: string = '';
  public toastTitle: string = '';
  public toastType: 'success' | 'error' = 'success';
  private gridApi: any;
  private originalValue: string | null = null;
  private isUpdating = false;

  public columnDefs: ColDef[] = [
    { field: 'id', headerName: 'Código', sortable: true, filter: false },
    { field: 'name', headerName: 'Nome', sortable: true, filter: 'agTextColumnFilter', editable: true },
    {
      headerName: 'Ações',
      cellRenderer: ActionRenderer,
      cellRendererParams: {
        context: { componentParent: this },
        onDelete: (authorId: number) => this.delete(authorId)
      }
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
    onCellEditingStarted: (event: any) => {
      this.originalValue = event.data.name;
    },
    onCellValueChanged: (event: any) => {
      this.handleCellValueChanged(event);
    }
  };

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.authorForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(40)]]
    });
  }

  ngOnInit() {
    this.getAuthors();
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

  getAuthors() {
    this.http.get<Author[]>('/authors').subscribe(
      (result) => {
        this.authors = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  addAuthor() {
    if (this.authorForm.valid) {
      const newAuthor: Author = {
        id: 0,
        name: this.authorForm.value.name
      };

      this.http.post<Author>('/authors', newAuthor).subscribe(
        (result) => {
          const newAuthorCopy = { ...result };
          this.authors = [...this.authors, newAuthorCopy];
          this.openToast('Autor adicionado com sucesso!', 'Sucesso', 'success');
        },
        (error) => {
          this.openToast('Erro ao adicionar autor. Tente novamente.', 'Erro', 'error');
        }
      );
    } else {
      this.openToast('Por favor, preencha o nome do autor.', 'Atenção', 'error');
    }
  }

  delete(authorId: number) {
    if (confirm('Você tem certeza que deseja deletar este autor?')) {
      this.http.delete(`/authors/${authorId}`).subscribe(
        () => {
          this.authors = this.authors.filter(author => author.id !== authorId);
          this.openToast('Autor deletado com sucesso!', 'Sucesso', 'success');
        },
        (error) => {
          this.openToast('Erro ao deletar autor. Tente novamente.', 'Erro', 'error');
        }
      );
    }
  }

  handleCellValueChanged(event: any) {
    const updatedAuthor = event.data;

    if (this.isUpdating) {
      return;
    }

    this.isUpdating = true;

    this.http.put<Author>(`/authors/${updatedAuthor.id}`, updatedAuthor).subscribe(
      (result) => {
        this.isUpdating = false;
        this.openToast('Autor atualizado com sucesso!', 'Sucesso', 'success');
      },
      (error) => {
        this.isUpdating = false;
        event.data.name = this.originalValue;
        this.gridApi.refreshCells({ rowNodes: [event.node], force: true });
        this.openToast('Erro ao atualizar autor. O valor foi revertido.', 'Erro', 'error');
      }
    );
  }
}
