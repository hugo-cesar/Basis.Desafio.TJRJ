import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Author } from '../../author/author.component';
import { Book, PurchaseType } from '../../book/book.component';
import { Subject } from '../../subject/subject.component';

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrl: './book-form.component.css'
})
export class BookFormComponent {
  public authors: Author[] = [];
  public subjects: Subject[] = [];
  public purchaseTypes: PurchaseType[] = [];

  public bookForm: FormGroup;

  public isUpdating = false;
  public showToast: boolean = false;
  public toastMessage: string = '';
  public toastTitle: string = '';
  public toastType: 'success' | 'error' = 'success';

  private bookId: number = 0;

  get purchaseDetails(): FormArray<FormGroup> {
    return this.bookForm.get('purchaseDetails') as FormArray<FormGroup>;
  }

  constructor(private http: HttpClient, private fb: FormBuilder, private route: ActivatedRoute) {
    this.bookForm = this.fb.group({
      title: ['', Validators.required],
      publisher: ['', Validators.required],
      edition: [null, [Validators.required, Validators.min(1)]],
      publicationYear: [null, [Validators.required, Validators.min(1900), Validators.max(2040)]],
      authors: [[], Validators.required],
      subjects: [[], Validators.required],
      purchaseDetails: this.fb.array([])
    });
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isUpdating = true;
      this.bookId = Number(id);
      this.getBookById(this.bookId);
    }

    this.getAuthors();
    this.getSubjects();
    this.getPurchaseTypes();
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

  getPurchaseTypes() {
    this.http.get<PurchaseType[]>('/books/purchase-types').subscribe(
      (result) => {
        this.purchaseTypes = result;
        const purchaseFormArray = this.bookForm.get('purchaseDetails') as FormArray;
        this.purchaseTypes.forEach(() => {
          purchaseFormArray.push(this.fb.group({
            typeId: [null],
            value: [null, [Validators.min(0)]]
          }));
        });
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getBookById(id: number) {
    this.http.get<Book[]>(`/books/${id}`).subscribe(
      (result) => {
        this.bookForm.patchValue(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onSubmit(): void {
    if (this.isUpdating) {
      this.updateBook(this.bookId);
    } else {
      this.addBook();
    }
  }

  onCheckboxChange(event: Event, index: number) {
    const checkbox = event.target as HTMLInputElement;

    const purchaseDetailsArray = this.bookForm.get('purchaseDetails') as FormArray;

    if (checkbox.checked) {
      purchaseDetailsArray.at(index).patchValue({ typeId: checkbox.value });
    } else {
      purchaseDetailsArray.at(index).patchValue({ typeId: null });
    }
  }

  addBook() {
    if (this.bookForm.valid) {

      const purchases = this.bookForm.value.purchaseDetails
        .filter((detail: any) => detail.typeId != null)
        .map((detail: any) => ({
          id: detail.typeId,
          price: detail.value
        }));

      const newBook: Book = {
        id: 0,
        title: this.bookForm.value.title,
        publisher: this.bookForm.value.publisher,
        edition: this.bookForm.value.edition,
        publicationYear: String(this.bookForm.value.publicationYear),
        subjects: this.bookForm.value.subjects,
        authors: this.bookForm.value.authors,
        purchaseTypes: purchases
      };

      this.http.post<Book>('/books', newBook).subscribe(
        (result) => {
          this.openToast('Livro adicionado com sucesso!', 'Sucesso', 'success');
        },
        (error) => {
          this.openToast('Erro ao adicionar livro. Tente novamente.', 'Erro', 'error');
        }
      );
    } else {
      this.openToast('Por favor, preencha a descrição do assunto.', 'Atenção', 'error');
    }
  }

  updateBook(bookId: number) {
    if (this.bookForm.valid) {

      const purchases = this.bookForm.value.purchaseDetails
        .filter((detail: any) => detail.typeId != null)
        .map((detail: any) => ({
          id: detail.typeId,
          price: detail.value
        }));

      const updatedBook: Book = {
        id: bookId,
        title: this.bookForm.value.title,
        publisher: this.bookForm.value.publisher,
        edition: this.bookForm.value.edition,
        publicationYear: String(this.bookForm.value.publicationYear),
        subjects: this.bookForm.value.subjects,
        authors: this.bookForm.value.authors,
        purchaseTypes: purchases,
      };

      this.http.put<Book>(`/books/${bookId}`, updatedBook).subscribe(
        (result) => {
          this.openToast('Livro atualizado com sucesso!', 'Sucesso', 'success');
        },
        (error) => {
          this.openToast('Erro ao atualizar livro. Tente novamente.', 'Erro', 'error');
        }
      );
    } else {
      this.openToast('Por favor, preencha todos os campos obrigatórios.', 'Atenção', 'error');
    }
  }

  openToast(message: string, title: string, type: 'success' | 'error' = 'success') {
    this.toastMessage = message;
    this.toastTitle = title;
    this.toastType = type;
    this.showToast = true;

    setTimeout(() => {
      this.showToast = false;
    }, 5000);
  }

  closeToast() {
    this.showToast = false;
  }

}
