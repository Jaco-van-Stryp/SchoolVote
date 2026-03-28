import { Routes } from '@angular/router';
import { LoginComponent } from './components/login-component/login-component';
import { RegisterComponent } from './components/register-component/register-component';
import { Dashboard } from './components/dashboard/dashboard';

export const routes: Routes = [
  {
    path: '',
    component: LoginComponent,
    title: 'Login',
  },
  {
    path: 'Register',
    component: RegisterComponent,
    title: 'Register',
  },
  {
    path: 'Login',
    component: LoginComponent,
    title: 'Login',
  },
  {
    path: 'Dashboard',
    component: Dashboard,
    title: 'Dashboard',
  },
];
