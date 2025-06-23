import { Component } from '@angular/core';
import { Nav } from '../../template/nav/nav';
import { Header } from '../../template/header/header';

@Component({
  selector: 'app-home',
  imports: [Nav, Header],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {

}
