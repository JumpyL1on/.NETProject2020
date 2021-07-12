import { Component } from '@angular/core';
import {AuthorizeService} from "../../api-authorization/authorize.service";
import {map} from "rxjs/operators";
import {Observable} from "rxjs";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})

export class NavMenuComponent {
  isExpanded = false;
  isAdmin: Observable<boolean>;

  constructor(private authorizeService: AuthorizeService) {
    this.isAdmin = this.authorizeService
      .getUser()
      .pipe(map(u => u && u.name == "admin@gmail.com"));
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
