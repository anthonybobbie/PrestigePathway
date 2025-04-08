import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { IonicModule, NavController } from '@ionic/angular';
import { AuthResponse, AuthService } from '../shared/services/auth.service';

@Component({
  standalone: true,
  imports: [FormsModule, IonicModule, ReactiveFormsModule],
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {
  email: string = '';
  password: string = '';

  constructor(
    private fb: FormBuilder,
    private navCtrl: NavController,
    private readonly authService: AuthService
  ) {

  }

  ngOnInit() { }

  login() {
    if (this.email.length > 0 && this.password.length > 0) {

      this.authService.login({ username: this.email, password: this.password })
        .subscribe({
          next: (response: AuthResponse) => {
            this.navCtrl.navigateForward('/home');
          }
        });


    }
  }
}
