import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { ColDef, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActionRenderer } from '../../action-renderer/action-renderer.component';

export interface Subject {
  id: number;
  description: string;
}

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrl: './subject.component.css'
})

export class SubjectComponent implements OnInit {
  public subjects: Subject[] = [];
  public subjectForm: FormGroup;
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
    { field: 'description', headerName: 'Descrição', sortable: true, filter: 'agTextColumnFilter', editable: true },
    {
      headerName: 'Ações',
      cellRenderer: ActionRenderer,
      cellRendererParams: {
        context: { componentParent: this },
        onDelete: (subjectId: number) => this.delete(subjectId)
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
      this.originalValue = event.data.description;
    },
    onCellValueChanged: (event: any) => {
      this.handleCellValueChanged(event);
    }
  };

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.subjectForm = this.fb.group({
      description: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.getSubjects();
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

  getSubjects() {
    this.http.get<Subject[]>('/subjects').subscribe(
      (result) => {
        this.subjects = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  addSubject() {
    if (this.subjectForm.valid) {
      const newSubject: Subject = {
        id: 0,
        description: this.subjectForm.value.description
      };

      this.http.post<Subject>('/subjects', newSubject).subscribe(
        (result) => {
          const newSubjectCopy = { ...result };
          this.subjects = [...this.subjects, newSubjectCopy];
          this.openToast('Assunto adicionado com sucesso!', 'Sucesso', 'success');
        },
        (error) => {
          this.openToast('Erro ao adicionar assunto. Tente novamente.', 'Erro', 'error');
        }
      );
    } else {
      this.openToast('Por favor, preencha a descrição do assunto.', 'Atenção', 'error');
    }
  }

  delete(subjectId: number) {
    if (confirm('Você tem certeza que deseja deletar este assunto?')) {
      this.http.delete(`/subjects/${subjectId}`).subscribe(
        () => {
          this.subjects = this.subjects.filter(subject => subject.id !== subjectId);
          this.openToast('Assunto deletado com sucesso!', 'Sucesso', 'success');
        },
        (error) => {
          this.openToast('Erro ao deletar assunto. Tente novamente.', 'Erro', 'error');
        }
      );
    }
  }

  handleCellValueChanged(event: any) {
    const updatedSubject = event.data;

    if (this.isUpdating) {
      return;
    }

    this.isUpdating = true;

    this.http.put<Subject>(`/subjects/${updatedSubject.id}`, updatedSubject).subscribe(
      (result) => {
        this.isUpdating = false;
        this.openToast('Assunto atualizado com sucesso!', 'Sucesso', 'success');
      },
      (error) => {
        this.isUpdating = false;
        event.data.name = this.originalValue;
        this.gridApi.refreshCells({ rowNodes: [event.node], force: true });
        this.openToast('Erro ao atualizar assunto. O valor foi revertido.', 'Erro', 'error');
      }
    );
  }
}
