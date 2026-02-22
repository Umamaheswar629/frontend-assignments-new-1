
import { signal, computed, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export interface AuthUser {
  name: string;
  email: string;
  role: string;
}

const API_URL = 'https://localhost:7291/api/Auth';

@Injectable({ providedIn: 'root' })
export class AuthService {
  currentUser = signal<AuthUser | null>(null);
  isLoggedIn = computed(() => !!localStorage.getItem('token'));

  constructor(private http: HttpClient) {
    const token = localStorage.getItem('token');
    const name = localStorage.getItem('name');
    const email = localStorage.getItem('email');
    const role = localStorage.getItem('role');
    if (token && name && email && role) {
      this.currentUser.set({ name, email, role });
    }
  }

  login(email: string, password: string) {
    this.http.post<any>(`${API_URL}/login`, { email, password })
      .subscribe({
        next: (res) => {
          localStorage.setItem('token', res.token);
          localStorage.setItem('name', res.name);
          localStorage.setItem('email', res.email);
          localStorage.setItem('role', res.role);
          this.currentUser.set({ name: res.name, email: res.email, role: res.role });
        },
        error: () => {
          this.currentUser.set(null);
        }
      });
  }

  register(name: string, email: string, password: string, role: string) {
    this.http.post<any>(`${API_URL}/register`, { name, email, password, role })
      .subscribe();
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('name');
    localStorage.removeItem('email');
    localStorage.removeItem('role');
    this.currentUser.set(null);
  }
}
