import { Component, signal } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ItemService } from '../../services/item';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './create.html',
  styleUrl: './create.css'
})
export class CreateComponent {

  name        = signal('');
  category    = signal('');
  price       = signal<number | null>(null);
  quantity    = signal<number | null>(null);
  status      = signal('In Stock');
  description = signal('');
  success     = signal('');

  constructor(public itemService: ItemService, private router: Router) {}

  onSubmit(): void {
    if (!this.name() || !this.category() || this.price() === null || this.quantity() === null || !this.description()) {
      this.itemService.error.set('Please fill in all fields.');
      return;
    }

    this.itemService.error.set('');
    this.success.set('');

    this.itemService.create({
      name:        this.name(),
      category:    this.category(),
      price:       this.price()!,
      quantity:    this.quantity()!,
      status:      this.status(),
      description: this.description()
    }).subscribe({
      next: () => {
        this.itemService.loading.set(false);
        this.success.set('✅ Product created! Redirecting...');
        setTimeout(() => this.router.navigate(['/view']), 1500);
      },
      error: (err) => {
        console.error(err);
        this.itemService.error.set('Failed to create product. Check your backend.');
        this.itemService.loading.set(false);
      }
    });
  }

  onReset(): void {
    this.name.set('');
    this.category.set('');
    this.price.set(null);
    this.quantity.set(null);
    this.status.set('In Stock');
    this.description.set('');
    this.success.set('');
    this.itemService.error.set('');
  }
}