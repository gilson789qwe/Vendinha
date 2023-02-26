import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'users',
    pathMatch: 'full',
    data: { title: 'Usuários'}
  },
  {

    path: '',
    children: [
      {
        path: 'users',
        loadChildren: () => import('../app/modules/users/users.module').then((m) => m.UsersModule),
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
