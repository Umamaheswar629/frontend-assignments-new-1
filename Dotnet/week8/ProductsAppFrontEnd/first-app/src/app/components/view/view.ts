import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ItemService } from '../../services/item';

@Component({
  selector: 'app-view',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './view.html',
  styleUrl: './view.css'
})
export class ViewComponent implements OnInit {

  constructor(public itemService: ItemService, private router: Router) {}

  ngOnInit(): void {
    this.itemService.loadAll();
  }

  goToUpdate(id: number): void {
    this.router.navigate(['/update', id]);
  }

  onDelete(id: number): void {
    const confirmed = confirm('Are you sure you want to delete this product?');
    if (!confirmed) return;

    this.itemService.delete(id).subscribe({
      next: () => {
        this.itemService.loading.set(false);
        this.itemService.loadAll();
      },
      error: (err) => {
        console.error(err);
        this.itemService.error.set('Failed to delete. Please try again.');
        this.itemService.loading.set(false);
      }
    });
  }
}