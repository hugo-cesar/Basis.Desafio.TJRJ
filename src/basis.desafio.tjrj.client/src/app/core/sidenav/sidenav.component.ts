import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidenav',  // Este é o seletor que você deve usar
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})

export class SidenavComponent {
  constructor(private router: Router) { }

  navigateToAuthor() {
    this.router.navigate(['/author']);
  }
}
