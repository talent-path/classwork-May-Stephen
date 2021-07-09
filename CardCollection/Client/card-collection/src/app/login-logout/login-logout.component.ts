import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AccountService } from 'src/services/account-service';

@Component({
  selector: 'app-login-logout',
  templateUrl: './login-logout.component.html',
  styleUrls: ['./login-logout.component.css']
})
export class LoginLogoutComponent implements OnInit {

  loggedIn: boolean;

  constructor(private service : AccountService) {
    this.loggedIn = this.isLoggedIn();
   }

  ngOnInit(): void {
   
  }

  logout() {
    this.service.logout();
  }

  isLoggedIn(): boolean {
    return this.service.isLoggedIn();
    
  }
}
