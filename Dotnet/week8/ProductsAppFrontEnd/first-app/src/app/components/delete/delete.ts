import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ItemService } from '../../services/item';
import { Item } from '../../models/Item';

@Component({
  selector: 'app-delete',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './delete.html',
  styleUrl: './delete.css'
})
export class DeleteComponent {

  searchId  = signal('');
  foundItem = signal<Item | null>(null);
  success   = signal('');

  constructor(public itemService: ItemService) {}

  onSearch(): void {
    const id = Number(this.searchId());
    if (!id) {
      this.itemService.error.set('Please enter a valid ID.');
      return;
    }

    this.foundItem.set(null);
    this.success.set('');
    this.itemService.error.set('');

    this.itemService.getById(id).subscribe({
      next: (item) => {
        this.foundItem.set(item);
        this.itemService.loading.set(false);
      },
      error: (err) => {
        console.error(err);
        this.itemService.error.set(`Product with ID ${id} not found.`);
        this.itemService.loading.set(false);
      }
    });
  }

  onDelete(): void {
    const item = this.foundItem();
    if (!item) return;

    this.itemService.delete(item.id).subscribe({
      next: () => {
        this.itemService.loading.set(false);
        this.success.set(`"${item.name}" was deleted successfully.`);
        this.foundItem.set(null);
        this.searchId.set('');
      },
      error: (err) => {
        console.error(err);
        this.itemService.error.set('Delete failed. Please try again.');
        this.itemService.loading.set(false);
      }
    });
  }

  onCancel(): void {
    this.foundItem.set(null);
    this.success.set('');
    this.itemService.error.set('');
  }
}