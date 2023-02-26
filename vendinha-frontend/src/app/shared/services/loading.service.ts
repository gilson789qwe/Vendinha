import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  loading$: Observable<boolean>;

  loadingOn() {
    this.loading$ = of(true);
    document.querySelector('html').style.overflow = "hidden";
  }
  loadingOff() {
    this.loading$ = of(false);
    document.querySelector('html').style.overflow = "auto";
  }
}
