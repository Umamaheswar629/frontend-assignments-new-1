import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { Router } from '@angular/router';

export const roleGuard: CanActivateFn = (route) => {
  const allowedRoles = route.data['roles'] as string[];
  const role = localStorage.getItem('role');
  const router = inject(Router);
  if (!role || !allowedRoles.includes(role)) {
    router.navigate(['/unauthorized']);
    return false;
  }
  return true;
};
