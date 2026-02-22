import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Item } from '../models/Item';

// 🔗 Replace with your .NET backend URL once it is running
const API_URL = 'https://localhost:7291/api/Items';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  // Shared signals — any component can read these
  items   = signal<Item[]>([]);
  loading = signal<boolean>(false);
  error   = signal<string>('');

  constructor(private http: HttpClient) {}

  // GET all
  loadAll(): void {
    this.loading.set(true);
    this.error.set('');
    this.http.get<Item[]>(API_URL).subscribe({
      next: (data) => {
        this.items.set(data);
        this.loading.set(false);
      },
      error: (err) => {
        console.error(err);
        this.error.set('Could not load products. Is the backend running?');
        this.loading.set(false);
      }
    });
  }

  // GET one
  getById(id: number) {
    this.loading.set(true);
    this.error.set('');
    return this.http.get<Item>(`${API_URL}/${id}`);
  }

  // POST
  create(item: Omit<Item, 'id'>) {
    this.loading.set(true);
    this.error.set('');
    return this.http.post<Item>(API_URL, item);
  }

  // PUT
  update(id: number, item: Omit<Item, 'id'>) {
    this.loading.set(true);
    this.error.set('');
    return this.http.put<Item>(`${API_URL}/${id}`, item);
  }

  // DELETE
  delete(id: number) {
    this.loading.set(true);
    this.error.set('');
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}