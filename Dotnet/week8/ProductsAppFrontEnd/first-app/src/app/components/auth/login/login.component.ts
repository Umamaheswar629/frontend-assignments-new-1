import { Component, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.html',
  imports: [FormsModule, RouterLink],
})
export class LoginComponent {
  email = '';
  password = '';
  error = signal('');

  constructor(private auth: AuthService, private router: Router) {}

  onLogin() {
    this.auth.login(this.email, this.password);
    setTimeout(() => {
      if (this.auth.isLoggedIn()) {
        this.router.navigate(['/view']);
      } else {
        this.error.set('Invalid email or password');
      }
    }, 500);
  }
}
