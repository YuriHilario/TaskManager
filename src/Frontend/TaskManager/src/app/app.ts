import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from './components/template/header/header';
import { Nav } from './components/template/nav/nav';
import { Home } from './components/views/home/home';
import { MatCard } from '@angular/material/card';
import { Login } from './components/views/login/login';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header, Nav, Home, MatCard, Login],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'TaskManager';
}
