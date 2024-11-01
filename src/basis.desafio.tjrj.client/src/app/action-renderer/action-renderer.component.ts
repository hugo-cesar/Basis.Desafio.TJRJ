import { Component } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';

@Component({
  selector: 'app-action-renderer',
  template: `
    <button (click)="onDelete()" class="btn btn-danger btn-sm rounded">Deletar</button>
    <button *ngIf="params.isBookPage" (click)="onEdit()" class="btn btn-primary btn-sm rounded"><i class="bi bi-pencil"></i>Alterar</button>
  `,
})
export class ActionRenderer implements ICellRendererAngularComp {
  params: any;

  agInit(params: any): void {
    this.params = params;
  }

  onDelete() {
    this.params.context.componentParent.delete(this.params.data.id);
  }

  onEdit() {
    this.params.context.componentParent.edit(this.params.data.id);
  }

  refresh(): boolean {
    return false;
  }
}
