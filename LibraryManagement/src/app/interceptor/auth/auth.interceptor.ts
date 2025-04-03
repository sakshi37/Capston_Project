import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  // debugger;
  const token = localStorage.getItem('token');
  const cloneReq = req.clone({
    setHeaders: { Authorization: `Bearer ${token}` },
  });
  return next(cloneReq);
};
