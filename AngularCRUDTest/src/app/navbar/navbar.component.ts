import { Component, OnInit } from '@angular/core';
import { NavbarClass } from '../navbar-class'
import { NavbarService } from '../navbar.service'

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  links: NavbarClass[]

  constructor(private service: NavbarService) { }

  ngOnInit() {
    this.service.getLinks().subscribe((data: NavbarClass[]) => {
      this.links = data;
    })
  }
}


