import { Routes } from '@angular/router';
import { EncuestaListComponent } from './components/encuesta-list/encuesta-list.component';
import { EncuestaFormComponent } from './components/encuesta-form/encuesta-form.component';

export const appRoutes: Routes = [
  { path: '', redirectTo: '/encuestas', pathMatch: 'full' },
  //{path: 'encuestas', loadChildren: () => import("./components/encuesta-list/encuesta-list.module").then(el => el.EncuestaListModule)},
  { path: 'encuestas', component: EncuestaListComponent },
  { path: 'encuestas/new', component: EncuestaFormComponent },
  { path: 'encuestas/edit/:id', component: EncuestaFormComponent },
];