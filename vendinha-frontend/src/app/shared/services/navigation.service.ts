import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class NavigationService {
  constructor() { }

  isMenuClosed: boolean = localStorage.getItem('isMenuClosed') === 'true';

  toggleSidebar(): void {
    this.isMenuClosed = !this.isMenuClosed;
    localStorage.setItem('isMenuClosed', this.isMenuClosed.toString());
  }

}
