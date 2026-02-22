import { Component, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  templateUrl: './register.html',
  imports: [FormsModule, RouterLink],
})
export class RegisterComponent {
  name = '';
  email = '';
  password = '';
  role = 'Viewer';
  error = signal('');

  constructor(private auth: AuthService, private router: Router) {}

  onRegister() {
    this.auth.register(this.name, this.email, this.password, this.role);
    setTimeout(() => {
      this.router.navigate(['/login']);
    }, 500);
  }
}
