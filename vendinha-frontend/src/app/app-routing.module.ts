import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'customers',
    pathMatch: 'full',
    data: { title: 'Usuários'}
  },
  {

    path: '',
    children: [
      {
        path: 'customers',
        loadChildren: () => import('../app/modules/customers/customers.module').then((m) => m.CustomersModule),
        data: { title: 'Usuários' },

      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
