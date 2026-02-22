
import { Routes } from '@angular/router';
import { ViewComponent } from './components/view/view';
import { CreateComponent } from './components/create/create';
import { UpdateComponent } from './components/update/update';
import { DeleteComponent } from './components/delete/delete';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { UnauthorizedComponent } from './components/auth/unauthorized/unauthorized.component';
import { authGuard } from './guards/auth.guard';
import { roleGuard } from './guards/role.guard';

export const routes: Routes = [
  { path: '', redirectTo: 'view', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'unauthorized', component: UnauthorizedComponent },
  { path: 'view', component: ViewComponent, canActivate: [authGuard] },
  { path: 'create', component: CreateComponent, canActivate: [authGuard, roleGuard], data: { roles: ['Admin', 'Manager'] } },
  { path: 'update/:id', component: UpdateComponent, canActivate: [authGuard, roleGuard], data: { roles: ['Admin', 'Manager'] } },
  { path: 'delete', component: DeleteComponent, canActivate: [authGuard, roleGuard], data: { roles: ['Admin'] } },
];