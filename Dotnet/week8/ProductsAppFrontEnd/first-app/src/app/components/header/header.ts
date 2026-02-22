
import { Component, signal, computed } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './header.html',
})
export class Header {
  user = signal({
    name: localStorage.getItem('name') || '',
    role: localStorage.getItem('role') || '',
  });
  isLoggedIn = computed(() => !!localStorage.getItem('token'));

  constructor(private router: Router, private auth: AuthService) {}

  logout() {
    this.auth.logout();
    this.router.navigate(['/login']);
  }
}
