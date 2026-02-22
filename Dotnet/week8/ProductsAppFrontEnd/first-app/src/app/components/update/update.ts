import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ItemService } from '../../services/item';

@Component({
  selector: 'app-update',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './update.html',
  styleUrl: './update.css'
})
export class UpdateComponent implements OnInit {

  id          = signal(0);
  name        = signal('');
  category    = signal('');
  price       = signal<number | null>(null);
  quantity    = signal<number | null>(null);
  status      = signal('In Stock');
  description = signal('');
  success     = signal('');

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    public itemService: ItemService
  ) {}

  ngOnInit(): void {
    const urlId = Number(this.route.snapshot.paramMap.get('id'));
    this.id.set(urlId);
    if (urlId && urlId !== 0) this.loadItem(urlId);
  }

  loadItem(id: number): void {
    this.itemService.getById(id).subscribe({
      next: (item) => {
        this.name.set(item.name);
        this.category.set(item.category);
        this.price.set(item.price);
        this.quantity.set(item.quantity);
        this.status.set(item.status);
        this.description.set(item.description);
        this.itemService.loading.set(false);
      },
      error: (err) => {
        console.error(err);
        this.itemService.error.set(`Product with ID ${id} not found.`);
        this.itemService.loading.set(false);
      }
    });
  }

  onSearch(inputId: string): void {
    const numId = Number(inputId);
    if (!numId) return;
    this.id.set(numId);
    this.loadItem(numId);
  }

  onSubmit(): void {
    if (!this.name() || !this.category() || this.price() === null || this.quantity() === null || !this.description()) {
      this.itemService.error.set('Please fill in all fields.');
      return;
    }

    this.itemService.error.set('');
    this.success.set('');

    this.itemService.update(this.id(), {
      name:        this.name(),
      category:    this.category(),
      price:       this.price()!,
      quantity:    this.quantity()!,
      status:      this.status(),
      description: this.description()
    }).subscribe({
      next: () => {
        this.itemService.loading.set(false);
        this.success.set('✅ Product updated! Redirecting...');
        setTimeout(() => this.router.navigate(['/view']), 1500);
      },
      error: (err) => {
        console.error(err);
        this.itemService.error.set('Failed to update product. Check your backend.');
        this.itemService.loading.set(false);
      }
    });
  }
}