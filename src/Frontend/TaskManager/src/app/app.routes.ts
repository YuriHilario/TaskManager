import { Routes } from '@angular/router';
import { Entryview } from './components/views/entryview/entryview';
import { Login } from './components/views/login/login';
import { Home } from './components/views/home/home';
import { Tasks } from './components/views/tasks/tasks';
import { authGuard } from './guards/auth-guard';
import { CreateTask } from './components/views/tasks/createtask/createtask';
import { UpdateTask } from './components/views/tasks/updatetask/updatetask';


export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    component: Login
  },
  {
    path: 'home',
    component: Home,
    canActivate: [authGuard],
    children: [
      {
        path: '',
        component: Entryview
      },
      {
        path: 'tasks',
        component: Tasks
      },
      {
        path: 'tasks/edit/:id',
        component: UpdateTask
      },
      {
        path: 'tasks/create',
        component: CreateTask
      }
    ]
  },
  {
    path: '**',
    redirectTo: 'login'
  }
];


