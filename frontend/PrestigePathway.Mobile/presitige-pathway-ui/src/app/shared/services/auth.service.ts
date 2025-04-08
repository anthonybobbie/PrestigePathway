import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';

// Interfaces for payloads and response data
export interface LoginPayload {
  username: string;
  password: string;
}

export interface RegisterPayload {
  email: string;
  password: string;
  name: string;
}

export interface User {
  id: number;
  name: string;
  email: string;
}

export interface AuthResponse {
  user: User;
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // Base URL for authentication endpoints
  private readonly base: string = environment.baseUrl+'/auth';

  constructor(private httpClient: HttpClient) {}

  /**
   * Log in with credentials and store token on success.
   * @param payload - The login credentials.
   * @returns An observable with the authentication response.
   */
  login(payload: LoginPayload): Observable<AuthResponse> {
    return this.httpClient
      .post<AuthResponse>(`${this.base}/login`, payload)
      .pipe(
        tap((response: AuthResponse) => {
          // Store the token and optionally the user data in local storage
          localStorage.setItem('token', response.token);
          localStorage.setItem('user', JSON.stringify(response.user));
          console.log('User logged in:', response.user);
        }),
        catchError(this.handleError)
      );
  }

  /**
   * Register a new user.
   * @param payload - The registration information.
   * @returns An observable with the registration response.
   */
  register(payload: RegisterPayload): Observable<AuthResponse> {
    return this.httpClient
      .post<AuthResponse>(`${this.base}/register`, payload)
      .pipe(
        tap((response: AuthResponse) => {
          // Optionally, store token and user info after registration
          localStorage.setItem('token', response.token);
          localStorage.setItem('user', JSON.stringify(response.user));
          console.log('User registered:', response.user);
        }),
        catchError(this.handleError)
      );
  }

  /**
   * Logs out the current user.
   * Clears token and user from local storage.
   * @returns An observable with the logout response.
   */
  logout(): Observable<any> {
    // Remove token and user data from local storage
    localStorage.removeItem('token');
    localStorage.removeItem('user');

    // Optionally, call the backend API to invalidate the token
    return this.httpClient
      .post(`${this.base}/logout`, {})
      .pipe(
        tap(() => console.log('User logged out')),
        catchError(this.handleError)
      );
  }

  /**
   * Checks if the user is authenticated.
   * @returns A boolean indicating if a user token exists in local storage.
   */
  isAuthenticated(): boolean {
    return localStorage.getItem('token') !== null;
  }

  /**
   * Gets the current user details from the backend.
   * @returns An observable containing the user information.
   */
  getUser(): Observable<User> {
    return this.httpClient
      .get<User>(`${this.base}/user`)
      .pipe(
        tap((user: User) => {
          // Optionally update local storage with the latest user information
          localStorage.setItem('user', JSON.stringify(user));
        }),
        catchError(this.handleError)
      );
  }

  /**
   * Handle HTTP errors.
   * @param error - The error response.
   * @returns A throwError observable with the error message.
   */
  private handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred.
      errorMessage = `Client error: ${error.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      errorMessage = `Server error: ${error.status} ${error.message}`;
    }
    console.error(errorMessage);
    return throwError(() => new Error(errorMessage));
  }
}
