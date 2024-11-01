import { Component, OnInit } from '@angular/core';
import jsPDF from 'jspdf';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface ReportData {
  reportBookAuthors: ReportBookAuthor[];
  reportBookYears: ReportBookYear[];
  reportSubjects: ReportSubject[];
}

interface ReportBookAuthor {
  author: string;
  books: string[];
}

interface ReportBookYear {
  year: string;
  books: string[];
}

interface ReportSubject {
  subject: string;
  books: string[];
}

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  public reportData: ReportData = { reportBookAuthors: [], reportBookYears: [], reportSubjects: [] };

  pdfUrl: string | undefined;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getReportData();
  }

  getReportData() {
    this.http.get<ReportData>('/books/report').subscribe(
      (result) => {
        this.reportData = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }


  generatePdf() {
    const pdf = new jsPDF();
    const title = 'Autores e seus Livros';

    pdf.setFontSize(14);
    pdf.text(title, 10, 10);

    const firstTableHeight = this.generateTable(pdf, 20, 'Autor', 'Livros', this.reportData.reportBookAuthors.map(item => ({
      col1: item.author,
      col2: item.books
    })));

    const yearTableStartY = 30 + firstTableHeight;
    pdf.setFontSize(14);
    pdf.text('Livros publicados por Ano', 10, yearTableStartY);
    const secondTableHeight = this.generateTable(pdf, yearTableStartY + 10, 'Ano', 'Livros', this.reportData.reportBookYears.map(item => ({
      col1: item.year,
      col2: item.books
    })));

    const subjectTableStartY = yearTableStartY + 20 + secondTableHeight;
    pdf.setFontSize(14);
    pdf.text('Assuntos por livro', 10, subjectTableStartY);
    const thirdTableHeight = this.generateTable(pdf, subjectTableStartY + 10, 'Assunto', 'Livros', this.reportData.reportSubjects.map(item => ({
      col1: item.subject,
      col2: item.books
    })));

    const pdfBlob = pdf.output('blob');
    this.pdfUrl = URL.createObjectURL(pdfBlob);
    pdf.save('relatorio.pdf');
  }

  private generateTable(pdf: jsPDF, startY: number, col1Title: string, col2Title: string, data: { col1: string; col2: string[] }[]): number {
    const rowHeight = 10;
    const col1X = 10;
    const col2X = 60;
    const tableWidth = 180;
    const col1Width = col2X - col1X;
    const col2Width = tableWidth - col1Width;

    pdf.setFontSize(12);
    pdf.text(col1Title, col1X + 2, startY + 5);
    pdf.text(col2Title, col2X + 2, startY + 5);
    pdf.rect(col1X, startY, col1Width, rowHeight);
    pdf.rect(col2X, startY, col2Width, rowHeight);
    startY += rowHeight;

    data.forEach(item => {
      const booksHeight = item.col2.length * rowHeight;

      if (startY + Math.max(rowHeight, booksHeight) > pdf.internal.pageSize.height) {
        pdf.addPage();
        startY = 10;
      }

      pdf.rect(col1X, startY, col1Width, booksHeight);
      pdf.text(item.col1, col1X + 2, startY + 5);

      pdf.rect(col2X, startY, col2Width, booksHeight);
      let bookY = startY;
      item.col2.forEach(book => {
        pdf.text(`• ${book}`, col2X + 2, bookY + 5);
        bookY += rowHeight;
      });

      startY += Math.max(rowHeight, booksHeight);
    });

    return startY;
  }
}
